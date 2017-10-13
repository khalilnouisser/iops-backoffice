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
/*
namespace IOPSApi.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private MysqlDBContext _context;
        private IModelService _modelS;
        public AdminController(IModelService modelS, MysqlDBContext context)
        {
            this._context = context;
            this._modelS = modelS;
        }
        [HttpPost("signup")] 
        public async Task<IActionResult> Create([FromBody]Admin admin)
        {
            dynamic response = new ExpandoObject();
            if (ModelState.IsValid)
            {
                response.status = 1;
                admin.DateCreation = DateTime.Now;
                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();
                response.extra = new ExpandoObject();
                response.extra.admin = admin;
                return Ok(response);
            } 
            else
            {
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.admin = admin;
                response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
            } 
        }

		[HttpPost("signin")]
        public async Task<IActionResult> Login([FromBody]FormLogin login)
        {
			dynamic response = new ExpandoObject();
            User admin = await _context.Admins
                                   .Where(u => u.EmailAdress == login.EmailAdress && u.AdminPassword == login.AdminPassword)
                                   .FirstOrDefaultAsync();

            if(admin == null){ 
                response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.EmailAdress = login.EmailAdress;
                response.extra.AdminPassword = login.AdminPassword;
                return Ok(response);
            }
			response.status = 1;
			response.extra = new ExpandoObject();
            response.extra.admin = admin;
            return Ok(response);
		}

    }  
    public class FormLogin {
        public string EmailAdress { get; set; }
        public string AdminPassword { get; set; }
    }  
}
 */