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
    public class MessageController : Controller
    {
        private MysqlDBContext _context;
        private IModelService _modelS;
        public MessageController(IModelService modelS, MysqlDBContext context)
        {
            this._context = context;
            this._modelS = modelS;
        }
        
        [HttpPost("contactUS")]

        public async Task<IActionResult> PostNew([FromBody]Messages m)
        {
            string countryID = "";

            m.DateMessage = DateTime.Now;
             
            dynamic response = new ExpandoObject();
            if (ModelState.IsValid)
            {
                var country = await _context.Countries.Where(k => k.CountryID == countryID).FirstOrDefaultAsync();
                if(country==null){
                    m.CountryID = "";
                } 
                response.status = 1;
                await _context.Messages.AddAsync(m);
                await _context.SaveChangesAsync();
                response.status = 1;
                response.extra = new ExpandoObject();
                response.extra.message = m;

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

        [HttpPost("contactUS/{countryID}")]

        public async Task<IActionResult> PostNewInCountry([FromBody]Messages m, string countryID)
        {
            m.DateMessage = DateTime.Now;

            dynamic response = new ExpandoObject();
            if (ModelState.IsValid)
            {
                var country = await _context.Countries
                                            .Where(k => k.CountryID == countryID)
                                            .Include(k=>k.Continent)
                                            .FirstOrDefaultAsync();
                if (country == null)
                {
                    m.CountryID = "";
                } 
                m.CountryID = countryID;
                response.status = 1;
                await _context.Messages.AddAsync(m);
                await _context.SaveChangesAsync();
                response.status = 1;
                response.extra = new ExpandoObject();
                response.extra.message = m;

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

        [HttpGet("contactUS/{countryID}")]
        public async Task<IActionResult> GetAllInCountry( string countryID = "")
        {

            dynamic response = new ExpandoObject();

                var country = await _context.Countries.Where(k => k.CountryID == countryID).FirstOrDefaultAsync();
                if (country == null)
                {
                    countryID = "";
                }
                response.status = 1;
                response.extra = new ExpandoObject();
                response.extra.messages = await _context.Messages.Where(k=>k.CountryID==countryID).ToListAsync();
                return Ok(response);
        
        }

        [HttpGet("contactUS")]
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
            response.extra.messages = await _context.Messages.Where(k => k.CountryID == countryID).ToListAsync();
            return Ok(response);
             
        }

    }
}
