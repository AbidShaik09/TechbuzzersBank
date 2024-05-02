using Techbuzzers_bank.Models;

namespace Techbuzzers_bank.Interface
{
    public interface IUsers
    {
        public List<UserDetails> GetAllUserDetails();
        public UserDetails GetUserDetails(long id);
        public void AddUser(UserDetails userDetails);

        public UserDetails GetUser(long PhoneNumber, int Pin);
        public void UpdateUser(UserDetails userDetails);
        public UserDetails DeleteUser(long id);
        public bool CheckUser(long id);
    }
}
