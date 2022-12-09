using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW1.Model
{
    internal class UsersDB
    {
        public List<User> Users { get; set; } = new List<User>()
        {
            new User("Admin", "Admin", "Admin"),
            new User("User", "User", "User"),
            new User("Максим", "Max", "123"),
            new User("Иван", "IvanoBoss", "0000"),
            new User("Балбес", "Babl", "12321"),
        };
        
    }
}
