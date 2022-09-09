using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();

            //BrandManagerTest();

            //ColorManagerTest();

            //UserManagerTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rentalAdd = new Rental();

            Console.WriteLine("Aracın Kodunu Giriniz.");
            rentalAdd.CarId =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Müşteri Kodunu Giriniz.");
            rentalAdd.CustomerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Araç Kiralama Tarihi Giriniz.");
            rentalAdd.RentDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Araç Teslim Tarihi Giriniz. (Boş Bırakılabilir.)");
            string returnDate = Console.ReadLine();

            rentalAdd.ReturnDate = returnDate == "" ? rentalAdd.ReturnDate = null : rentalAdd.ReturnDate = DateTime.Parse(returnDate);


            var result = rentalManager.Add(rentalAdd);
            Console.WriteLine(result.Message);

            

        }

        private static void UserManagerTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            User userAdd = new User();
            Console.WriteLine("Kişi Adını Giriniz.");
            userAdd.FirstName = Console.ReadLine();
            Console.WriteLine("Kişi Soyadını Giriniz.");
            userAdd.LastName = Console.ReadLine();
            Console.WriteLine("Kişi Mail Adresini Giriniz.");
            userAdd.Email = Console.ReadLine();
            Console.WriteLine("Kişi Şifresini Giriniz.");
            userAdd.Password = Console.ReadLine();
            userManager.Add(userAdd);



            var result = userManager.GetAll();
            foreach (var Users in result.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", Users.Id, Users.FirstName, Users.LastName, Users.Email, Users.Password);
            }

            Console.WriteLine("Kullanıcı Kodunu Giriniz.");
            int Id = Convert.ToInt32(Console.ReadLine());
            var result2 = userManager.GetById(Id).Data;
            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", result2.Id, result2.FirstName, result2.LastName, result2.Email, result2.Password);
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Brand brand = new Brand();
            //Console.WriteLine("Marka Adı Giriniz");
            //brand.Name = Console.ReadLine();
            //brandManager.Add(brand);
            var result3 = brandManager.GetAll();
            foreach (var brands in result3.Data)
            {
                Console.WriteLine("{0} - {1}", brands.Id, brands.Name);
            }

            Console.WriteLine("Marka Kodu Giriniz");
            int Id = Convert.ToInt32(Console.ReadLine());
            var result = brandManager.GetById(Id);
            Console.WriteLine("{0} - {1}", result.Data.Id, result.Data.Name);
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
            Console.WriteLine("Renk Adını Giriniz");
            color.Name = Console.ReadLine();
            colorManager.Add(color);


            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1}", colors.Id, colors.Name);
            }

            Console.WriteLine("Renk Kodu Giriniz.");
            int Id = Convert.ToInt32(Console.ReadLine());
            var result = colorManager.GetById(Id);
            Console.WriteLine("{0} - {1} ", result.Data.Id, result.Data.Name);

            Console.WriteLine("Renk Kodunu Giriniz");
            int Id2 = Convert.ToInt32(Console.ReadLine());
            var result2 = colorManager.GetById(Id2);
            Console.WriteLine("Renk Adını Giriniz");
            string name2 = Console.ReadLine();
            result2.Data.Name = name2;
            colorManager.Update(result2.Data);
        }

        private static void CarManagerTest()
        {

            

            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();


            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}",item.Id, item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }


            Console.WriteLine("Aracın Adını Giriniz");
            car.Name = Console.ReadLine();

            Console.WriteLine("Aracın Marka Kodunu Giriniz");
            car.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Aracın Renk Kodunu Giriniz");
            car.ColorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Aracın Model Yılını Giriniz");
            car.ModelYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Aracın Günlük Fiyatını Giriniz");
            car.DailyPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Aracın Açıklamasını Giriniz");
            car.Description = Console.ReadLine();

            carManager.Add(car);


            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", cars.Name, cars.Id, cars.BrandId, cars.ColorId, cars.ModelYear, cars.DailyPrice, cars.Description);
            }

            Console.WriteLine("Aracın Id'sini Giriniz.");
            int Id = Convert.ToInt32(Console.ReadLine());
            var result = carManager.GetById(Id);
            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", result.Data.Name, result.Data.Id, result.Data.BrandId, result.Data.ColorId, result.Data.ModelYear, result.Data.DailyPrice, result.Data.Description);
        }
    }
}
