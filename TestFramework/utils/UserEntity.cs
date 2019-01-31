using System;
using System.IO;
using Newtonsoft.Json;

namespace TestFramework.utils
{
    public class UserEntity
    {
        string firstname;
        string lastname;
        string street;
        string city;
        string phone;
        string zipcode;
        string state;

        public UserEntity(string firstname, string lastname, string street, string city,
                       string phone, string zipcode, string state)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.street = street;
            this.city = city;
            this.phone = phone;
            this.zipcode = zipcode;
            this.state = state;
        }

        public UserEntity()
        {
        }

        public static UserEntity getUser(string dataFile)
        {
            return JsonConvert.DeserializeObject<UserEntity>(File.ReadAllText(dataFile));
        }

        public string getFirstname() { return firstname; }
        public void setFirstname(string firstname) { this.firstname = firstname; }

        public string getLastname() { return lastname; }
        public void setLastname(string lastname) { this.lastname = lastname; }

        public string getStreet() { return street; }
        public void setStreet(string street) { this.street = street; }

        public string getCity() { return city; }
        public void setCity(string city) { this.city = city; }

        public string getPhone() { return phone; }
        public void setPhone(string phone) { this.phone = phone; }

        public string getZipcode() { return zipcode; }
        public void setZipcode(string zipcode) { this.zipcode = zipcode; }

        public string getState() { return state; }
        public void setState(string state) { this.state = state; }
    }
}
