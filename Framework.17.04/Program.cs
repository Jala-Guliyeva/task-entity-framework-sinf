using Framework._17._04.DAL;
using Framework._17._04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework._17._04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AddCourse();
            // GetAllCourse();
            //UpdateCourse(1);
            DeleteCourse(2);
        }

         static void AddCourse()
        {

            Course course = new Course
            {
                Name = "Code1",
                Description = "Test1",
                Price = 600
            };
            using (AppDbContext dbContext=new AppDbContext())
            {
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
            }
            Console.WriteLine($"{course.Name} created");


        }

        static void GetAllCourse()
        {

            using (AppDbContext dbContext = new AppDbContext())
            {
                List<Course> courses = dbContext.Courses.ToList();
                Console.WriteLine($"Course list:");
                foreach (var item in courses)
                {
                    Console.WriteLine($"{item.Name} {item.Description} {item.Price}");
                }
            }
            


        }

        static void UpdateCourse(int? id)
        {
            if (id==null)
            {
                Console.WriteLine("id null ola bilmez");
                return;
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Course course=dbContext.Courses.FirstOrDefault(c => c.Id==id);
                if (course==null)
                {
                    Console.WriteLine("course tapilmadi");
                    return;
                }
                course.Name = "Code3";
                course.Description = "Test3";
                course.Price = 400;
                dbContext.SaveChanges();
                Console.WriteLine($"{course.Name} changed");
            }
        }

        static void DeleteCourse(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("id null ola bilmez");
                return;
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Course course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
                if (course == null)
                {
                    Console.WriteLine("course tapilmadi");
                    return;
                }
               dbContext.Courses.Remove(course);
                dbContext.SaveChanges();
                Console.WriteLine($"{course.Name} removed");
            }
        }
    }
}
