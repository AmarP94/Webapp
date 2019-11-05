using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSite.db.EntityModels;

namespace WebSite.db.BLL
{
    public class DBBL
    {
        private ApplicationDbContext _applicationDbContext;

        public DBBL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _applicationDbContext.Users.ToList();
        }

        public ApplicationUser SelectUserById(string id)
        {
            return _applicationDbContext.Users.Where(u => u.Id == id).First();
        }

        public void DeleteUser(ApplicationUser u)
        {
            _applicationDbContext.Users.Remove(u);
            _applicationDbContext.SaveChanges();
        }
        public bool AddKalendarskuObavijest(KalendarskaObavijest kalendarskaObavijest)
        {
            if (kalendarskaObavijest != null)
            {
                try
                {
                    _applicationDbContext.KalendarskaObavijests.Add(kalendarskaObavijest);
                    _applicationDbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return false;
        }
        public List<KalendarskaObavijest> GetAllKalendarskeObavijesti()
        {
            try
            {
                return _applicationDbContext.KalendarskaObavijests.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool ObrisiKO(int id)
        {
            var ob = _applicationDbContext.KalendarskaObavijests.Where(x => x.Id == id).FirstOrDefault();

            if (ob != null)
            {
                _applicationDbContext.KalendarskaObavijests.Remove(ob);
                _applicationDbContext.SaveChanges();
                return true;
            }

            return false;
        }

       
    }
}
