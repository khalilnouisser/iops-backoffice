using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IOPSApi.Data;
using Microsoft.AspNetCore.Hosting;
using IOPSApi.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace IOPSApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IModelService,ModelService>();
			services
					.AddMvcCore()
					.AddAuthorization()
					.AddJsonFormatters(j => j.Formatting = Newtonsoft.Json.Formatting.Indented);
             
			services.AddCors(options =>
				{
					options.AddPolicy("CorsPolicy",
						builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
				});

            services.AddSingleton(Configuration);
            services.AddMvc(options=>{
				options.InputFormatters.Add(new TextPlainInputFormatter());
			}).AddJsonOptions(options =>
            {  
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

			services.AddDbContext<MysqlDBContext>();

			// Register the Swagger generator, defining one or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,MysqlDBContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            context.Database.EnsureCreated();
            app.UseMvc(); 

			app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());


			app.UseSwagger(c =>
				{
					c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
				});
			app.UseSwaggerUi(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
				}); 
        }
    }
     
	

}

public class TextPlainInputFormatter : TextInputFormatter
	{
		public TextPlainInputFormatter()
		{
			SupportedMediaTypes.Add("text/plain");
			SupportedEncodings.Add(UTF8EncodingWithoutBOM);
			SupportedEncodings.Add(UTF16EncodingLittleEndian);
		} 

		protected override bool CanReadType(Type type)
		{
			return true;
		}

		public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
		{
			string data = null;
			using (var streamReader = context.ReaderFactory(
				context.HttpContext.Request.Body,
				encoding))
			{
				data = await streamReader.ReadToEndAsync();
			}

			return InputFormatterResult.Success(data);
		}
	}