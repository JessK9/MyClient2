using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace MyClient
{

    public class Program
    {
        static void Main(string[] args)
        {
            
            string serverName = "whois.net.dcs.hull.ac.uk";
            int portNumber = 43;
            string protocol = "whois";
            string username = null;
            string location = null;


            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {

                    case "-h": serverName = args[i + 1];
                        break;
                    case "-p": portNumber = int.Parse(args[i + 1]);
                        break;
                    case "-h0":
                        protocol = args[i + 1];
                        break;
                    case "-h1":
                        protocol = args[i + 1];
                        break;
                    case "-h9":
                        protocol = args[i + 1];
                        break;
                    default:
                        if (username == null)
                        {
                            username = args[i];
                        }
                        else if (location == null)
                        {
                            location = args[i];
                        }
                        break;

                }
            }

            TcpClient client = new TcpClient();
            client.Connect(serverName, portNumber);
            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());

            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("There is no input");
                }
                else if (args.Length != 0)
                {
                    switch (protocol)
                    {
                        case "whois":
                            if (args.Length == 1) // finding location 
                            {
                                sw.WriteLine(args[0]);
                                sw.Flush();
                                string result = args[0] + " is " + sr.ReadToEnd();
                                Console.WriteLine(result);
                            }
                            else if (args.Length == 2)  // changing location
                            {
                                sw.WriteLine(args[0] + ' ' + args[1]);
                                sw.Flush();
                                string reply = sr.ReadLine();
                                if (reply == "OK")
                                {
                                    string result = args[0] + " location changed to be " + args[1];
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong");
                                }
                            }
                            break;

                        case "-h9": // look at the protocols - HTTP/0.9
                            if (args.Length == 1) // finding location 
                            {
                                sw.WriteLine(args[0]);
                                sw.Flush();
                                string result = args[0] + " is " + sr.ReadToEnd();
                                Console.WriteLine(result);
                            }
                            else if (args.Length == 2)  // changing location
                            {
                                sw.WriteLine(args[0] + ' ' + args[1]);
                                sw.Flush();
                                string reply = sr.ReadLine();
                                if (reply == "OK")
                                {
                                    string result = args[0] + " location changed to be " + args[1];
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong");
                                }
                            }
                            break;

                            case "-h0": //HTTP/1.0
                                 if (args.Length == 1) // finding location 
                                 {
                                     sw.WriteLine(args[0]);
                                     sw.Flush();
                                     string result = args[0] + " is " + sr.ReadToEnd();
                                     Console.WriteLine(result);
                                 }
                                 else if (args.Length == 2)  // changing location
                                 {
                                     sw.WriteLine(args[0] + ' ' + args[1]);
                                     sw.Flush();
                                     string reply = sr.ReadLine();
                                     if (reply == "OK")
                                     {
                                         string result = args[0] + " location changed to be " + args[1];
                                         Console.WriteLine(result);
                                     }
                                     else
                                     {
                                         Console.WriteLine("Something went wrong");
                                     }
                                 }
                                 break;
                           case "-h1": // HTTP/1.1
                                 if (args.Length == 1) // finding location 
                                 {
                                sw.WriteLine(args[0]);
                                sw.Flush();
                                string result = args[0] + " is " + sr.ReadToEnd();
                                Console.WriteLine(result);
                                 }
                                else if (args.Length == 2)  // changing location
                                {
                                    sw.WriteLine(args[0] + ' ' + args[1]);
                                    sw.Flush();
                                    string reply = sr.ReadLine();
                                    if (reply == "OK")
                                    {
                                        string result = args[0] + " location changed to be " + args[1];
                                        Console.WriteLine(result);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Something went wrong");
                                    }
                                }
                                 break;
                    }
                }
            }
                catch
            {
                Console.WriteLine("Something went wrong");
            }
           
           /*     else if (args.Length == 2)
            {

                sw.WriteLine(args[0] + ' ' + args[1]);
                sw.Flush();
                string reply = sr.ReadLine();
                if (reply == "OK")
                {
                    string result = args[0] + " location changed to be " + args[1];
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
            }
            */


            //sr is reading what comes out of the server
            // args is the user 




        }
    }
}


