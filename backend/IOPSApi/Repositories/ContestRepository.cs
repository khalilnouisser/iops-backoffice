using IOPSBackend.Models;
using IOPSBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace IOPSBackend.Repositories
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContestRepository
    {
		MysqlDBContext _context;
        CountryRepository _countryRepo;
        public ContestRepository(CountryRepository countryRepo,MysqlDBContext context)
		{
			this._context = context;
            this._countryRepo = countryRepo;
		}

        public LocalContest getLocalContest(string NameC,int Edition){
            return _context.LocalContests.Where(k => k.NameC == NameC && k.Edition == Edition)
						   .Include(k => k.Admins)
						   .Include(k => k.ContestantRegistrations)
									.ThenInclude(k => k.Contestant)
						   .FirstOrDefault();
        }

        public NationalContest getNationalContest(string NameC, int Edition){
            return _context.NationalContests.Where(k => k.NameC == NameC && k.Edition == Edition)
                           .Include(k=>k.Admins)
                           .Include(k=>k.LocalContests)
                                .ThenInclude(k3 => k3.Admins)
						   .Include(k => k.ContestantRegistrations)
									.ThenInclude(k => k.Contestant)
                           .FirstOrDefault();
		}

        public InternationalContest getInternationalContestByEdition(int Edition)
		{
			return _context.InternationalContests.Where(k => k.NameC == "IOPS" && k.Edition == Edition)
                           .Include(k => k.Admins)
                           .Include(k=>k.NationalContests)
                                .ThenInclude(k2=>k2.LocalContests)
                                    .ThenInclude(k3=>k3.Admins)
						   .Include(k => k.ContestantRegistrations)
									.ThenInclude(k => k.Contestant)
						   .FirstOrDefault();
		}

        public async Task<Contest> getFullDetails(string NameC, int Edition){
            return await _context.Contests.Where(k => k.NameC == NameC && k.Edition == Edition)
                                 .Include(k => k.ContestantRegistrations)
                                    .ThenInclude(k => k.Contestant)
                                 .FirstOrDefaultAsync();
        }

        public InternationalContest addNewInternationalContest(int Edition){
            try{
				InternationalContest c = new InternationalContest() { NameC = "IOPS", Edition = Edition };
				this._context.InternationalContests.Add(c);
				this._context.SaveChanges();
				return c; 
            }
            catch{
                return null;
            }

        }

        public NationalContest addNewNationalContest(NationalContest c)
		{
            InternationalContest ic = getInternationalContestByEdition(c.Edition);
            if(ic!=null && getNationalContest(c.NameC,c.Edition) == null && _countryRepo.isExsist(c.CountryName) ){
                c.InternationalContest = ic;
                this._context.NationalContests.Add(c);
				this._context.SaveChanges();
				return c;
            }
            else {
                return null;
            }
		}

        public LocalContest addnewLocalContest(LocalContest c)
		{
            NationalContest nc = null;
            if(c!=null)
            nc = getNationalContest(c.NationalContestNameC, c.NationalContestEdition);
            if (nc != null && getLocalContest(c.NameC, c.NationalContestEdition) == null)
			{
                c.NationalContest = nc;
                c.Edition = c.NationalContestEdition;
                this._context.LocalContests.Add(c);
				this._context.SaveChanges();
				return c;
			}
			else
			{
				return null;
			}
		}




	} 

}
