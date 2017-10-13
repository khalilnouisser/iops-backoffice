using IOPSBackend.Models;
using IOPSBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IOPSBackend.Repositories
{
    public class CountryRepository
    {
		MysqlDBContext _context;
        ContinentRepository _contientRepo;
		public CountryRepository(MysqlDBContext context,ContinentRepository repo)
		{
			this._context = context;
            this._contientRepo = repo;
		}
         
		public Country getByName(string Name)
		{
            if(this._context.Countries.Count()>0)
            return _context.Countries.Where(k => k.CountryName == Name).FirstOrDefault();
            return null;
		}

		public Country getByNameDetails(string Name)
		{
            return _context.Countries.Where(k => k.CountryName == Name)
                           .Include(k => k.Continent)
                           .Include(k=>k.Institutions)
                           .FirstOrDefault();
		}

        public List<Country> getListCountries(string ContinentName=""){
            if(ContinentName.Length>0)
                return _context.Countries.Where(k=>k.Continent.ContinentName==ContinentName)
						   .Include(k => k.Continent)
						   .Include(k => k.Institutions)
						   .ToList();
            else
				return _context.Countries
							   .Include(k => k.Continent)
							   .Include(k => k.Institutions)
	                           .ToList();
        }

		public bool isExsist(string Name)
		{
			return this.getByName(Name) != null;
		}


        public Country add(Country c)
		{
            if (this.isExsist(c.CountryName))
			{
				return null;
			}
			else
			{
                if(!_contientRepo.isExsist(c.ContinentID)){
                    c.Continent = _contientRepo.add(c.ContinentID);
                    _context.SaveChangesAsync();
                }
                _context.Countries.Add(c);
				_context.SaveChangesAsync();
				return c;
			}
		} 
	}
}
