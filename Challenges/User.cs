using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Gender { get; set; }

        public User(string name, int age, string Job, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Job = Job;
            Gender = gender;

        }

        public void InsertUsers()
        {
            User user1 = new User("Tiago", 33, "developer", "M");
            User user2 = new User("Joici", 34, "manager", "F");
            User user3 = new User("Nicolas", 31, "developer", "M");
            User user4 = new User("Maria", 35, "tester", "F");
        }
    }
}
