using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9GUSLauncher.Core.Events.MissionFile
{
    public class Create
    {
        public static void File(string fileName, eventVar _eventVar)
        {
            try
            {
                //Import config variables
                Config.softwareConfig cfg = new Config.softwareConfig();

                if (System.IO.File.Exists(MainWindow.workingDir + "\\Config\\" + fileName))
                {
                    System.IO.File.Delete(MainWindow.workingDir + "\\Config\\" + fileName);

                    using (FileStream fs = System.IO.File.Open(MainWindow.workingDir + "\\Config\\" + fileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(fs))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, _eventVar);
                    }
                }
                else
                {
                    using (FileStream fs = System.IO.File.Open(MainWindow.workingDir + "\\Config\\" + fileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(fs))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, _eventVar);
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
