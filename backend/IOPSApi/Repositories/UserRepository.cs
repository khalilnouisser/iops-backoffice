using IOPSBackend.Models;
using IOPSBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using IOPSBackend.Consts;

namespace IOPSBackend.Repositories
{
    public class UserRepository
    {
        MysqlDBContext _context;
        ContestRepository _contestRepo;
        CountryRepository _countryRepo;
        InstitutionRepository _institutionRepo;

		public UserRepository(MysqlDBContext context, ContestRepository repo,CountryRepository crepo,InstitutionRepository instrepo)
        {
            this._context = context;
            this._contestRepo = repo;
            this._countryRepo = crepo;
            this._institutionRepo = instrepo;
        }

        public User getUserByEmail(string Email)
        {
            return this._context.Users.Where(k => k.EmailAddress == Email).FirstOrDefault();
        }

		public User getUserByID(int Id)
		{
            return this._context.Users.Where(k => k.UserId == Id).FirstOrDefault();
		}

        public Admin getAdminBydId(int UserId)
        {
            return this._context.Admins.Where(k => k.UserId == UserId).FirstOrDefault();
        }

        public async Task<SuperAdmin> addSuperAdmin(SuperAdmin a)
        {
            a.InternationalContestNameC = "IOPS";
            a.InternationalContest = _contestRepo.getInternationalContestByEdition(a.InternationalContestEdition);
            if (getUserByEmail(a.EmailAddress) == null && a.InternationalContest != null)
            {
                a.DateAdded = DateTime.UtcNow;
                this._context.SuperAdmins.Add(a);
                await _context.SaveChangesAsync();
                return a;
            }
            else
            {
                return null;
            }
        }


        public async Task<LocalContestAdmin> addLocalContestAdmin(LocalContestAdmin a)
        {
            a.LocalContest = _contestRepo.getLocalContest(a.LocalContestNameC, a.LocalContestEdition);
            if (getUserByEmail(a.EmailAddress) == null && a.LocalContest != null)
            {
                a.DateAdded = DateTime.UtcNow;
                this._context.LocalContestAdmins.Add(a);
                await _context.SaveChangesAsync();
                return a;
            }
            else
            {
                return null;
            }
        }

        public async Task<CountryAdmin> addCountryAdmin(CountryAdmin a)
        {
            a.NationalContest = _contestRepo.getNationalContest(a.NationalContestNameC, a.NationalContestEdition);
            if (getUserByEmail(a.EmailAddress) == null && a.NationalContest != null)
            {
                a.DateAdded = DateTime.UtcNow;
                this._context.CountryAdmins.Add(a);
                await _context.SaveChangesAsync();
                return a;
            }
            else
            {
                return null;
            }
        }

        public async Task<Admin> AdminConnect(string Email, string password)
        {
            return await _context.Admins.Where(k => k.EmailAddress == Email && k.Password == password).FirstOrDefaultAsync();
        }

        public Contestant SignUp(Contestant c){
            c.Institution = _institutionRepo.getByName(c.InstitutionName);
            if(getUserByEmail(c.EmailAddress) == null && _countryRepo.getByName(c.CountryID) !=null &&  c.Institution !=null){
                c.Status = RegistrationStatus.INACTIVE;
                c.RegistrationDate = DateTime.UtcNow;
                _context.Contestants.Add(c);
                _context.SaveChanges();
                return c;
            }
            return null;
        }

        public Contestant ConfirmMail(string hash) {
            Contestant c = _context.Contestants.Where(k => k.c == hash).FirstOrDefault();
            if(c!=null){
                c.Status = RegistrationStatus.WAITING;
                _context.Contestants.Update(c);
                _context.SaveChanges();
                return c;
            }
            return null;
        }

		public Contestant ActiveContestant(int id)
		{
            Contestant c = (Contestant) getUserByID(id);
			if (c != null)
			{
                c.Status = RegistrationStatus.ACTIVE;
				_context.Contestants.Update(c);
				_context.SaveChanges();
                return c;
			}
			return null;
		}

        public Contestant RefuseContestant(int id)
		{
			Contestant c = (Contestant)getUserByID(id);
			if (c != null)
			{
				c.Status = RegistrationStatus.REFUSED;
				_context.Contestants.Update(c);
				_context.SaveChanges();
                return c;
			}
			return null;
		}

		public Contestant BlockContestant(int id)
		{
			Contestant c = (Contestant)getUserByID(id);
			if (c != null)
			{
                c.Status = RegistrationStatus.BLOCKED;
				_context.Contestants.Update(c);
				_context.SaveChanges();
                return c;
			}
			return null;
		}



        public void SetConfirmationHash(Contestant c,string hash){
            c.c = hash;
            _context.Contestants.Update(c);
            _context.SaveChanges();
        }


    }
}
