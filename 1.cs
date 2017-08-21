using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module1
{
    class Program
    {
        const string ADMIN_PASSWORD = "admin";
        const string USER_PASSWORD = "user";
        const string EXIT_VALUE = "0";
        const string AdminLoginPr = "admin admin1";
        static string[] UserLoginPr = { "user1 password1", "user2 password2", "user3 password3" };
        static string[] UserName = { "Ivan", "Oleg", "Sasha" };
        static string[] status = { "available", "blocked", "available" };
        static string[] history = { " ", " ", " " };
        static int[][] accounts = new int[][]
        {
        new int[] { 1000},
        new int[] { 2000, 250},
        new int[] { 3, 5}
        };
        
        static void Main(string[] args)           
        {
            while (true)
            {
                Console.WriteLine("If you want to login as admin press 1");
                Console.WriteLine("If you want to login as user press 2");
                Console.WriteLine("(Press 0 to quite this program):");
                string inputtedValue = Console.ReadLine();

                if(inputtedValue =="1")//Вход под админом
                {
                    Console.WriteLine("Please enter login");
                    string inputtedAdminLogin = Console.ReadLine();               
                    Console.WriteLine("Please enter password");
                    string inputtedAdminPassword = Console.ReadLine();
                    if(inputtedAdminLogin + " "+ inputtedAdminPassword == AdminLoginPr)
                    {
                        AdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else if(inputtedValue =="2")//Вход под юзером
                {
                    Console.WriteLine("Please enter login");
                    string inputtedUserLogin = Console.ReadLine();
                    Console.WriteLine("Please enter password");
                    string inputtedUserPassword = Console.ReadLine();
                    bool flag = false;
                    int i;
                    int userId= 0;
                    for ( i = 0; i < UserLoginPr.Length; i++)
                    {
                        if ((inputtedUserLogin + " " + inputtedUserPassword) == UserLoginPr[i])
                        {
                            flag = true;
                            userId = i;                           
                            break;                           
                        }          
                    }
                    if (flag)
                    {                       
                        UserMenu(userId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid value");
                    }
                }
                else if(inputtedValue =="0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("You logged as admin!");
                Console.WriteLine("Press 1 if you want to see list of users");
                Console.WriteLine("Press 2 if you want to block user");
                Console.WriteLine("Press 3 if you want to unblock");
                Console.WriteLine("Press 4 if you want to add account");
                Console.WriteLine("Press 5 if you want to delete account");
                Console.WriteLine("Press 6 if you want to see the history of user");
                Console.WriteLine("Press 0 to quit");
                string inputtedValue = Console.ReadLine();
                if (inputtedValue == "1")
                {
                    ShowList();
                }
                else if (inputtedValue == "2")
                {
                    BlockUser();
                }
                else if (inputtedValue == "3")
                {
                    UnblockUser();
                }
                else if (inputtedValue == "4")
                {
                    AddAccount();
                }
                else if (inputtedValue == "5")
                {
                    DeleteAccount();
                }
                else if (inputtedValue == "0")
                {
                    break;
                }
                else if (inputtedValue=="6")
                {
                    SeeHistory();
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }
        static void UserMenu(int UserId)
        {
            while (true)
            {
                Console.WriteLine("You logged as user!");
                Console.WriteLine("Hello" + UserName[UserId]);
                Console.WriteLine("Press 1 if you want to replenish account");
                Console.WriteLine("Press 2 if you want to withdraw money");
                Console.WriteLine("Press 3 if ypu want to ranfer money");
                Console.WriteLine("Press 0 to quite");
                string inputtedValue = Console.ReadLine();
                if(inputtedValue=="1")
                {
                    AddMoney(UserId);
                }
                else if(inputtedValue=="2")
                {
                    WithdrawMoney(UserId);
                }
                else if(inputtedValue=="0")
                {
                    break;
                }
                else if (inputtedValue=="3")
                {
                    TransferMoney(UserId);
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }

        static void ShowList()//Выводим список все пользователей для админа
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(UserName[i]);
                Console.WriteLine(status[i]);
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    Console.WriteLine(accounts[i][j]);
                }
            }
        }

        static void BlockUser()//блокировка пользователя админом
        {
            Console.WriteLine("Which user you want to block?");
            int userId = int.Parse(Console.ReadLine());
            int flag = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (i == userId) {
                    for (int j = 0; j < accounts[i].Length; j++)
                    {
                        if (accounts[i][j] < 10)
                        {
                            flag++;
                        }
                    }
                    if (flag == accounts[i].Length)
                    {
                        status[i] = "blocked";
                    }
                    break;
                }
            }
        }
        static void UnblockUser()//разблокировка пользователя для админа
        {
            Console.WriteLine("Which user you want to unblock?");
            int userId= int.Parse(Console.ReadLine());
            for (int i = 0; i < accounts.Length; i++)
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    if (i == userId)
                    {
                         status[i]= "available";
                    }
                }
        }
        static void AddAccount()//добавление пользователя или счета пользователю
        {

            while (true)
            {
                Console.WriteLine("If you want to add user press 1 ");
                Console.WriteLine("If you want to add account press 2");
                Console.WriteLine("If you want to quit press 0");
                int Value = int.Parse(Console.ReadLine());
                if (Value == 1)//создание нового пользователя
                {
                    Console.WriteLine("Please enter user login");
                    string inputtedUserLogin = Console.ReadLine();
                    Console.WriteLine("Please enter user password");
                    string inputtedUserPassword = Console.ReadLine();
                    string LogPas = inputtedUserLogin + " " + inputtedUserPassword;
                    Console.WriteLine("Please enter name");
                    string NewUserName = Console.ReadLine();
                    string[] newLogPas = new string[UserLoginPr.Length + 1];
                    string[] newName = new string[UserName.Length + 1];
                    string[] newStatus = new string[status.Length + 1];
                    string[] newHistory = new string[history.Length + 1];
                    int[][] NewAccounts = new int[accounts.Length + 1][];
                    for (int i = 0; i < accounts .Length; i++)
                    {
                        newLogPas[i] = UserLoginPr[i];
                        newName[i] = UserName[i];
                        newStatus[i] = status[i];
                        newHistory[i] = history[i];
                        NewAccounts[i] = accounts[i];
                    }
                    newLogPas[newLogPas.Length - 1] = LogPas;
                    UserLoginPr = newLogPas;
                    newName[newName.Length - 1] = NewUserName;
                    UserName = newName;
                    newStatus[newStatus.Length - 1] = "available";
                    status = newStatus;
                    newHistory[newHistory.Length - 1] = " ";
                    history = newHistory;
                    NewAccounts[NewAccounts.Length - 1] = new int[] { 0 };
                    accounts = NewAccounts;
                }
                else if (Value == 2)//создание еще одного счета уже существующему пользователю
                {
                    Console.WriteLine("Please enter user ID");
                    int UserId = int.Parse(Console.ReadLine());
                    int[] NewAccount = new int[accounts[UserId].Length + 1];
                    for (int j = 0; j < accounts[UserId ].Length; j++)
                    {
                        NewAccount[j] = accounts[UserId][j];
                    }
                    NewAccount[NewAccount.Length - 1] = 0;
                    accounts[UserId] = NewAccount;
                }
                else if (Value == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }
        static void DeleteAccount()//удаление пользователя или счета
        {
            while (true)
            {
                Console.WriteLine("If you want to delete user press 1 ");
                Console.WriteLine("If you want to delete account press 2");
                Console.WriteLine("If you want to quit press 0");
                int Value = int.Parse(Console.ReadLine());
                if (Value == 1)//удаление всего пользователя
                {
                    Console.WriteLine("Please enter UserId");
                    int userId = int.Parse (Console.ReadLine());
                    string[] newLogPas = new string[UserLoginPr.Length - 1];
                    string[] newName = new string[UserName.Length - 1];
                    string[] newStatus = new string[status.Length - 1];
                    string[] newHistory = new string[history.Length - 1];
                    int[][] NewAccounts = new int[accounts.Length - 1][];
                    int j = 0;
                    for (int i = 0; i < accounts.Length ; i++)
                    {
                        if (i!= userId)
                        {
                            newLogPas[j] = UserLoginPr[i];
                            newName[j] = UserName[i];
                            newStatus[j] = status[i];
                            NewAccounts[j] = accounts[i];
                            newHistory[j] = history[i];
                            j++;
                        }
                    }
               
                    UserLoginPr = newLogPas;                   
                    UserName = newName;                   
                    status = newStatus;                  
                    history = newHistory;
                    accounts = NewAccounts;
                }
                else if (Value == 2)//удаление одного счета пользователя
                {
                    Console.WriteLine("Please enter user ID");
                    int UserId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter account ID");
                    int AccountId = int.Parse(Console.ReadLine());
                    int[] NewAccount = new int[accounts[UserId].Length -1];
                    for (int j = 0; j < accounts[UserId].Length; j++)
                    {
                        if (j != AccountId)
                        {
                            NewAccount[j] = accounts[UserId][j];
                        }
                    }
                    accounts[UserId ] = NewAccount;
                }
                else if (Value == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }
        static void SeeHistory()//просмотр истории денежных операций
        {
            Console.WriteLine("Please enter UserId for user ,who history you want to see");
            int UserId = int.Parse(Console.ReadLine());
            Console.WriteLine(history[UserId]);
        }
        static void AddMoney(int userId)//добавление денег пользователем
        {
            Console.WriteLine("On which account you want to add money?");
            int AccountId = int.Parse(Console.ReadLine());
            Console.WriteLine("Which sum you want to add?");
            int Sum = int.Parse(Console.ReadLine());
            accounts[userId][AccountId] += Sum;
            Console.WriteLine("New balance :");
            Console.WriteLine(accounts[userId][AccountId]);
            history[userId] += "On account" + AccountId + "was added" + Sum;
        }
        static void WithdrawMoney(int userId)//снятие денег пользователем
        {
            Console.WriteLine("From which account you want to take money?");
            int AccountId = int.Parse(Console.ReadLine());
            Console.WriteLine("Which sum you want to take?");
            int sum = int.Parse(Console.ReadLine());
            accounts[userId][AccountId] -= sum;
            Console.WriteLine("New balance :");
            Console.WriteLine(accounts[userId][AccountId]);
            history[userId] += "From account" + AccountId + "was withdrawn" + sum;
        }
        static void TransferMoney(int userId)//перевод денег между счетами
        {
            Console.WriteLine("From which account you want to take money?");
            int Account1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Which sum you want to tranfer?");
            int Sum = int.Parse(Console.ReadLine());
            Console.WriteLine("On which account you want to put money?");
            int Account2 = int.Parse(Console.ReadLine());
            if(accounts[userId][Account1]>= Sum)
            {
                accounts[userId][Account1] -= Sum;
                accounts[userId][Account2] += Sum;
            }
            else
            {
                Console.WriteLine("Not enough money for transfer");
            }
            Console.WriteLine("New balance Account 1:");
            Console.WriteLine(accounts[userId][Account1]);
            Console.WriteLine("New balance Account 2:");
            Console.WriteLine(accounts[userId][Account2]);
            history[userId] += "From account" + Account1 + "was transfered" + Sum + "to account" + Account2;
        }       
    }   
}
