using IOPSBackend.Models;
using IOPSBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IOPSBackend.Repositories
{
    public class InstitutionRepository
    {
		MysqlDBContext _context;
        CountryRepository _countryRepo;
		public InstitutionRepository(MysqlDBContext context,CountryRepository repo)
		{
			this._context = context;
			this._countryRepo = repo;
		}

        public Institution getByName(string Name)
		{
            return _context.Institutions.Where(k => k.Name == Name).FirstOrDefault();
		}

		public Institution getByNameDetails(string Name)
		{
			return _context.Institutions.Where(k => k.Name == Name)
                           .Include(k => k.Country)
                           .Include(k => k.Students)
						   .FirstOrDefault();
		}

		public bool isExsist(string Name)
		{
			return this.getByName(Name) != null;
		}

        public University addUniversity(University i){
            if(this._countryRepo.isExsist(i.CountryID)){
                if(!isExsist(i.Name)){
                    this._context.Universities.Add(i);
                    _context.SaveChanges();
                    return i;
                }
            }
            return null;
        }


        public School addSchool(School i)
		{
			if (this._countryRepo.isExsist(i.CountryID))
			{
				if (!isExsist(i.Name))
				{
                    this._context.Schools.Add(i);
                    _context.SaveChangesAsync();
					return i;
				}
			}
			return null;
		}

        public List<Institution> getAll(string CountryName=""){
            if(CountryName.Length>0){
                return _context.Institutions.Where(k => k.CountryID == CountryName)
						   .Include(k => k.Country)
						   .Include(k => k.Students)
                               .ToList();
            }
            else {
				return _context.Institutions
						   .Include(k => k.Country)
						   .Include(k => k.Students)
							   .ToList();
            }
        } 

		public List<School> getAllSchools(string CountryName = "")
		{
			if (CountryName.Length > 0)
			{
                return _context.Schools.Where(k => k.CountryID == CountryName)
						   .Include(k => k.Country)
						   .Include(k => k.Students)
							   .ToList();
			}
			else
			{
				return _context.Schools
						   .Include(k => k.Country)
						   .Include(k => k.Students)
							   .ToList();
			}
		}


        public List<University> getAllUniversities(string CountryName = "")
		{
			if (CountryName.Length > 0)
			{
                return _context.Universities.Where(k => k.CountryID == CountryName)
						   .Include(k => k.Country)
						   .Include(k => k.Students)
							   .ToList();
			}
			else
			{
				return _context.Universities
						   .Include(k => k.Country)
						   .Include(k => k.Students)
							   .ToList();
			}
		}



    }
}
