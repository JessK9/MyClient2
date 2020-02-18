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
            int c;
            TcpClient client = new TcpClient();
            client.Connect("whois.net.dcs.hull.ac.uk", 43);
            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());
            if(args.Length == 0)
            {
                Console.WriteLine("There is no input");
            }

                    else if (args.Length == 1)
                    {
                        if(args[0] == "-h")  // in the spec -h is the name of the server  
                            {
                                // then args[1] will be the actual server name eg whois.net
                            }
                        if(args[0] == "-p")  // in the spec - is the port number 
                            { 
                                // then args[1] will be the port number 
                            }
                        sw.WriteLine(args[0]);
                        sw.Flush();
                        string result = args[0] + " is " + sr.ReadToEnd();
                        Console.WriteLine(result);
                    }

                    else if (args.Length == 2)
                    {
                        sw.WriteLine(args[0] + ' ' + args[1]);
                        sw.Flush();
                        string result = args[0] + " location changed to be " + args[1];
                        Console.WriteLine(result);
                    }
                
           
               
            }
            catch
            {
                Console.WriteLine("Something went wrong");
            }
        }
       
    }
  
}


