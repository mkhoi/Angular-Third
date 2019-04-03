﻿namespace WebApi.Models
{
    using System.Runtime.Serialization;
    [DataContract(Name="user")]
    public class User
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name ="firstName")]
        public string FirstName { get; set; }
        [DataMember(Name ="lastName")]
        public string LastName { get; set; }
        [DataMember(Name ="userName")]
        public string UserName { get; set; }

        public User() { }
        public User(string firstName, string lastName, string userName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
        }
    }
}