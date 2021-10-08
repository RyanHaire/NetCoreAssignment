using System.Collections.Generic;
namespace AssignmentOne.Models
{
    public class Repository
    {
        private static List<User> users = new List<User>();
        public static IEnumerable<User> Users => users;
        public static void AddUser(User user)
        {
            users.Add(user);
        }
    }
}