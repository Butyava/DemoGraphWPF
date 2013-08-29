using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoGraphWPF
{
    class GraphViewModel : ViewModelBase
    {
        Graph m_Graph1;
        Graph m_Graph2;

        public bool[,] Matrix
        {
            get { return m_Graph1.m_Matrix; }
            set
            {
                m_Graph1.m_Matrix = value;
                OnPropertyChanged("Matrix");
            }
        }

        public string Name1
        {
            get { return string.Format("{0}.png", m_Graph1.m_Name); }
            set
            {
                m_Graph1.m_Name = value;
                OnPropertyChanged("Name1");
            }
        }

        public string Name2
        {
            get { return string.Format("{0}.png", m_Graph2.m_Name); }
            set
            {
                m_Graph2.m_Name = value;
                OnPropertyChanged("Name2");
            }
        }

        public GraphViewModel(Graph graph1, Graph graph2)
        {
            m_Graph1 = graph1;
            m_Graph2 = graph2;
            m_Graph1.GenerateDotFile();
            m_Graph2.GenerateDotFile();
            m_Graph1.GeneratePngFile();
            m_Graph2.GeneratePngFile();
            
        }
    }
}
