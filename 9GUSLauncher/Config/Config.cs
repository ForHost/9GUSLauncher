using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9GUSLauncher.Config
{
    public class Config
    {
        public string Software { get; set; }
        public string LatestVersion { get; set; }
        public int SoftwareID { get; set; }
        public string Language { get; set; }
        public bool Available { get; set; }
        public string notAvailableMsg { get; set; }
        public string MasterIP { get; set; }
        public string MasterIPDNS { get; set; }
        public string[] Administrators { get; set; }
        public string webConfig { get; set; }
        public string webConfig_News { get; set; }
        public string[] whiteList { get; set; }
        public string[] banList { get; set; }
    }
}
