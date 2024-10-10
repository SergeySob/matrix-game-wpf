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

namespace matrix_game_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Data
        {
            public int step { get; set; }
            public string p1method { get; set; }
            public string p2method { get; set; }
            public int p1A { get; set; }
            public int p1B { get; set; }
            public int p1C { get; set; }
            public int p2a { get; set; }
            public int p2b { get; set; }
            public int p2y { get; set; }
            public double vl1 { get; set; }
            public double vl2 { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cellAa = Convert.ToInt16(tbAa.Text), cellAb = Convert.ToInt16(tbAb.Text), cellAy = Convert.ToInt16(tbAy.Text);
            int cellBa = Convert.ToInt16(tbBa.Text), cellBb = Convert.ToInt16(tbBb.Text), cellBy = Convert.ToInt16(tbBy.Text);
            int cellCa = Convert.ToInt16(tbCa.Text), cellCb = Convert.ToInt16(tbCb.Text), cellCy = Convert.ToInt16(tbCy.Text);

            string strategyA = "A", strategyB = "B", strategyC = "C";
            string strategya = "a", strategyb = "b", strategyy = "y";

            int step;    string player1method, player2method;   int player1A, player1B, player1C;   int player2a, player2b, player2y;    double vl1, vl2;

            player1A = cellAa; player1B = cellBa; player1C = cellCa; player2a = cellAa; player2b = cellAb; player2y = cellAy;


            var data = new List<Data>();

            

            vl1 = Math.Max(Convert.ToDouble(player1A), Math.Max(Convert.ToDouble(player1B), Convert.ToDouble(player1C))) / Convert.ToDouble(1);
            vl2 = Math.Min(Convert.ToDouble(player2a), Math.Min(Convert.ToDouble(player2b), Convert.ToDouble(player2y))) / Convert.ToDouble(1);

            data.Add(new Data
            {
                step = 1,
                p1method = "A",
                p2method = "a",
                p1A = player1A,
                p1B = player1B,
                p1C = player1C,
                p2a = player2a,
                p2b = player2b,
                p2y = player2y,
                vl1 = vl1,
                vl2 = vl2
            });

            for (int i = 2; i <= 20; i++)
            {
                if (Math.Max(player1A, Math.Max(player1B, player1C)) == player1A)
                {
                    player1method = strategyA;
                }
                else if (Math.Max(player1A, Math.Max(player1B, player1C)) == player1B)
                {
                    player1method = strategyB;
                }
                else
                {
                    player1method = strategyC;
                }

                if (Math.Min(player2a, Math.Min(player2b, player2y)) == player2a)
                {
                    player2method = strategya;
                }
                else if (Math.Min(player2a, Math.Min(player2b, player2y)) == player2b)
                {
                    player2method = strategyb;
                }
                else
                {
                    player2method = strategyy;
                }

                //p1
                if (player2method == strategya)
                {
                    player1A += cellAa;
                    player1B += cellBa;
                    player1C += cellCa;
                }
                else if (player2method == strategyb)
                {
                    player1A += cellAb;
                    player1B += cellBb;
                    player1C += cellCb;
                }
                else
                {
                    player1A += cellAy;
                    player1B += cellBy;
                    player1C += cellCy;
                }



                //p2
                if (player1method == strategyA)
                {
                    player2a += cellAa;
                    player2b += cellAb;
                    player2y += cellAy;
                }
                else if (player1method == strategyB)
                {
                    player2a += cellBa;
                    player2b += cellBb;
                    player2y += cellBy;
                }
                else
                {
                    player2a += cellCa;
                    player2b += cellCb;
                    player2y += cellCy;
                }


                vl1 = Math.Max(Convert.ToDouble(player1A), Math.Max(Convert.ToDouble(player1B), Convert.ToDouble(player1C))) / Convert.ToDouble(i);
                vl2 = Math.Min(Convert.ToDouble(player2a), Math.Min(Convert.ToDouble(player2b), Convert.ToDouble(player2y))) / Convert.ToDouble(i);

                

                data.Add(new Data
                {
                    step = i,
                    p1method = player1method,
                    p2method = player2method,
                    p1A = player1A,
                    p1B = player1B,
                    p1C = player1C,
                    p2a = player2a,
                    p2b = player2b,
                    p2y = player2y,
                    vl1 = vl1,
                    vl2 = vl2
                });
            }

            dgMatrix.ItemsSource = data;
            
        }

        
    }
}
