using Techbuzzers_bank.Data;
using Techbuzzers_bank.Interface;
using Techbuzzers_bank.Models;

namespace Techbuzzers_bank.Repository
{
    public class UserRepository:IUsers
    {
        readonly ApplicationDbContext _db ;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }   

        public List<UserDetails> GetAllUserDetails()
        {
            try
            {
                return _db.userDetails.ToList();
            }
            catch
            {
                throw;
            }
        }

        public UserDetails GetUserDetails(long id)
        {
            try
            {
                UserDetails? user = _db.userDetails.Find(id);
                if (user == null)
                {
                    throw new ArgumentNullException();
                }
                return user;
            }
            catch
            {
                throw;
            }
        }
        public void AddUser(UserDetails user)
        {
            try
            {

                _db.userDetails.Add(user);
                _db.SaveChanges();

            }
            catch
            {
                throw;
            }
        }



        public void UpdateUser(UserDetails user)
        {
            try
            {
                _db.userDetails.Update(user);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public UserDetails DeleteUser(long id)
        {
            try{
                UserDetails? user = _db.userDetails.Find(id);
                if(user == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _db.userDetails.Remove(user);
                    _db.SaveChanges();
                    return user;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(long id)
        {
            return _db.userDetails.Any(e=>e.Id == id);
        }
        public UserDetails GetUser(long PhoneNumber,int Pin)
        {
            UserDetails user= _db.userDetails.FirstOrDefault(e=>e.PhoneNumber== PhoneNumber && e.Pin==Pin);
            if(user == null)
            {
                throw new Exception("Invalid Credentials");
            }
            else
            {
                return user;
            }
        }
    }
}
