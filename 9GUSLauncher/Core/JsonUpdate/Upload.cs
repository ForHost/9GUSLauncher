using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9GUSLauncher.Core.JsonUpdate
{
    public class Upload
    {
        public static void File()
        {
            //Import config variables
            Config.softwareConfig cfg = new Config.softwareConfig();

            FtpWebRequest request;
            try
            {
                string absoluteFileName = Path.GetFileName(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName);

                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", cfg.ftpjsonAddress, cfg.ftpjsonFolder, absoluteFileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(cfg.ftpjsonUser, cfg.ftpjsonPassword);
                request.ConnectionGroupName = "group";

                using (FileStream fs = System.IO.File.OpenRead(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                    requestStream.Flush();
                }

                System.IO.File.Delete(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
