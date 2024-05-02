using Techbuzzers_bank.Models;

namespace Techbuzzers_bank.Interface
{
    public interface IUsers
    {
        public List<UserDetails> GetAllUserDetails();
        public UserDetails GetUserDetails(string id);
        public void AddUser(UserDetails userDetails);

        public UserDetails GetUser(long PhoneNumber, int Pin);
        public void UpdateUser(UserDetails userDetails);
        public UserDetails DeleteUser(string id);
        public bool CheckUser(string id);
    }
}
