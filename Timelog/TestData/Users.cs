using System.Collections;
using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.TestData
{
    public static class Users
    {
        public static List<User> IMetaUsers { get; }

        static Users()
        {
            if (IMetaUsers != null )
                return;
            IMetaUsers = new List<User>()
            {
                new User() {Name = "Jonathan"},
                new User() {Name = "Steve"},
                new User() {Name = "Phil"},
                new User() {Name = "Jason"},
                new User() {Name = "Mark N"},
                new User() {Name = "David WL"},
                new User() {Name = "David G"},
                new User() {Name = "Nia"},
                new User() {Name = "Simon"},
                new User() {Name = "James W"},
                new User() {Name = "James A"},
                new User() {Name = "Adrian"},
                new User() {Name = "Mark G"},
                new User() {Name = "Julie"},
                new User() {Name = "Julia"},
                new User() {Name = "Nick"},
                new User() {Name = "Ben M"},
                new User() {Name = "Ben T"},
                new User() {Name = " Michael E"}
            };

        }       
    }
}