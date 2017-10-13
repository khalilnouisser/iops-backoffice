using IOPSBackend.Models;
using IOPSBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace IOPSBackend.Repositories
{
    public class ContinentRepository
    {
        MysqlDBContext _context;
        public ContinentRepository(MysqlDBContext context)
        {
            this._context = context;
        }

        public Continent getByName(string Name){
            return _context.Continents.Where(k => k.ContinentName == Name).FirstOrDefault();
        }

		public Continent getByNameDetails(string Name)
		{
			return _context.Continents.Where(k => k.ContinentName == Name).Include(k=>k.Countries).FirstOrDefault();
		}

        public bool isExsist(string Name){
            Continent c = this.getByName(Name);
            return  c != null;
        }

        public List<Continent> getList(){
            return _context.Continents.Include(k => k.Countries).Include(k => k.Countries).ToList();
        } 

		public Continent add(string Name){
            Console.WriteLine("Name : {0}",Name);
            Continent c = getByName(Name);
            if(c!= null)
            Console.WriteLine("Name : {0}", c.ContinentName);
			if(this.isExsist(Name)){
                return null;
            }
            else {
                _context.Continents.Add(new Continent(){ContinentName=Name});
                _context.SaveChanges();
                return getByName(Name);
            }
        } 
    }
}
