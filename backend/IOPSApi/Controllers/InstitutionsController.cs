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
    public class InstitutionsController : Controller
    {
        InstitutionRepository _repo;
		IModelService _modelServices;
		public InstitutionsController(InstitutionRepository repo, IModelService modelServices)
		{
			this._repo = repo;
			this._modelServices = modelServices;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.list = _repo.getAll();

			return Ok(result);
        }

        [HttpGet("{InstitutionName}")]
		public IActionResult GetByName(string InstitutionName)
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.result = _repo.getByName(InstitutionName);

			return Ok(result);
		}

        [HttpGet("Schools")]
		public IActionResult GetAllSchools()
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.list = _repo.getAllSchools();

			return Ok(result);
		}

		[HttpGet("Universities")]
		public IActionResult GetAllUniversities()
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
            result.list = _repo.getAllUniversities();

			return Ok(result);
		}

        [HttpGet("Schools/{CountryName}")]
		public IActionResult GetAllSchoolsByCountryName(string CountryName)
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
			result.list = _repo.getAllSchools(CountryName);

			return Ok(result);
		}

		[HttpGet("Universities/{CountryName}")]
		public IActionResult GetAllUniversitiesByCountryName(string CountryName)
		{
			dynamic result = new ExpandoObject();
			result.status = 1;
			result.list = _repo.getAllUniversities(CountryName);

			return Ok(result);
		}

		[HttpPost("School")]
        public IActionResult AddSchool([FromBody]School s)
		{
			dynamic result = new ExpandoObject();

			if (ModelState.IsValid)
			{
				School s2 = _repo.addSchool(s);
				if (s2 == null)
				{
					result.status = 0;
					result.message = "Verify your informations";
				}
				else
				{
					result.status = 1;
					result.result = s2;
				}
			}
			else
			{
				result.status = 0;
				result.message = _modelServices.GetErrorMessage(ModelState);
			}



			return Ok(result);
		}



        [HttpPost("University")]
		public IActionResult AddUniversity([FromBody]University u)
		{
			dynamic result = new ExpandoObject();

			if (ModelState.IsValid)
			{
				University u2 = _repo.addUniversity(u);
				if (u2 == null)
				{
					result.status = 0;
					result.message = "Verify your informations";
				}
				else
				{
					result.status = 1;
					result.result = u2;
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
