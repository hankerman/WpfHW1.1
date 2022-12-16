using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW1.Model
{

    internal class UsersDB
    {
        private static UsersDB _context;
        public static UsersDB Context => _context ?? (_context = new UsersDB());
        
        private UsersDB()
        {
            Orders = new ObservableCollection<Order>()
            {
            new Order(){Id = 1, Client = "Вася Васечкин",Date = new DateTime(2022,12,18),
                Products=new ObservableCollection<OrderProduct>(){
                    new OrderProduct(){Product = Products.First(x=>x.ID == 1), Quantity = 2},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 3), Quantity = 3},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 5), Quantity = 4},
                } },
            new Order(){Id = 2, Client = "Петя Балбесов",Date = new DateTime(2022,12,19),
                Products=new ObservableCollection<OrderProduct>(){
                    new OrderProduct(){Product = Products.First(x=>x.ID == 2), Quantity = 2},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 4), Quantity = 2},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 6), Quantity = 2},
                } },
            new Order(){Id = 3, Client = "Оля Воронцовская",Date = new DateTime(2022,12,20),
                Products=new ObservableCollection<OrderProduct>(){
                    new OrderProduct(){Product = Products.First(x=>x.ID == 1), Quantity = 5},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 2), Quantity = 3},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 3), Quantity = 6},
                } },
            new Order(){Id = 4, Client = "Коля Воронин",Date = new DateTime(2022,12,21),
                Products=new ObservableCollection<OrderProduct>(){
                    new OrderProduct(){Product = Products.First(x=>x.ID == 1), Quantity = 5},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 4), Quantity = 3},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 3), Quantity = 6},
                } },
            new Order(){Id = 5, Client = "Валя Селезнева",Date = new DateTime(2022,12,22),
                Products=new ObservableCollection<OrderProduct>(){
                    new OrderProduct(){Product = Products.First(x=>x.ID == 6), Quantity = 5},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 2), Quantity = 3},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 3), Quantity = 6},
                } },
            new Order(){Id = 6, Client = "Тот кого нельзя называть",Date = new DateTime(2022,12,23),
                Products=new ObservableCollection<OrderProduct>(){
                    new OrderProduct(){Product = Products.First(x=>x.ID == 1), Quantity = 5},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 2), Quantity = 3},
                    new OrderProduct(){Product = Products.First(x=>x.ID == 3), Quantity = 6},
                } },

            };
        }
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User("Admin", "Admin", "Admin"),
            new User("User", "User", "User"),
            new User("Максим", "Max", "123"),
            new User("Иван", "IvanoBoss", "0000"),
            new User("Балбес", "Babl", "12321"),
        };
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>()
        {
            new Product(){ID = 1, Name = "Конфета шоколадная", Price = 100M},
            new Product(){ID = 2, Name = "Леденец \"Петушок\"", Price = 50M},
            new Product(){ID = 3, Name = "Шарлотка", Price = 200M},
            new Product(){ID = 4, Name = "Пирожок с капустой", Price = 50M},
            new Product(){ID = 5, Name = "Торт \"Чародейка\"", Price = 350M},
            new Product(){ID = 6, Name = "Глинтвейн", Price = 150M},
        };
        public ObservableCollection<Order> Orders { get; set; } 
    }
}
