using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BroadcastHotkeyPlayer
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BroadcastHotkeyPlayerWindow());
            }
            catch (Exception e) {
                MessageBox.Show("Caught exception in main: {0}", e.ToString());
            }
        }
    }
}
