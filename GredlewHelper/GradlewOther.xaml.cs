using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GredlewHelper
{
    /// <summary>
    /// GradlewOther.xaml 的互動邏輯
    /// </summary>
    public partial class GradlewOther : Window
    {
        public GradlewOther()
        {
            InitializeComponent();
        }
        private void startProcess(String command)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.Arguments = "/C " + command;
            pro.StartInfo.UseShellExecute = false;
            pro.Start();
        }
        private void butProcess_Click(object sender, RoutedEventArgs e)
        {
            String com = txtboxArg.Text;
            com = "gradlew " + com;
            startProcess(com);
            txtboxArg.Text = "";
            this.Close();
        }
    }
}
