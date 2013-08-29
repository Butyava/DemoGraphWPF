using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoGraphWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow view = new MainWindow();

            Graph m_Gr1 = new Graph();
            Graph m_Gr2 = new Graph();
            m_Gr1.m_Matrix = new bool[,]  {{false, false, false,false , true, true, true, false},
            {false, false, false,false ,true, true,false,true}, {false, false, false,false ,true, false, true, true},
            {false, false, false,false ,false, true, true, true}, {true, true, true, false, false, false, false,false},
            {true, true, false, true, false, false, false,false}, { true, false, true, true, false, false, false,false},
            {false,true, true, true,false, false, false,false }};
            m_Gr2.m_Matrix = new bool[,] {{false, true, false, true, true, false, false, false},
                                           {true, false, true, false, false, true, false, false},
                                           {false, true, false, true, false, false, true, false},
                                           {true, false, true, false, false, false, false, true},
                                           {true, false, false, false, false, true, false, true},
                                           {false, true, false, false, true, false, true, false},
                                           {false, false, true, false, false, true, false, true},
                                           {false, false, false, true, true, false, true, false}};
            m_Gr1.m_Name = @"C:\graphviz-2.32\release\bin\m_graph1";
            m_Gr2.m_Name = @"C:\graphviz-2.32\release\bin\m_graph2";
            GraphViewModel viewModel = new GraphViewModel(m_Gr1, m_Gr2);

            view.DataContext = viewModel;


            view.Show();

        }
    }
}
