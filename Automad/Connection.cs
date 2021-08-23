using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Automad
{
    class connection
    {
        String url = "https://ottadmin.montymobile.com/";
        private static HttpClient client;
        public connection()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client = new HttpClient();
    }
        public String login(String user, String pass)
        {

            ASCIIEncoding encoding = new ASCIIEncoding();
            String postData = "user=" + user + "&pass=" + pass;
            byte[] data = encoding.GetBytes(postData);
            String page = "checkuser.php";
            WebRequest request = WebRequest.CreateHttp(url + page);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            String resp = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return resp;
        }
       
        public static String externalip()
        {
            string externalip = new WebClient().DownloadString("http://ottadmin.montymobile.com/ipaddress.php");
            return externalip;
        }
        public static String GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }

            }
            return null;
        }
        public void log(String user)
        {
            String Internalip = GetLocalIPAddress();
            String Externalip = externalip();
            String Macaddress = GetMacAddress().ToString();

            ASCIIEncoding encoding = new ASCIIEncoding();
            String postData = "user=" + user + "&public=" + Externalip + "&private=" + Internalip + "&mac=" + Macaddress;
            byte[] data = encoding.GetBytes(postData);
            String page = "log.php";
            WebRequest request = WebRequest.CreateHttp(url + page);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
        }

        public void SuccessCount(String server,String destination,int count)
        {

            ASCIIEncoding encoding = new ASCIIEncoding();
            String postData = "server=" + server+"&destination="+destination+"&count="+count;
            byte[] data = encoding.GetBytes(postData);
            String page = "successCount.php";
            WebRequest request = WebRequest.CreateHttp(url + page);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            String resp = sr.ReadToEnd();
            sr.Close();
            stream.Close();
        }
    }
}
