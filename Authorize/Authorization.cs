using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize;

public class Authorization : IReader, IAuthorization
{
    public void Login()
    {
        Console.WriteLine();
        Console.WriteLine("Введите логин");
        Console.WriteLine();
        string login = Console.ReadLine();
        if (login.Length < 4)
        {
            string exeption = "Ошибка, логин меньше 4 символов";
            Log log = new();
            log.Logs(exeption);
            return;
        }
        else
        {
            string path = @"C:\Users\Студент1\Desktop\Logins.txt";
            if (Read(path, login))
            {
                Password(login);
            }
            else
            {
                return;
            }
        }
    }

    public void Password(string login)
    {
        Console.WriteLine();
        Console.WriteLine("Введите пароль");
        Console.WriteLine();
        string password = Console.ReadLine();
        if (password.Length < 8)
        {
            string exeption = "Ошибка, пароль меньше 8 символов";
            Console.WriteLine();
            Console.WriteLine(exeption);
            Console.WriteLine();
            Log log = new();
            log.Logs(exeption);
            return;
        }
        else
        {
            string pathLogin = @"C:\Users\Студент1\Desktop\Logins.txt";
            string pathPassword = @"C:\Users\Студент1\Desktop\Passwords.txt";
            FileInfo passwords = new FileInfo(pathPassword);
            FileInfo logins = new FileInfo(pathLogin);
            if (passwords.Exists)
            {
                using (StreamReader read = new StreamReader(pathPassword))
                {
                    using (StreamReader readLogin = new StreamReader(pathLogin))
                    {
                        string userLogin = readLogin.ReadToEnd();

                        string userPassword = read.ReadToEnd();
                        if (userLogin.Contains(login) ||  userPassword.Contains(password))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы успешно вошли");
                            Console.WriteLine();
                        }
                        else
                        {
                            string exeption = "Ошибка, неверный логин или пароль";
                            Console.WriteLine();
                            Console.WriteLine(exeption);
                            Console.WriteLine();
                            Log log = new();
                            log.Logs(exeption);
                            return;
                        }
                    }
                }
            }
            else
            {
                string exeption = "Ошибка, пользователь ещё не зарегистрирован";
                Console.WriteLine();
                Console.WriteLine(exeption);
                Console.WriteLine();
                Log log = new();
                log.Logs(exeption);
                return;
            }
        }
    }

    public bool Read(string path,string login)
    {
        FileInfo file = new FileInfo(path);
        if (file.Exists)
        {
            using (StreamReader read = new StreamReader(path))
            {
                string userLogin = read.ReadToEnd();
                if (userLogin.Contains(login))
                {
                    return true;
                }
            }
        }
        else
        {
            string exeption = "Ошибка, логин не найден";
            Console.WriteLine();
            Console.WriteLine(exeption);
            Console.WriteLine();
            Log log = new();
            log.Logs(exeption);           
            return false;
        }
        return false;
    }
}
