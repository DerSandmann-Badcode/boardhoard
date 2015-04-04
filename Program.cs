using System;
using System.Windows.Forms;
using System.Reflection;
using HtmlAgilityPack;
using System.Runtime.InteropServices;

namespace BoardHoard
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);

            if (args.Length > 0)
            {
                /*
                 * Plans to build a non-GUI version of BoardHoard
                 * so that it can be run on a server with no UI
                 */
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("HtmlAgilityPack.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
            }
        }


       
    }


}
