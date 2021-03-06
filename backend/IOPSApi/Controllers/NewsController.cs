﻿using System;
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
    public class NewsController : Controller
    {
		private MysqlDBContext _context;
		private IModelService _modelS;

		public NewsController(IModelService modelS, MysqlDBContext context)
		{
			this._context = context;
			this._modelS = modelS;
		}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]News news){
			dynamic response = new ExpandoObject();
			if (ModelState.IsValid)
			{
				response.status = 1;
                news.DatePub = DateTime.Now;
				await _context.News.AddAsync(news);
				await _context.SaveChangesAsync();
				response.extra = new ExpandoObject();
				response.extra.news = news;
				return Ok(response);
			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.news = news;
				response.extra.errorMessage = _modelS.GetErrorMessage(ModelState);
				return BadRequest(response);
			}
		} 

        [HttpGet]
		public async Task<IActionResult> GetLimited()
		{
			dynamic response = new ExpandoObject();
				response.status = 1;
				response.extra = new ExpandoObject();
                List<News> listN = await _context.News.OrderByDescending(k => k.DatePub).ToListAsync();
            if(listN.Count()<4){
				response.extra.news = listN;

			}
            else {
				response.extra.news = listN.GetRange(0, 4);

			}
				return Ok(response);
		}

        [HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			dynamic response = new ExpandoObject();
			response.status = 1;
			response.extra = new ExpandoObject();
            List<News> listN = await _context.News.OrderByDescending(k=>k.DatePub).ToListAsync();
			response.extra.news = listN;
			return Ok(response);
		}

        [HttpGet("{NewsId}")]
		public async Task<IActionResult> GetNews(int NewsId)
		{
            Console.WriteLine("NewsId : "+NewsId);
			dynamic response = new ExpandoObject();
			News c = await _context.News.Where(k => k.NewsID == NewsId).FirstOrDefaultAsync();
			if (c != null) {
				response.status = 1;
				response.extra = new ExpandoObject();
                response.extra.news = c;

			}
            else {
				response.status = 0;
				response.extra = new ExpandoObject();
                response.extra.NewsId = NewsId;
				response.extra.errorMessage = "news not found";

			}
            return Ok(response);
		}

        [HttpPut("{NewsId}")]
        public async Task<IActionResult> updateNews(int NewsId,[FromBody] News news)
		{
			Console.WriteLine("NewsId : " + NewsId);
			dynamic response = new ExpandoObject();
			News c = await _context.News.Where(k => k.NewsID == NewsId).FirstOrDefaultAsync();
            if (c != null && ModelState.IsValid)
			{
                c.PhotoURL = news.PhotoURL;
                c.Text = news.Text;
                c.Title = news.Title;
                this._context.Update(c);
                await this._context.SaveChangesAsync();
				response.status = 1;
				response.extra = new ExpandoObject();
				response.extra.news = c;
			}
			else
			{
				response.status = 0;
				response.extra = new ExpandoObject();
				response.extra.NewsId = NewsId;
                response.extra.errorMessage = "";
                if(!ModelState.IsValid){
                    response.extra.errorMessage += _modelS.GetErrorMessage(ModelState);
				}
                if (c == null)
				response.extra.errorMessage += " news not found";
			}
			return Ok(response);
		}

		[HttpDelete("{NewsId}")]
		public async Task Delete(int NewsId)
		{
			dynamic response = new ExpandoObject();
            News c = await _context.News.Where(k => k.NewsID == NewsId).FirstOrDefaultAsync();
			if (c != null)
			{
                _context.News.Remove(c);
				await _context.SaveChangesAsync();
			}
		}

	}
}
