using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;
using System.Net.Sockets;
namespace ConsoleAppIP
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip1 = IPAddress.Parse("192.168.1.249");
            IPHostEntry hostInfo = Dns.GetHostEntry(ip1);
            Console.WriteLine("Host name : " + hostInfo.HostName);

            IPAddress ipclient = IPAddress.Parse("192.168.2.40");
            IPHostEntry hostEntry = Dns.GetHostEntry(ipclient);
            //string HostName1 = hostEntry.HostName;
            //IPAddress[] ipAddr1 = Dns.GetHostAddresses(HostName1);
            IPAddress[] ipAddr1 = hostEntry.AddressList;
            //Console.WriteLine("Host name : " + HostName1.ToString());
            foreach (IPAddress _IPAddress in ipAddr1)
            {
                Console.WriteLine("IPAddress : " + _IPAddress.ToString());
            }
            
           
            //string HostName = "";
            //System.Net.IPAddress clientIP = System.Net.IPAddress.Parse("192.168.2.40");//根据目标IP地址获取IP对象
            //System.Net.IPHostEntry ihe = System.Net.Dns.GetHostEntry(clientIP);//根据IP对象创建主机对象
            //HostName = ihe.HostName;//获取客户端主机名称
            
            //IPAddress[] ipAddr;

            //ipAddr = Dns.GetHostAddresses(HostName);

            //Console.WriteLine("GetHostAddresses({0}) returns:", HostName);

            //foreach (IPAddress _IPAddress in ipAddr)
            //{
            //    if (_IPAddress.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        Console.WriteLine("Ipv4  {0}", _IPAddress);
            //    }
            //    if (_IPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            //    {
            //        Console.WriteLine("Ipv6  {0}", _IPAddress);
            //    }
            //}
        }
    }
}
