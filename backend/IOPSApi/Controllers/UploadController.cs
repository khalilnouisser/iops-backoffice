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
using System.Diagnostics.Contracts;

namespace IOPSApi.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {

		private IHostingEnvironment _environment;
		private IModelService _modelS;

		public UploadController(IModelService modelS, IHostingEnvironment environment)
		{
			_environment = environment;
			_modelS = modelS;
        }

        [HttpPost("{path}")]
        public IActionResult Upload(IFormFile image, string path)
		{
            IFormFile file = image;
			string PathUpload = _environment.WebRootPath + "/../../../images/"+path+"/";
			dynamic response = new ExpandoObject();
			if ( file != null && file.Length != 0)
			{
				if (Path.GetExtension(file.FileName) == "php")
				{
					response.status = 0;
					response.extra = new ExpandoObject();
					response.extra.errorMessage = "Upload image not a shell php";
					return BadRequest(response);
				}

				Random rnd = new Random();
				using (Stream stream = file.OpenReadStream())
				{
					using (var binaryReader = new BinaryReader(stream))
					{
						byte[] fileContent = binaryReader.ReadBytes((int)file.Length);
						var alea = rnd.Next(10, int.MaxValue);

                        var filename = alea + "_" + DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day+"-"+DateTime.Now.Hour+ "-" + Path.GetExtension(file.FileName);
						if (!Directory.Exists(PathUpload))
						{
							Directory.CreateDirectory(PathUpload);
						}
						string FullFileName = PathUpload + filename;
						Console.WriteLine("FullFileName"+FullFileName);

						using (FileStream fs = System.IO.File.Create(FullFileName))
						{
							file.CopyTo(fs);
							fs.Flush();
						}

						response.status = 1;
						response.extra = new ExpandoObject();
						response.extra.filename = filename;
						response.extra.FullFileName = FullFileName;
						return Ok(response);
					}
				}

			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.path = file;
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				if (file == null)
				{
					response.extra.errorMessage += " , File is null";
				}
				else if (file.Length == 0)
				{
					response.extra.errorMessage += " , File is empty";
				}
				return BadRequest(response);
			}


		}

    }
}
