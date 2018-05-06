using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System.Windows.Forms;
using System.IO;

namespace NavisPlugin
{
    [Plugin("NavisPlugin", "CONN", ToolTip = "BasicPlugIn.ABasicPlugin tool tip",DisplayName = "ExportCADLayer")]
    public class CadLayer: AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            string s = "";
            var doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            foreach (ModelItem item in doc.CurrentSelection.SelectedItems)
            {
                s += doc.CurrentSelection.SelectedItems.Count;
                foreach (var prop in item.Children)
                {
                    s += prop.DisplayName + '\n';
                }
            }
            string outputFolder;
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dResult = folderBrowser.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                outputFolder = folderBrowser.SelectedPath;
                File.WriteAllText(outputFolder + @"\" + "Output.txt", s);
            }

            return 0;
        }
    }
}
