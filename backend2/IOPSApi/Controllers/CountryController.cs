using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IOPSApi.Models;
using IOPSApi.Services;
using IOPSApi.Data;
using System.Dynamic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOPSApi.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
		private MysqlDBContext _context;
		private IModelService _modelS;
		public CountryController(IModelService modelS, MysqlDBContext context)
		{
			this._context = context;
			this._modelS = modelS;
		}
        [HttpPost]
		public async Task<IActionResult> Create([FromBody]Country country)
		{
			dynamic response = new ExpandoObject();
			if (ModelState.IsValid)
			{
				response.status = 1;
				response.extra = new ExpandoObject();
				response.extra.country = country;
                Continent c = await _context.Continent.Where(l => l.ContinentID == country.ContinentID).FirstOrDefaultAsync();
                if(c==null){
                    await _context.Continent.AddAsync(new Continent(){ContinentID=country.ContinentID});
					await _context.SaveChangesAsync();
				}
                try{
                    country.Continent = c;
					await _context.Countries.AddAsync(country);
					await _context.SaveChangesAsync();
                }
                catch(Exception){ 
					response.status = 0;
                    response.extra.message = "country exsist";
                    return BadRequest(response);
				} 
				return Ok(response);
			}
			else 
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.country = country;
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
			}
		}

        [HttpGet("{id}")]
		public async Task<IActionResult> FindById(string id)
        {
			dynamic response = new ExpandoObject();
            Country c = await _context.Countries.Where(l => l.CountryID == id).FirstOrDefaultAsync();
			if (c == null)
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.message = "country not found";
				response.extra.id = id;
				return BadRequest(response);
			}
            else
			{
				response.status = 1;
				response.extra = new ExpandoObject();
				response.extra.pays = c;
                return BadRequest(response);
			}
		}

	}
}
