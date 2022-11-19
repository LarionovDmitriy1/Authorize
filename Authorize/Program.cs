using Authorize;
void Menu()
{
    Console.WriteLine("Меню");
    Console.WriteLine();
    Console.WriteLine("1. Зарегистрироваться");
    Console.WriteLine("2. Войти");
}
void GetMenu()
{
    string menu = Console.ReadLine();
    bool parse = int.TryParse(menu, out var selectedItem);
    if (parse)
    {
        switch (selectedItem)
        {
            case 1:
                IAuthorization registration = new Registration();
                registration.Login();
                break;
            case 2:
                IAuthorization authorization = new Authorization();
                authorization.Login();
                break;

            default:
                string exception = "Ошибка, введите корректное значение в меню";
                Console.WriteLine();
                Console.WriteLine(exception);
                Console.WriteLine();
                Log log = new Log();
                log.Logs(exception);
                break;
        }
    }
    else
    {
        string exception = "Ошибка, введите корректное значение в меню";
        Console.WriteLine();
        Console.WriteLine(exception);
        Console.WriteLine();
        Log log= new Log();
        log.Logs(exception);
        
    }
}
while (true)
{
    Menu();
    GetMenu();
}