using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9GUSLauncher.Core
{
    public class loginClass
    {
        public static CookieContainer login(string url, string username, string password)
        {
            if (url.Length == 0 || username.Length == 0 || password.Length == 0)
            {

                return null;
            }

            CookieContainer myContainer = new CookieContainer();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();

            // Set type to POST
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            request.ContentType = "application/x-www-form-urlencoded";

            // Build the new header, this isn't a multipart/form, so it's very simple
            StringBuilder data = new StringBuilder();
            data.Append("username=" + Uri.EscapeDataString(username));
            data.Append("&password=" + Uri.EscapeDataString(password));
            data.Append("&login=Login");

            // Create a byte array of the data we want to send
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());

            // Set the content length in the request headers
            request.ContentLength = byteData.Length;

            Stream postStream;
            try
            {
                postStream = request.GetRequestStream();
            }
            catch (Exception e)
            {
                MessageBox.Show("Login - " + e.Message.ToString() + " (GRS)");
                return null;
            }

            // Write data
            postStream.Write(byteData, 0, byteData.Length);

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {
                MessageBox.Show("Login - " + e.Message.ToString() + " (GR)");
                return null;
            }

            bool isLoggedIn = false;

            // Store the cookies
            foreach (Cookie c in response.Cookies)
            {
                if (c.Name.Contains("_u"))
                {
                    if (Convert.ToInt32(c.Value) > 1)
                    {
                        isLoggedIn = true;
                    }
                }
                myContainer.Add(c);
            }

            if (isLoggedIn)
            {
                return myContainer;
            }
            else
            {
                return null;
            }
        }
    }
}
