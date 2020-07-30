using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace ConsoleAppIPPing
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping ping = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string ip="www.baidu.com";
            int timeout=200;
            string data="ping test";
            byte[] buf=Encoding.ASCII.GetBytes(data);
            PingReply reply = ping.Send(ip, timeout, buf, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("{0}连接成功", ip);
            }
            else
            {
                Console.WriteLine("{0}连接不成功", ip);
            }
        }
    }
}
