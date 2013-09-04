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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DemoGraphWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GraphViewModel ViewModel { get { return ((GraphViewModel)DataContext); } }

        private void Click1(object sender, RoutedEventArgs e)
        {
            
            ViewModel.GenerateIsomorphic();
            ImageSourceConverter imgConv = new ImageSourceConverter();
            string path = string.Format("{0}.png", ViewModel.m_Isomorphic.m_Name);
            ImageSource imageSource = (ImageSource)imgConv.ConvertFromString(path);
            Image3.Source = imageSource;
            if (ViewModel.m_Isomorphic.m_Name == @"C:\graphviz-2.32\release\bin\m_isomorphic")
            {
                File.Delete(@"C:\graphviz-2.32\release\bin\m_isomorphic2");
                ViewModel.m_Isomorphic.m_Name = @"C:\graphviz-2.32\release\bin\m_isomorphic2";

            }
            else if (ViewModel.m_Isomorphic.m_Name == @"C:\graphviz-2.32\release\bin\m_isomorphic3")
            {
                File.Delete(@"C:\graphviz-2.32\release\bin\m_isomorphic");
                ViewModel.m_Isomorphic.m_Name = @"C:\graphviz-2.32\release\bin\m_isomorphic";
            }

            else if (ViewModel.m_Isomorphic.m_Name == @"C:\graphviz-2.32\release\bin\m_isomorphic2")
            {
                File.Delete(@"C:\graphviz-2.32\release\bin\m_isomorphic3");
                ViewModel.m_Isomorphic.m_Name = @"C:\graphviz-2.32\release\bin\m_isomorphic3";
            }
        }

        private void Click2(object sender, RoutedEventArgs e)
        {
            ViewModel.ProveIsomorphism1();
            TextBlock2.Text = ViewModel.m_Condition1;
        }

        private void Click3(object sender, RoutedEventArgs e)
        {
            ViewModel.ProveIsomorphism2();
            TextBlock2.Text = ViewModel.m_Condition1;
        }

        public MainWindow()
        {
            InitializeComponent();
        }




    }
}
