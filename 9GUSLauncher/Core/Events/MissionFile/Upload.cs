using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9GUSLauncher.Core.Events.MissionFile
{
    public class Upload
    {
        public static void File(string fileName)
        {
            //Import config variables
            Config.softwareConfig cfg = new Config.softwareConfig();

            FtpWebRequest request;
            try
            {
                string absoluteFileName = Path.GetFileName(MainWindow.workingDir + "\\Config\\" + fileName);

                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", cfg.ftpjsonAddress , cfg.eventsLocation, fileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(cfg.ftpjsonUser, cfg.ftpjsonPassword);
                request.ConnectionGroupName = "group";

                using (FileStream fs = System.IO.File.OpenRead(MainWindow.workingDir + "\\Config\\" + fileName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                    requestStream.Flush();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
