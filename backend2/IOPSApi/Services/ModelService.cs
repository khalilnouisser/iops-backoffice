using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
namespace IOPSApi.Services
{
    public class ModelService : IModelService
    {
        public string GetErrorMessage(ModelStateDictionary ModelState)
        { 
			return string.Join(" , ", ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage));

		}
    }
}
