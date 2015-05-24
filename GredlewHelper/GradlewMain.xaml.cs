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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GredlewHelper
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startProcess(String command)
        {
            listBoxOutput.Items.Clear();
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.Arguments = "/C " + command;
            pro.StartInfo.UseShellExecute = false;
//            pro.StartInfo.CreateNoWindow = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError  = true;
            
            pro.Start();
            string output = pro.StandardOutput.ReadToEnd();
            string error = pro.StandardError.ReadToEnd();
            if(output != null){
                listBoxOutput.Items.Add(output);
            }
            if (error != null)
            {
                listBoxOutput.Items.Add(error);
            }
        }

        private void butC_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew runClient");
        }

        private void butS_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew runServer");
        }

        private void butBuild_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew build");
        }

        private void butGui_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew --gui");
        }

        private void butOther_Click(object sender, RoutedEventArgs e)
        {
//            new GradlewOther().ShowDialog();
            doGradlewOther(true);
        }

        private void expanderOutput_Collapsed(object sender, RoutedEventArgs e)
        {
            var ani = new DoubleAnimationUsingKeyFrames();
            ani.KeyFrames.Add(new LinearDoubleKeyFrame(MainWindow1.ActualWidth, TimeSpan.FromSeconds(0)));
            ani.KeyFrames.Add(new LinearDoubleKeyFrame(570, TimeSpan.FromSeconds(0.2)));
            MainWindow1.BeginAnimation(FrameworkElement.WidthProperty, ani);
        }

        private void expanderOutput_Expanded(object sender, RoutedEventArgs e)
        {
            var ani = new DoubleAnimationUsingKeyFrames();
            ani.KeyFrames.Add(new LinearDoubleKeyFrame(MainWindow1.ActualWidth, TimeSpan.FromSeconds(0)));
            ani.KeyFrames.Add(new LinearDoubleKeyFrame(1000, TimeSpan.FromSeconds(0.2)));
            MainWindow1.BeginAnimation(FrameworkElement.WidthProperty, ani);
        }
        private void doGradlewOther(bool create) {
            var aniW = new DoubleAnimationUsingKeyFrames();
            var aniG = new DoubleAnimationUsingKeyFrames();
            aniW.KeyFrames.Add(new LinearDoubleKeyFrame(MainWindow1.ActualHeight, TimeSpan.FromSeconds(0)));
            aniW.KeyFrames.Add(new LinearDoubleKeyFrame(create ? 400 : 350, TimeSpan.FromSeconds(0.2)));
            aniG.KeyFrames.Add(new LinearDoubleKeyFrame(create ? 0 : 50, TimeSpan.FromSeconds(0)));
            aniG.KeyFrames.Add(new LinearDoubleKeyFrame(create ? 50 : 0, TimeSpan.FromSeconds(0.2)));
            MainWindow1.BeginAnimation(FrameworkElement.HeightProperty, aniW);
            gridOther.BeginAnimation(FrameworkElement.HeightProperty, aniG);
        }

        private void butClose_Click(object sender, RoutedEventArgs e)
        {
            doGradlewOther(false);
        }

        private void butProcess_Click(object sender, RoutedEventArgs e)
        {
            String com = txtboxArg.Text;
            com = "gradlew " + com;
            startProcess(com);
            txtboxArg.Text = "";
            doGradlewOther(false);
        }

        private void butDecomp_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew setupDecompWorkspace");
        }

        private void butDev_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew setupDevWorkspace");
        }

        private void butCI_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew setupCIWorkspace");
        }

        private void butEclipse_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew eclipse");
        }

        private void butEclipseClean_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew cleanEclipse");
        }

        private void butIdea_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew idea");
        }

        private void butIdeaClean_Click(object sender, RoutedEventArgs e)
        {
            startProcess(@"gradlew cleanIdea");
        }
    }
}
