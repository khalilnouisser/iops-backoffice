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

namespace IOPSBackend.Controllers
{
    [Route("api/[controller]")]
    public class ContestController : Controller
    {

        ContestRepository _repo;
		IModelService _modelServices;

        public ContestController(MysqlDBContext c, ContestRepository repo, IModelService modelServices)
		{
			this._repo = repo;
			this._modelServices = modelServices;
		}


        [HttpGet("international/{Edition}")]
        public IActionResult Get(int Edition)
        {
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.result = _repo.getInternationalContestByEdition(Edition);

			return Ok(result);
        }

        [HttpGet("national/{Name}/{Edition}")]
		public IActionResult GetN(string Name , int Edition)
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.result = _repo.getNationalContest(Name,Edition);

			return Ok(result);
		}

		[HttpGet("local/{Name}/{Edition}")]
		public IActionResult GetL(string Name, int Edition)
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.result = _repo.getLocalContest(Name, Edition);

			return Ok(result);
		}

		[HttpGet("details/{Name}/{Edition}")]
		public IActionResult GetD(string Name, int Edition)
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.result = _repo.getFullDetails(Name, Edition);

			return Ok(result);
		}

		[HttpPost("international")]
        public IActionResult Add([FromBody]InternationalContest c)
		{
			dynamic result = new ExpandoObject();

			if (ModelState.IsValid)
			{
				InternationalContest c2 = _repo.addNewInternationalContest(c.Edition);

				if (c2 == null)
				{
					result.status = 0;
					result.message = "Contest exist";
				}
				else
				{
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

		[HttpPost("national")]
        public IActionResult AddN([FromBody]NationalContest c)
		{
			dynamic result = new ExpandoObject();
			if (ModelState.IsValid)
			{
				NationalContest c2 = _repo.addNewNationalContest(c);

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
			}
			else
			{
				result.status = 0;
				result.message = _modelServices.GetErrorMessage(ModelState);
			}


			return Ok(result);
		}

		[HttpPost("local")]
        public IActionResult AddL([FromBody]LocalContest c)
		{
			dynamic result = new ExpandoObject();

			if (ModelState.IsValid)
			{
				LocalContest c2 = _repo.addnewLocalContest(c);

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
			}
			else
			{
				result.status = 0;
				result.message = _modelServices.GetErrorMessage(ModelState);
			}
			return Ok(result);
		}



    }
}
