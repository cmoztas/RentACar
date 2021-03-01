using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetAllByModelYear(2000).Data)
            {
                Console.WriteLine($"{item.Id}) {item.Model}");
            }
        }
    }
}