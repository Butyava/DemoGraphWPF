using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Graphviz;
using System.Security;
using System.IO;

namespace DemoGraphWPF
{
    class Graph
    {
        public bool[,] m_Matrix;
        public string m_Name;

        public void GenerateDotFile()
        {
            var graph = new AdjacencyGraph<string, TaggedEdge<string, string>>();

            for (int i = 0; i < Math.Sqrt(Convert.ToDouble(m_Matrix.Length)); i++)
            {
                graph.AddVertex(String.Format("{0}", i));
            }
            for (int i = 0; i < Math.Sqrt(Convert.ToDouble(m_Matrix.Length)); i++)
            {
                for (int j = 0; j < Math.Sqrt(Convert.ToDouble(m_Matrix.Length)); j++)
                {
                    if ((m_Matrix[i, j] == true) & (i < j))
                    {
                        graph.AddEdge(new TaggedEdge<string, string>(String.Format("{0}", i), String.Format("{0}", j), String.Format("{0}", i)));
                    }
                }
            }

            var graphViz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph, @".\", QuickGraph.Graphviz.Dot.GraphvizImageType.Png);
            graphViz.FormatVertex += (sender, e) =>
            {
                e.VertexFormatter.Shape = QuickGraph.Graphviz.Dot.GraphvizVertexShape.Circle;
            };

            graphViz.FormatEdge += (sender, e) =>
            {
                e.EdgeFormatter.Dir = QuickGraph.Graphviz.Dot.GraphvizEdgeDirection.None;
            };

            graphViz.Generate(new FileDotEngine(), m_Name);

        }


        public void GeneratePngFile()
        {
            
            Process m_proc = new Process();

            m_proc.StartInfo.FileName = @"C:\graphviz-2.32\release\bin\dot";
            m_proc.StartInfo.Arguments = string.Format(@"-T png {0}.dot -o {0}.png", m_Name);
            m_proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            m_proc.Start();
            m_proc.WaitForExit();
        }

    }
}
