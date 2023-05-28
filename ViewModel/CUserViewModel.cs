using Library.Models;

namespace Library.ViewModel
{
    public class CUserViewModel
    {
        private Tuser _user;
        public Tuser user
        {
            get { return _user; }
            set { _user = value; }
        }
        public CUserViewModel() 
        {
            _user = new Tuser();
        }
        public int UserId {
            get { return _user.UserId; }
            set { _user.UserId = value; }
        }
        public int? PhoneNumber {
            get { return _user.PhoneNumber; }
            set { _user.PhoneNumber = value; }
        }
        public string Password {
            get { return _user.Password; }
            set { _user.Password = value; }
        }
        public string UserName {
            get { return _user.UserName; }
            set { _user.UserName = value; }
        }
        public DateTime? RegistrationTime {
            get { return _user.RegistrationTime; }
            set { _user.RegistrationTime = value; }
        }
        public DateTime? LastLoginTime {
            get { return _user.LastLoginTime; }
            set { _user.LastLoginTime = value; }
        }
        public string Privilege {
            get { return _user.Privilege; }
            set { _user.Privilege = value; }
        }

    }
}
