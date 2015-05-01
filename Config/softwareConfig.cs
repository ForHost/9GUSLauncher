using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9GUSLauncher.Config
{
    public class softwareConfig
    {
        //Online FTP Json config

        public string ftpjsonUser = "";
        public string ftpjsonPassword = "";
        public string ftpjsonAddress = ""; //ftp.domain.com or 127.0.0.1
        public string ftpjsonFolder = ""; // /public_html/private/files/
        public string ftpjsonFileName = "";

        //Online URLS

        public string jsonConfig = ""; //https or http
        public string updateFile = ""; //https or http

        //Master Server

        public string masterServer = ""; //master.domain.com or 127.0.0.1

        //String Cipher Key

        public readonly string cipherKey = ""; //djkoi123ezKSAOq2341s

        //Login System Platform

        public string forumLink = ""; //https or http. actually supported phpbb3 (/ucp.php?mode=login)

    }


}