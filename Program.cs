using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using EpubEditor.Forms;

namespace EpubEditor
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
                Application.Run(new EpubEditorMainForm(args));
            else
                Application.Run(new EpubEditorMainForm());

        }
    }
}
