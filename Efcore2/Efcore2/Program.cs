using Efcore2.Context;
using Efcore2.Models;

namespace Efcore2
{
    internal class Program
    {
       
        public class UserNotFoundException : Exception
        {

        }
        public class ProductNotFoundException : Exception
        { }     
        static void Main(string[] args)
        {
            List<Users> users = [];
            Console.WriteLine("""
                1. Register
                2. Login
                """);
            int digit = int.Parse(Console.ReadLine());
            switch (digit)
            {
                case 1:
                    Register();
                    break;
                case 2:

                    Login();
                    int digitt = int.Parse(Console.ReadLine());
                    switch (digitt)
                    {   case 0: 
                            ShowMenu();
                            break;
                        case 1:
                            LooksProducts();
                            break;
                        case 2:
                            BasketsProducts();
                            break;
                        case 3:
                            Login();
                            break;
                    }
                    break;

            }
        }
        public static void Register()
        {

            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("SurName:");
            string surName = Console.ReadLine();
            Console.Write("UserName:");
            string userName = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            Users newuser = new Users()
            {
                Name = name,
                SurName = surName,
                UserName = userName,
                Password = password
            };

            using (AppDbcontext sql = new AppDbcontext())
            {
                sql.users.Add(newuser);
                sql.SaveChanges();
            }

        }
        public static void Login()
        {

            List<Users> users = [];
            Console.Write("UserName: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var userpassword = Console.ReadLine();

            using (AppDbcontext sql = new AppDbcontext())
            {

                var user = sql.users.Where(u => u.UserName == username && u.Password == userpassword).FirstOrDefault();

                if (user == null)
                {
                    throw new UserNotFoundException();
                }

                else
                {
                    ShowMenu();
                }
            }
        }
        public static void ShowMenu()
        {
            Console.WriteLine("""
                1. Mehsullara bax.
                2. Sebete bax.
                3. Hesabdan cıx.
                """);
            using (AppDbcontext sql = new AppDbcontext()) {
                Console.WriteLine("Mehsullar:");
                foreach (var product in sql.products)
                {
                    Console.WriteLine($"Mehsulun Id-si-{product.Id},Mehsulun Adi-{product.Name},Mehsulun Qiymeti-{product.Price}");
                }
            }
        }
        public static void LooksProducts()
        {



            using (AppDbcontext sql = new AppDbcontext())
            {
                Console.WriteLine("Mehsul ID-sini daxil edin:");
                int productId = int.Parse(Console.ReadLine());
                var product = sql.products.Find(productId);
                if (product != null)
                {

                    Console.WriteLine($"Mehsul tapildi: {product.Name} - {product.Price} AZN");

                    sql.baskets.Add(new Baskets
                    {
                       
                        ProductId = product.Id

                    });
                    sql.SaveChanges();
                    Console.WriteLine("Mehsul sebete elave edildi!");
                }
                else
                {
                    throw new ProductNotFoundException();
                }
            }

        }
        public static void BasketsProducts()
        {
            using (AppDbcontext sql = new AppDbcontext())
            {
                Console.WriteLine("Sebet:");
                foreach (var basket in sql.baskets)
                {
                    Console.WriteLine($"Mehsulun Id-si-{basket.Id},Mehsulun Adi-{basket.UserId},Mehsulun Qiymeti-{basket.ProductId}");
                }
                using (AppDbcontext sqll = new AppDbcontext())
                {
                    Console.WriteLine("Mehsullar:");
                    foreach (var product in sqll.products)
                    {
                        Console.WriteLine($"Mehsulun Id-si-{product.Id},Mehsulun Adi-{product.Name},Mehsulun Qiymeti-{product.Price}");
                    }
                }
                using (AppDbcontext sqll = new AppDbcontext())
                {
                    int num =int .Parse(Console.ReadLine());    
                    var data = sql.baskets.Find(num);
                    if (data != null)
                    {
                        sql.baskets.Remove(data);
                        sql.SaveChanges();
                    }
                    else 
                    {
                        throw new ProductNotFoundException();
                    }
                }

            }
        }
        
    }
}

