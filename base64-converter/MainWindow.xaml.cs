using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.IO;

namespace base64_ui
{
    public partial class MainWindow : Window
    {
        string path;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EncodeBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
                filePath.Content = path;
                byte[] encode = File.ReadAllBytes(path);
                string newfile = Convert.ToBase64String(encode);
                File.WriteAllText("encoded.txt", newfile);
                MessageBox.Show("Output wirtten to \"encoded.txt\"", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void DecodeBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
                filePath.Content = path;
                try
                {
                    string bytes = File.ReadAllText(path);
                    byte[] newfile = Convert.FromBase64String(bytes);
                    File.WriteAllBytes("decoded.txt", newfile);
                    MessageBox.Show("Output written to \"decoded.txt\"", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                catch
                {
                    MessageBox.Show("File isn't encoded!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window1.DragMove();
        }
    }
}
