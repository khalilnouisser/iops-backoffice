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
    public class ContextController : Controller
    {
		private MysqlDBContext _context;
		private IModelService _modelS;
		public ContextController(IModelService modelS, MysqlDBContext context)
		{
			this._context = context;
			this._modelS = modelS;
		}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Context context){
			dynamic response = new ExpandoObject();
			if (ModelState.IsValid)
			{
				response.status = 1;
                Context dbcon = await _context.Contexts.Where(c => c.NomContext == context.NomContext).FirstOrDefaultAsync();
                if(dbcon == null){
                    await _context.AddAsync(context);
                    await _context.SaveChangesAsync();
					response.status = 1; 
					response.extra = new ExpandoObject();
					response.extra.context = context;
                }
                else {
					response.status = 0;
					response.extra = new ExpandoObject();
					response.extra.context = context;
					response.extra.errorMessage = "context exists";
					return BadRequest(response);
                }
				return Ok(response);
			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.context = context;
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
			}
		}
    }
}
*/