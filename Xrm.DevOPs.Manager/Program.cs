using System;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.UI.Forms;

namespace Xrm.DevOPs.Manager
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //this is pushed from the command line (git)


        }
    }
}
