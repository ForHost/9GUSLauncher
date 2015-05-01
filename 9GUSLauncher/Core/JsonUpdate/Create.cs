using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9GUSLauncher.Core.JsonUpdate
{
    public class Create
    {
        public static void File()
        {
            try
            {
                //Import config variables
                Config.softwareConfig cfg = new Config.softwareConfig();

                if (System.IO.File.Exists(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName))
                {
                    System.IO.File.Delete(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName);

                    using (FileStream fs = System.IO.File.Open(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(fs))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, MainWindow.config);
                    }
                }
                else
                {
                    using (FileStream fs = System.IO.File.Open(MainWindow.workingDir + "\\" + cfg.ftpjsonFileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(fs))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, MainWindow.config);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }
    }
}
