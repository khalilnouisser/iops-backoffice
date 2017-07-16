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
    public class ContinentController : Controller
    {
		private MysqlDBContext _context;
		private IModelService _modelS;

		public ContinentController(IModelService modelS, MysqlDBContext context)
		{
			this._context = context;
			this._modelS = modelS;
        }

        [HttpDelete("{ContinentName}")]
        public async Task Delete(string ContinentName)
        {
			dynamic response = new ExpandoObject();
            Continent c = await _context.Continent.Where(k => k.ContinentID == ContinentName).FirstOrDefaultAsync();
            if(c!=null){
                _context.Continent.Remove(c);
                await _context.SaveChangesAsync();
			}           
        }


        [HttpPut("{LastContinentName}")]
        public async Task<IActionResult> Update([FromBody]Continent Continent, string LastContinentName)
		{
            
			dynamic response = new ExpandoObject();
            Continent c = await _context.Continent.Where(k => k.ContinentID == Continent.ContinentID).FirstOrDefaultAsync();
			if (c != null)
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.errorMessage = "Continent "+Continent.ContinentID +" exsist";
                response.extra.ContinentName = Continent.ContinentID;
				response.extra.LastContinentName = LastContinentName;

				return Ok(response);
			} 

            else {
				Continent c2 = await _context.Continent.Where(k => k.ContinentID == LastContinentName).Include(k => k.countries).FirstOrDefaultAsync();
				if (c2 == null)
				{
					response.status = 0;
					response.extra = new ExpandoObject();
					response.extra.errorMessage = "Continent "+LastContinentName+" doesn't exist";
					response.extra.ContinentName = Continent.ContinentID;
					response.extra.LastContinentName = LastContinentName;
					return Ok(response);
				}
                else {
                    foreach(var country in c2.countries){
                        country.ContinentID = Continent.ContinentID;
                    }
                    await _context.Continent.AddAsync(Continent);
                    await _context.SaveChangesAsync();
					_context.Continent.Remove(c2);
					await _context.SaveChangesAsync();

					response.status = 1;
					response.extra = new ExpandoObject();
                    response.extra.Continent = c;
					return Ok(response);
				}
			}
		}


		[HttpPost]
        public async Task<IActionResult> Create([FromBody]Continent continent){
			dynamic response = new ExpandoObject();
			if (ModelState.IsValid)
			{
				response.status = 1;
				response.extra = new ExpandoObject();
				try
				{
					await _context.Continent.AddAsync(continent);
					await _context.SaveChangesAsync();
				}
				catch (Exception)
				{
					response.status = 0;
					response.extra.errorMessage = "Continent exsist";
					return Ok(response);
				}
				response.extra.continent = continent;

				return Ok(response);
			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.continent = continent;
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
			}
        }

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			dynamic response = new ExpandoObject();
			response.status = 1;
			response.extra = new ExpandoObject();
            List<Continent> listC = await _context.Continent
                .Include(k=>k.countries)
                .ToListAsync();
            response.extra.continents = listC.Select(k => new { continentID = k.ContinentID , pays = k.countries });
			
			return Ok(response);
		}

		[HttpGet("mapDisplay")]
		public async Task<IActionResult> GetM()
		{
			List<Continent> listContient =  await _context.Continent
				.Include(k => k.countries)
				.ToListAsync();

            Dictionary<string,Dictionary<string, Country>> map = new Dictionary<string, Dictionary<string, Country>>();
            foreach(Continent c in listContient){
                Dictionary<string, Country> listD = new Dictionary<string, Country>();
                foreach(Country coun in c.countries){
                    listD.Add(coun.CountryID,coun);
                }
                map.Add(c.ContinentID,listD);
            }
            return Ok(map);
		}

    }
}
