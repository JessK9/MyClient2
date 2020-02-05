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
            sw.WriteLine(args[0]);
            sw.Flush();
            Console.WriteLine(sr.ReadToEnd());
           
            
        }
       
    }
  
}


