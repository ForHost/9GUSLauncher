using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _9GUSLauncher.Core
{
    public class Program
    {
        static System.Threading.Mutex mutex = new System.Threading.Mutex(true, "9GUSLauncher");

        [STAThreadAttribute]
        public static void Main()
        {
            try
            {
                if(!mutex.WaitOne(TimeSpan.Zero, true))
                {
                    MessageBox.Show("There is already another istance running!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                }
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
                App.Main();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly parentAssembly = Assembly.GetExecutingAssembly();

            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
            var resourceName = parentAssembly.GetManifestResourceNames()
                .First(s => s.EndsWith(name));

            using (Stream stream = parentAssembly.GetManifestResourceStream(resourceName))
            {
                byte[] block = new byte[stream.Length];
                stream.Read(block, 0, block.Length);
                return Assembly.Load(block);
            }
        }
    }
}
