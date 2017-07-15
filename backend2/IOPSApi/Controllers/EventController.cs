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
	[Route("api")]
	public class EventController : Controller
	{
		private MysqlDBContext _context;
		private IModelService _modelS;
		public EventController(IModelService modelS, MysqlDBContext context)
		{
			this._context = context;
			this._modelS = modelS;
		}

		[HttpPost("Event/{countryID}")]
        public async Task<IActionResult> PostNew([FromBody]Event e, string countryID = "")
		{
			e.DateEvent = DateTime.Now;

			dynamic response = new ExpandoObject();
			if (ModelState.IsValid)
			{
				var country = await _context.Countries.Where(k => k.CountryID == countryID).FirstOrDefaultAsync();
				if (country == null)
				{
					e.CountryID = "";
				}
                e.CountryID = countryID;
				response.status = 1;
                await _context.Events.AddAsync(e);
				await _context.SaveChangesAsync();
				response.status = 1;
				response.extra = new ExpandoObject();
				response.extra.e = e;

				return Ok(response);
			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
			}
		}

		[HttpPost("Event")]
		public async Task<IActionResult> PostNew([FromBody]Event e)
		{
            string countryID = "";
			e.DateEvent = DateTime.Now;

			dynamic response = new ExpandoObject();
			if (ModelState.IsValid)
			{
				var country = await _context.Countries.Where(k => k.CountryID == countryID).FirstOrDefaultAsync();
				if (country == null)
				{
					e.CountryID = "";
				}
				response.status = 1;
				await _context.Events.AddAsync(e);
				await _context.SaveChangesAsync();
				response.status = 1;
				response.extra = new ExpandoObject();
				response.extra.e = e;

				return Ok(response);
			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
			}
		}

		[HttpGet("Event/{countryID}")]
		public async Task<IActionResult> GetAllInCountry(string countryID = "")
		{

			dynamic response = new ExpandoObject();

			var country = await _context.Countries.Where(k => k.CountryID == countryID).FirstOrDefaultAsync();
			if (country == null)
			{
				countryID = "";
			}
			response.status = 1;
			response.extra = new ExpandoObject();
            response.extra.events = await _context.Events.Where(k => k.CountryID == countryID).ToListAsync();
			return Ok(response); 

		}

		[HttpGet("Event")]
		public async Task<IActionResult> GetAll()
		{
            string countryID = "";
			dynamic response = new ExpandoObject();

			var country = await _context.Countries.Where(k => k.CountryID == countryID).FirstOrDefaultAsync();
			if (country == null)
			{
				countryID = "";
			}
			response.status = 1;
			response.extra = new ExpandoObject();
			response.extra.events = await _context.Events.Where(k => k.CountryID == countryID).ToListAsync();
			return Ok(response);

		}
    }
}
