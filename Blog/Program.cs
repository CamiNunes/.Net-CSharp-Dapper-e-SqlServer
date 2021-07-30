using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=CAMILANUNES-DES\SQLEXPRESS; Database=Cursos; User ID=sa; Password=8uygfe345";
                                                
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            
            ReadUsers(connection);
            ReadRoles(connection);
            ReadTags(connection);
            ReadCategories(connection);
            
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.Get();

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Usuários:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);  
            }
            Console.WriteLine("------------------------------------");
        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Get();

            Console.WriteLine("Roles:");
            foreach (var role in roles)
            {
                Console.WriteLine(role.Name);   
            }
            Console.WriteLine("------------------------------------");
        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.Get();

            Console.WriteLine("Tags:");
            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name);   
            }
            Console.WriteLine("------------------------------------");
        }
        public static void ReadCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var categories = repository.Get();

            Console.WriteLine("Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);   
            }
            Console.WriteLine("------------------------------------");
        }
    }
}
