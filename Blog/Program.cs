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
            
            //ReadUser();
            //ReadUsers(connection);
            ReadRoles(connection);
            //CreateUser();
            //UpdateUser();
            //DeleteeUser();

            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);   
            }
        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.Get();

            foreach (var role in roles)
            {
                Console.WriteLine(role.Name);   
            }
        }
        
    }
}
