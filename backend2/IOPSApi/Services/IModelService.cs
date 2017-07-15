using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
namespace IOPSApi.Services
{
    public interface IModelService
    {
        string GetErrorMessage(ModelStateDictionary ModelState);
	}
}
