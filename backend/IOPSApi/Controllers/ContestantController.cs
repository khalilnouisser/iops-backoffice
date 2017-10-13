using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IOPSBackend.Repositories;
using IOPSBackend.Models;
using IOPSBackend.Services;
using System.Dynamic;
using IOPSBackend.Data;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOPSBackend.Controllers
{
    [Route("api/[controller]")]
    public class ContestantController : Controller
    {
        
        SendMailService _mailService;
        UserRepository _repo;
        IModelService _modelServices;
        public ContestantController(IModelService ims,SendMailService s,UserRepository ur){
            _mailService = s;
            _repo = ur;
            _modelServices = ims;
        }
        // GET: api/values
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody]Contestant c)
        {
            dynamic result = new ExpandoObject();

            if (ModelState.IsValid)
            {
                Contestant c2 = _repo.SignUp(c);

                if (c2 == null)
                {
                    result.status = 0;
                    result.message = "Verify your infromations";
                }
                else
                {
                    await this._mailService.SendMailConfirmationToContestantAsync(c);
                    result.status = 1;
                    result.result = c2;
                }
            }
            else
            {
                result.status = 0;
                result.message = _modelServices.GetErrorMessage(ModelState);
            }
            return Ok(result);
        }

        [HttpPost("confirm/{code}")]
		public IActionResult Confirm(string code)
		{
			dynamic result = new ExpandoObject();

                Contestant c2 = _repo.ConfirmMail(code);

				if (c2 == null)
				{
					result.status = 0;
					result.message = "Verify your infromations";
				}
				else
				{
					result.status = 1;
					result.result = c2;
				}
			
			return Ok(result);
		}

		[HttpPost("block/{id}")]
		public IActionResult Block(int id)
		{
			dynamic result = new ExpandoObject();

            Contestant c2 = _repo.BlockContestant(id);

			if (c2 == null)
			{
				result.status = 0;
				result.message = "Verify your infromations";
			}
			else
			{
				result.status = 1;
				result.result = c2;
			}

			return Ok(result);
		}

		[HttpPost("active/{id}")]
		public IActionResult Active(int id)
		{
			dynamic result = new ExpandoObject();

			Contestant c2 = _repo.ActiveContestant(id);

			if (c2 == null)
			{
				result.status = 0;
				result.message = "Verify your infromations";
			}
			else
			{
				result.status = 1;
				result.result = c2;
			}

			return Ok(result);
		}

		[HttpPost("refuse/{id}")]
		public IActionResult Refuse(int id)
		{
			dynamic result = new ExpandoObject();

			Contestant c2 = _repo.RefuseContestant(id);

			if (c2 == null)
			{
				result.status = 0;
				result.message = "Verify your infromations";
			}
			else
			{
				result.status = 1;
				result.result = c2;
			}

			return Ok(result);
		}

	}
}
