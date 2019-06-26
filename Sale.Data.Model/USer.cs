using System;
namespace Sale.Data.Model
{
    public class User:BaseEntity
    {
        public User()
        {
        }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Fullname { get; set; }
		public string Phone { get; set; }
		public bool IsAuthenticate { get; set; }
	}
}
