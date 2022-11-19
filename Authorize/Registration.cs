using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize;

public class Registration : IReader, IAuthorization
{
    public Registration()
    {

    }


    public void Login()
    {
        Console.WriteLine();
        Console.WriteLine("Введите логин, который не меньше 4 символов");
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
            string path = @"C:\Users\Студент1\Desktop\Users.txt";
            if (!Read(path, login))
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
        Console.WriteLine("Введите пароль, который не меньше 8 символов");
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
            string pathUser = @"C:\Users\Студент1\Desktop\Users.txt";
            FileInfo logins = new FileInfo(pathUser);
            if (logins.Exists)
            {
                using (StreamWriter writeLog = new StreamWriter(pathUser, true))
                {
                    writeLog.WriteLine($"{password} {login}");
                    Console.WriteLine();
                    Console.WriteLine("Вы успешно зарегистрированы");
                    Console.WriteLine();
                }
            }
            else
            {
                using (logins.Create())
                {

                }
                using (StreamWriter writeLog = new StreamWriter(pathUser, true))
                {
                    writeLog.WriteLine($"{password} {login}");
                    Console.WriteLine();
                    Console.WriteLine("Вы успешно зарегистрированы");
                    Console.WriteLine();
                }
            }
        }
    }


    public bool Read(string path,string login)
    {
        FileInfo file = new FileInfo(path);
        if (file.Exists)
        {
            using (StreamReader read=new StreamReader(path))
            {
                string userLogin = read.ReadToEnd();
                if (userLogin.Contains(login))
                {
                    string exeption = "Ошибка, Логин занят";
                    Console.WriteLine();
                    Console.WriteLine(exeption);
                    Console.WriteLine();
                    Log log = new();
                    log.Logs(exeption);
                    return true;
                }
            }
        }
        else
        {
            return false;
        }
        return false;
    }
}
