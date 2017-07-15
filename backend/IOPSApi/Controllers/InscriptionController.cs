using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using IOPSApi.Models;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using IOPSApi.Data;
using IOPSApi.Services;

namespace IOPSApi.Controllers 
{
    [Route("api/[controller]")]
    public class InscriptionController : Controller
    {
		private IHostingEnvironment _environment;

		private MysqlDBContext _context;
		private IModelService _modelS;


		public InscriptionController(IModelService modelS,MysqlDBContext context,IHostingEnvironment environment)
		{
			_environment = environment;
            _context = context;
            _modelS = modelS;
		}

        [HttpPost]
        /*public async Task<IActionResult> Index(IList<IFormFile> files)
        {
			long size = 0;
			foreach (var file in files)
			{
				var filename = ContentDispositionHeaderValue
								.Parse(file.ContentDisposition)
								.FileName
								.Trim('"');
				filename = _environment.WebRootPath + $@"\{filename}";
				size += file.Length;
				using (FileStream fs = System.IO.File.Create(filename))
				{
					file.CopyTo(fs);
					fs.Flush();
				}
			}
            string Message = $"{files.Count} file(s) /  { size} bytes uploaded successfully!";
            return Ok(Message);
        }*/

        public async Task<IActionResult> Upload(IFormFile file,Inscription userInscri)
		{
            //string PathUpload = _environment.WebRootPath + "/../../../images/users/";
            string PathUpload = _environment.WebRootPath + "../../tops/images/users/";
			dynamic response = new ExpandoObject();
            if (ModelState.IsValid && file != null && file.Length!=0)
            {
				Inscription u1 = await _context.Inscriptions.Where(k => k.EmailAdress == userInscri.EmailAdress).FirstOrDefaultAsync();
                Inscription u2 = await _context.Inscriptions.Where(k => k.Username == userInscri.Username).FirstOrDefaultAsync();
                 
				if(u1!=null||u2!=null){
					response.status = 0;
					response.extra = new ExpandoObject();
					response.extra.userInscri = userInscri;
					response.extra.errorMessage = "Registration already exists";
					
					return BadRequest(response);
                }

                if (Path.GetExtension(file.FileName)=="php"){
					response.status = 0;
					response.extra = new ExpandoObject();
					response.extra.userInscri = userInscri;
					response.extra.errorMessage = "Upload image not a shell php";

					return BadRequest(response);
                } 

				Random rnd = new Random();
				using (Stream stream = file.OpenReadStream())
				{
					using (var binaryReader = new BinaryReader(stream))
					{
						byte[] fileContent = binaryReader.ReadBytes((int)file.Length);
                        var alea = rnd.Next(1000000, int.MaxValue);

                        var filename = alea + "_" + userInscri.Fname + "_" + userInscri.Lname +"."+Path.GetExtension(file.FileName);
						if (!Directory.Exists(PathUpload))
						{
							Directory.CreateDirectory(PathUpload);
						}
						string FullFileName = PathUpload + filename;
						Console.WriteLine(FullFileName);

						using (FileStream fs = System.IO.File.Create(FullFileName))
						{
							file.CopyTo(fs);
							fs.Flush();
						}

                        userInscri.DateInsc = DateTime.Now;
                        userInscri.CEPic = filename;
                        await _context.Inscriptions.AddAsync(userInscri);
                        await _context.SaveChangesAsync();
						response.status = 1;
						response.extra = new ExpandoObject();
						response.extra.inscription = userInscri;
						return Ok(response);
					} 
				}

            }
            else {
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.admin = userInscri;
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
                if (file==null){
                    response.extra.errorMessage += " , File is null";
                }
                else if (file.Length == 0){
					response.extra.errorMessage += " , File is empty";
				}
				return BadRequest(response);
            }


		}
    }
}
