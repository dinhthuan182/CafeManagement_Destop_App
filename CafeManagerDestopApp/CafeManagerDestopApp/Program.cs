using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagerDestopApp.Entitys;

namespace CafeManagerDestopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (AuthGlobals.access_token == null)
            {
                Application.Run(new Login());
            } else
            {
                Application.Run(new MainScreen());
            }
            
        }
    }

    static class AuthGlobals
    {
        // user info
        public static User user;
        // token
        public static string access_token;
        public static int expires_in;
    }


}
