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

            TcpClient client = new TcpClient();
            client.Connect(serverName, portNumber);
            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());
            client.SendTimeout = 1000;
            client.ReceiveTimeout = 1000;

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
                            if (location != null)  // changing location
                            {
                                sw.WriteLine(username + ' ' + location);
                                sw.Flush();
                                string reply = sr.ReadLine();
                                if (reply == "OK")
                                {
                                    string result = username + " location changed to be " + location;
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong");
                                }
                            }
                          else  if (username != null) // finding location 
                                 {
                                sw.WriteLine(username);
                                sw.Flush();
                                string result = username + " is " + sr.ReadToEnd();
                                Console.WriteLine(result);
                                  }
                            
                            break;

                        case "-h9": // HTTP/0.9
                            if (location != null)  // changing location
                            {
                                sw.WriteLine("PUT /" + username);
                                sw.WriteLine();
                                sw.WriteLine(location);
                                sw.Flush();
                                
                                string reply = sr.ReadLine();
                                if (reply.StartsWith("HTTP/0.9 200"))
                                {
                                    string result = username + " location changed to be " + location;
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong");
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
                                    Console.WriteLine(result);
                                }
                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: Not Found");
                                }
                                
                            }
                           
                            break;

                        case "-h0": //HTTP/1.0
                            if (location != null)  // changing location
                            {
                                int locationLength = location.Length;
                                sw.WriteLine("POST /" + username + " HTTP/1.0");
                                sw.WriteLine("Content-Length: " + locationLength);
                                sw.WriteLine();
                                sw.WriteLine(location);
                                sw.Flush();
                                
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
                                    Console.WriteLine(result);
                                }
                                else if (split[1] == "404")
                                {
                                    Console.WriteLine("ERROR: no entries found");
                                }

                            }
                            break;

                        case "-h1": // HTTP/1.1
                            if (location != null)  // changing location
                            {
                               
                                string everything = "name=" + username + "&location=" + location;
                                int everythingLength = everything.Length;
                                sw.WriteLine("POST /" + " HTTP/1.1");
                                sw.WriteLine("Host: " + serverName);
                                sw.WriteLine("Content-Length: " + everythingLength);
                                sw.WriteLine();
                                sw.WriteLine(everything);
                                sw.Flush();

                               
                                string line = sr.ReadLine();
                                string[] split = line.Split(' ');
                                if (split[1] == "200" || split[1] == "304" || split[1] == "301")
                                {
                                    do
                                    {
                                        line = sr.ReadLine();
                                    } while (line.Length != 0);

                                    string result = username + " is " + sr.ReadToEnd();
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
                                if(!serverName.Equals("localhost"))
                                {
                                    sw.WriteLine("Connection: close");
                                }
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
            }
            catch
            {
                Console.WriteLine("Something went wrong here");
            }

          



        }
    }
}


