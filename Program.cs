using ServiceTestConsole.ServiceReference1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Modify the following line to use your project name 
// if your project is not named Console1Application1.


// Modify the following line to use your project name 
// if your project is not named Console1Application1.
namespace ServiceTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************");
            Console.WriteLine("Welcome to my test WCF Program");

            bool loop = true;

            while (loop)
            {
                string menuItem;

                Console.WriteLine("***** MENU *****");
                Console.WriteLine("1 - GetHello()");
                Console.WriteLine("2 - Init()");
                Console.WriteLine("q - Quit");
                Console.WriteLine("****************\n");
                Console.Write("Select function to call:");

                menuItem = Console.ReadLine();

                if (menuItem == "1")
                {

                    Service1Client client = null;

                    try
                    {
                        client = new Service1Client();

                        GetHelloRequest request = new GetHelloRequest();
                        GetHelloResponse response;

                        response = client.GetHello(request);

                        Console.WriteLine("The WCF service called returned: '{0}'",
                                         response.GetHelloResult);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception encounter: {0}",
                                         e.Message);
                    }
                    finally
                    {
                        if (null != client)
                        {
                            client.Close();
                        }
                    }
                }
                else if (menuItem == "2")
                {
                    Service1Client client = null;

                    try
                    {
                        client = new Service1Client();

                        InitUserRequest request = new InitUserRequest("benapptest", "benapptest");
                        InitUserResponse response;

                        response = client.InitUser(request);

                        Console.WriteLine("The WCF service called returned: '{0}'",
                                         response.InitUserResult);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception encounter: {0}",
                                         e.Message);
                    }
                    finally
                    {
                        if (null != client)
                        {
                            client.Close();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Thanks for playing. Goodbye!");
                    return;
                }
            }
        }
    }
}
