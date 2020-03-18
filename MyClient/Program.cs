using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;


namespace MyClient
{

    public class Program

    {
        public static string serverName = null;
        public static int portNumber = 43;
        public static int timeoutClient = 1000;
        public static string username = null;
        public static string location = null;
        public static string protocol = null;
        public static bool debug;

        static void Main(string[] args)
        {
            

            if (args.Length == 0)
            {
                
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 Application.Run(new Form1());
                
               
            }
            else if (args.Length != 0)
            {
                serverName = "whois.net.dcs.hull.ac.uk";
                protocol = "whois";
               

                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {

                        case "-h":
                            serverName = args[++i];
                            break;
                        case "-p":
                            portNumber = int.Parse(args[++i]);
                            break;
                        case "-h0":
                            protocol = args[i];
                            break;
                        case "-h1":
                            protocol = args[i];
                            break;
                        case "-h9":
                            protocol = args[i];
                            break;
                        case "-t":
                            timeoutClient = int.Parse(args[++i]);
                            Console.WriteLine("Timeout for the client has been changed to: " + timeoutClient);
                            break;
                        case "-d":
                            debug = true;
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
                            else
                            {
                                Console.WriteLine();
                                return;
                            }
                            break;

                    }
                }
            }

            TcpClient client = new TcpClient();
            client.Connect(serverName, portNumber);
            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());
            client.SendTimeout = timeoutClient;
            client.ReceiveTimeout = timeoutClient;

            try
            {
                    switch (protocol)
                    {

                        case "whois":
                            if (location != null)  // changing location
                            {
                                sw.WriteLine(username + ' ' + location);
                                sw.Flush();
                                if (debug == true)
                                {
                                Console.WriteLine("This is an update protocol for whois and the username is: " + username + " and the location is: " + location);
                                }
                            try
                            {
                                string reply = sr.ReadLine();
                                if (reply == "OK")
                                {
                                    string result = username + " location changed to be " + location;
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong - whois protocol");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Something went wrong");
                            }
                            
                            }
                          else  if (username != null) // finding location 
                              {
                                sw.WriteLine(username);
                                sw.Flush();
                          
                            try
                            {
                                string result = username + " is " + sr.ReadLine();
                                Console.WriteLine(result);
                                if (debug == true)
                                {
                                    Console.WriteLine("This is a lookup protocol for whois and the username is: " + username + " and the location is: " + location);
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Something went wrong");
                            }
                             }
                            
                           break;

                    case "-h9": case "HTTP/0.9": // HTTP/0.9
                            if (location != null)  // changing location
                            {
                                sw.WriteLine("PUT /" + username + "\r\n" + location);
                                sw.Flush();

                            if (debug == true)
                            {
                                Console.WriteLine("This is an update location for protocol HTTP/0.9 and the username is: " + username + " and the location is: " + location);
                            }

                            string reply = sr.ReadLine();
                                if (reply.StartsWith("HTTP/0.9 200"))
                                {
                                    string result = username + " location changed to be " + location;
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong - HTTP/0.9 protocol");
                                }
                            }
                            else if (username != null) // finding location 
                            {
                               
                                sw.WriteLine("GET /" + username);
                            sw.Flush();
                           
                            
                                string line = sr.ReadLine();
                                string[] split = line.Split(' ');
                                if (split[1] == "200")
                                {
                                    do
                                    {
                                        line = sr.ReadLine();
                                    } while (line.Length != 0);
                                    
                                    string result = username + " is " + sr.ReadToEnd();
                                if (debug == true)
                                {
                                    Console.WriteLine("This is look-up for protocol whois and the username is: " + username + " and the location is: " + location);
                                }
                                Console.WriteLine(result);
                                }
                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: No Entries Found");
                                }
                                
                            }
                           
                            break;

                        case "-h0": case "HTTP/1.0": //HTTP/1.0
                            if (location != null)  // changing location
                            {
                                int locationLength = location.Length;
                                sw.WriteLine("POST /" + username + " HTTP/1.0" + "\r\n" + "Content-Length: " + locationLength + "\r\n" + location);
                                sw.Flush();

                            if (debug == true)
                            {
                                Console.WriteLine("This is a update location for protocol HTTP/1.0 and the username is: " + username + " and the location is: " + location);
                            }
                            string line = sr.ReadLine();
                                string[] split = line.Split(' ');
                                if (split[1] == "200" || split[1] == "304" || split[1] == "301")
                                {
                                    do
                                    {
                                        line = sr.ReadLine();
                                    } while (line.Length != 0);

                                    string result = username + " location changed to be " + location;
                                    Console.WriteLine(result);
                                }
                               

                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: no entries found");
                                }
                            }
                            else if (username != null) // finding location 
                            {

                                sw.WriteLine("GET /?" + username + " HTTP/1.0");
                                sw.WriteLine();
                                sw.Flush();
                            
                            string line = sr.ReadLine();
                                string[] split = line.Split(' ');
                                if (split[1] == "200")
                                {
                                    do
                                    {
                                        line = sr.ReadLine();
                                    } while (line.Length != 0);

                                    string result = username + " is " + sr.ReadToEnd();
                                if (debug == true)
                                {
                                    Console.WriteLine("This is look-up for protocol HTTP/1.0 and the username is: " + username + " and the location is: " + location);
                                }
                                
                                Console.WriteLine(result);

                                }
                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: no entries found");
                                }

                            }
                            break;

                        case "-h1": case "HTTP/1.1":// HTTP/1.1
                            if (location != null)  // changing location
                            {
                               
                                string everything = "name=" + username + "&location=" + location;
                                int everythingLength = everything.Length;
                                sw.WriteLine("POST /" + " HTTP/1.1");
                                sw.WriteLine("Host: " + serverName);
                                sw.WriteLine("Content-Length: " + everythingLength);
                                sw.WriteLine();// remove this to work, dows not work if its this!
                                sw.WriteLine(everything);
                                sw.Flush();
                                if (debug == true)
                                {
                                    Console.WriteLine("This is a location update for protocol HTTP/1.1 and the username is: " + username + " and the location is: " + location);
                                }

                            string line = sr.ReadLine();
                                string[] split = line.Split(' ');
                                if (split[1] == "200" || split[1] == "304" || split[1] == "301")
                                {
                                    do
                                    {
                                        line = sr.ReadLine();
                                    } while (line.Length != 0);

                                    string result = username + " location changed to be " + location;
                                    Console.WriteLine(result);
                                }
                                
                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: no entries found");
                                }
                               
                            }
                            else if (username != null) // finding location 
                            {

                                sw.WriteLine("GET /?name=" + username + " HTTP/1.1");
                                sw.WriteLine("Host: " + serverName);
                            
                            sw.WriteLine();
                                sw.Flush();
                                
                                string line = sr.ReadLine();
                                string[] split = line.Split(' ');
                                if (split[1] == "200" || split[1] == "304" || split[1] =="301")
                                {
                                    do
                                    {
                                        line = sr.ReadLine();
                                    } while (line.Length != 0);

                                    string result = username + " is " + sr.ReadToEnd();
                                if (debug == true)
                                {
                                    Console.WriteLine("This is look-up for protocol HTTP/1.1 and the username is: " + username + " and the location is: " + location);
                                }
                                Console.WriteLine(result);
                                }
                                

                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: no entries found");
                                }

                            }

                            break;
                    }
                
            }
            catch (Exception e)
            { 
            
                    Console.WriteLine("Exception: " + e.ToString());
                
            }

          



        }
    }
}


