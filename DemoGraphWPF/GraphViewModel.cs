using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections;


namespace DemoGraphWPF
{
    class GraphViewModel : ViewModelBase
    {
        Graph m_Graph1;
        Graph m_Graph2;
        private DelegateCommand m_GenerateIsomorphicCommand;
        private DelegateCommand m_ProveIsomorphism1Command;
        private DelegateCommand m_ProveIsomorphisn2Command;
       public Graph m_Isomorphic;
        Random m_Random = new Random();
        ObservableCollection<int> m_Condition = new ObservableCollection<int>();
        ObservableCollection<int> m_ConditionIsomorphic = new ObservableCollection<int>();
        public string m_Condition1 = "";

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

        public string NameIsomorphic
        {
            get { return string.Format("{0}.png", m_Isomorphic.m_Name); }
            set
            {
                m_Isomorphic.m_Name = value;
                OnPropertyChanged("NameIsomorphic");
            }
        }

        public string Condition1
        {
            get { return m_Condition1; }
            set
            {
                if (m_Condition1 != null)
                {
                    m_Condition1 = value;
                    OnPropertyChanged("Condition1");
                }
            }
        }

        public ICommand GenerateIsomorphicCommand
        {
            get
            {
                if (m_GenerateIsomorphicCommand == null)
                {
                    m_GenerateIsomorphicCommand = new DelegateCommand(GenerateIsomorphic);
                }
                return m_GenerateIsomorphicCommand;
            }
        }

        public void GenerateIsomorphic()
        {
            int random;
            m_ConditionIsomorphic.Clear();
            for (int i = 0; i < m_Condition.Count; i++)
            {
                for (int j = 0; j < m_Condition.Count; j++)
                {
                    m_Isomorphic.m_Matrix[i, j] = false;
                }
            }
            for (int i = 0; i < (m_Condition.Count - 1); i++)
            {
                random = m_Random.Next((m_Condition.Count - 1));

                if (!(m_ConditionIsomorphic.Contains(random)))
                {
                    m_ConditionIsomorphic.Add(random);
                }
                else
                {
                    i--;
                }

            }
            for (int i = 0; i < m_Condition.Count; i++)
            {
                if (!(m_ConditionIsomorphic.Contains(i)))
                {
                    m_ConditionIsomorphic.Add(i);
                }
            }
            for (int i = 0; i < m_ConditionIsomorphic.Count; i++)
            {
                for (int j = 0; j < m_ConditionIsomorphic.Count; j++)
                {
                    if (m_Graph1.m_Matrix[m_ConditionIsomorphic[i], j] == true)
                    {
                        for (int k = 0; k < m_ConditionIsomorphic.Count; k++)
                        {
                            if (m_ConditionIsomorphic[k] == j)
                            {
                                m_Isomorphic.m_Matrix[i, k] = true;
                            }
                        }

                    }

                }
            }
            m_Isomorphic.GenerateDotFile();
            m_Isomorphic.GeneratePngFile();
        }

        public void ProveIsomorphism1()
        {
            m_Condition1 = "";
            for (int i = 0; i < m_ConditionIsomorphic.Count; i++)
            {
                m_Condition1 = m_Condition1 + m_ConditionIsomorphic[i].ToString() + " ";
            }
        }

        public void ProveIsomorphism2()
        {
            m_Condition1 = "";
            for (int i = 0; i < m_ConditionIsomorphic.Count; i++)
            {
                m_Condition1 = m_Condition1 + m_Condition[m_ConditionIsomorphic[i]].ToString() + " ";
            }
        }

        public GraphViewModel(Graph graph1, Graph graph2, ObservableCollection<int> condition, Graph isomorphic)
        {
            m_Graph1 = graph1;
            m_Graph2 = graph2;
            m_Isomorphic = isomorphic;
            m_Condition = condition;
            m_Graph1.GenerateDotFile();
            m_Graph2.GenerateDotFile();
            m_Graph1.GeneratePngFile();
            m_Graph2.GeneratePngFile();
            //m_Isomorphic.m_Name = @"C:\graphviz-2.32\release\bin\m_isomorphic";
        }
    }
}
