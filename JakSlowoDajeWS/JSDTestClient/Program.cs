using JSDTestClient.AdminServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JSDTestClient
{
    class Program
    {
        
        //Variables
        public static UserAccount MyUser = new UserAccount();
        public static AdminService ws = new AdminService();
        public static bool isLogin = false;

        //Commands
        public static List<string> commandList = new List<string>(){
            "HELP", // 0
            "ZALOGUJ", //1
            "NOWE KONTO", // 2
            "ZMIEN HASLO", //3
            "WCZYTAJ PYTANIA"  //4
        };

        //Program
        static void Main(string[] args)
        {
            string command;         
            ShowCommandList();
            do
            {
                Console.Write("JSDWebService" + (MyUser.login != null ? ("/" +  MyUser.login) : "")  + " - >");
                command = Console.ReadLine(); 
                int i;
                switch (int.TryParse(command, out i) ? i : commandList.IndexOf(command.ToUpper()))
                {
                    case 0: //HELP
                        ShowCommandList();
                        break;
                    case 1: //ZALOGUJ
                        Login();
                        break;
                    case 2: //NOWE KONTO
                        if (isLog()) 
                        NewAccount();
                        break;
                    case 3: //ZMIEŃ HASŁO
                        if (isLog())
                        ChangePassword();
                        break;
                    case 4: //WCZYTAJ PYTANIA
                        if (isLog())
                        LoadQuestionsToDataBase();
                        break;                    
                    default:
                        Console.WriteLine("Błędna komenda. Aby uzyskać listę dostępnych komend użyj poplecenia HELP");                  
                    break;
                   }
                
            } while (true);

        }

        



        //Functions
        private static void ShowCommandList()
        {
            foreach (var com in commandList)
            {
                Console.WriteLine(commandList.IndexOf(com).ToString() + " - " + com.ToString());
            }
        }

        private static bool isLog()
        {
            if (isLogin) return true; 
            else
            {
                Console.WriteLine("Nie jesteś zalogowany. Użyj komendy ZALOGUJ");
                return false;
            }
        }

        private static void Login()
        {
            Console.Write("Login: ");
            MyUser.login = Console.ReadLine();
            Console.Write("Password: ");
            MyUser.password = Console.ReadLine();
            ws.UserAccountValue = MyUser;
            isLogin = ws.Login();
            Console.WriteLine(isLogin ? "Zalogowano: " + MyUser.login : "Złe dane");           
        }

        private static void NewAccount()
        {
            Console.Write("Login: ");
            MyUser.login = Console.ReadLine();
            Console.Write("Password: ");
            MyUser.password = Console.ReadLine();                        
            Console.WriteLine(ws.AddUser(MyUser) ? "Utworzono nowe konto: " + MyUser.login : "Błąd");        
        }

        private static void ChangePassword()
        {

            Console.Write("Nowe hasło: ");
            string newPassword = Console.ReadLine();
            ws.UserAccountValue = MyUser;
            MyUser.password = newPassword;
            Console.WriteLine(ws.ChangePassword(newPassword) ? "Zmieniono hasło!" : "Błąd");
        }

        private static void LoadQuestionsToDataBase()
        {
            ws.UserAccountValue = MyUser;
            Console.WriteLine(ws.LodadQuestionsToDataBase() == true ? "Wykonano" : "Nie wykonano");
        }

    }
}
