using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=CAMILANUNES-DES\SQLEXPRESS; Database=Cursos; User ID=sa; Password=8uygfe345";
                                                
        static void Main(string[] args)
        {
            //ReadUser();
            //ReadUsers();
            CreateUser();
            //UpdateUser();
            //DeleteeUser();
        }

        public static void ReadUsers()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);   
                }
            }
        }

        public static void ReadUser()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Name);   
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Name = "Camila Viana Nunes",
                Email = "cvn.camila@gmail.com",
                Bio = "Desenvolvedora Delphi e C#",
                PasswordHash = "HashHash",
                Image = "https://",
                Slug = "camila-viana-nunes" 
            };

            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);

                Console.WriteLine("Cadastro realizado com sucesso.");   
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Name = "Camila Viana Nunes",
                Email = "cvn.camila@gmail.com",
                Bio = "Desenvolvedora Delphi e C# .Net", 
                PasswordHash = "HashHash",
                Image = "https://",
                Slug = "camila-viana-nunes" 
            };

            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);

                Console.WriteLine("Cadastro alterado com sucesso.");   
            }
        }

        public static void DeleteeUser()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);

                Console.WriteLine("Usuário excluído com sucesso.");   
            }
        }
    }
}
