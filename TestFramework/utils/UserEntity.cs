using System;
using System.IO;
using Newtonsoft.Json;

namespace TestFramework.utils
{
    public class UserEntity
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public UserEntity(string email, string firstname, string lastname, string street, string city, string state, string zipcode, string phone)
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Street = street;
            City = city;
            Phone = phone;
            Zipcode = zipcode;
            State = state;
        }

        public UserEntity()
        {
        }

        public static UserEntity getUser(string dataFile)
        {
            return JsonConvert.DeserializeObject<UserEntity>(File.ReadAllText(dataFile));
        }
    }
}
