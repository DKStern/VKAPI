using System;
using System.IO;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VKAuth
{
    public class Program
    {
        private static readonly ulong AppId = 7282889;
        private static string login;
        private static string password;

        static void Main(string[] args)
        {
            var api = new VkApi();

            Console.Write("Введите логин: ");
            login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            password = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
                {
                    api.Authorize(new ApiAuthParams
                    {
                        ApplicationId = AppId,
                        Login = login,
                        Password = password,
                        Settings = Settings.All,
                        TwoFactorAuthorization = () =>
                        {
                            Console.Write("Введите код: ");
                            return Console.ReadLine();
                        }
                    });

                    Console.WriteLine(api.Token);
                    using (var sw = new StreamWriter("AccesToken.txt", false))
                    {
                        sw.WriteLine(api.Token);
                    }

                    Console.ReadKey();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($@"Во время авторизации возникла ошибка: {e.Message}");
            }
        }
    }
}
