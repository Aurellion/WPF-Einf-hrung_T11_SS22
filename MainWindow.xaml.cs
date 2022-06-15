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

namespace WPF_Einführung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button btn = new Button();
            btn.FontWeight = FontWeights.Bold;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.Width = 150;
            btn.Height = 20;

            WrapPanel pnl = new WrapPanel();

            TextBlock text1 = new TextBlock();
            text1.Text = "Multi";
            text1.Foreground = Brushes.Red;
            TextBlock text2 = new TextBlock();
            text2.Text = "Color";
            text2.Foreground = Brushes.Blue;
            TextBlock text3 = new TextBlock();
            text3.Text = "Button";

            pnl.Children.Add(text1);
            pnl.Children.Add(text2);
            pnl.Children.Add(text3);

            btn.Content = pnl;
            btn.Click += Button_Click;

            grid.Children.Add(btn);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Button wurde geklickt.","Klick!");

            //Aufgabe: Mit Klick auf den Button soll sich die Hintergrundfarbe
            //         des Fensters (Grid) ändern, beim nächsten Klick wieder
            //         zurücksetzen usw...

            //if (grid.Background == Brushes.Aqua)
            //{
            //    grid.Background = Brushes.White;
            //}
            //else
            //{
            //    grid.Background = Brushes.Aqua;
            //}

            //Zufällige Farbe
            Random rnd = new Random();
            grid.Background = 
                new SolidColorBrush(
                    Color.FromRgb(
                        (byte)rnd.Next(0, 256),
                        (byte)rnd.Next(0, 256),
                        (byte)rnd.Next(0, 256)
                        )
                    );
        }

        private void btnLZ_Click(object sender, RoutedEventArgs e)
        {
            LeerzeichenEntfernen();
        }

        private void LeerzeichenEntfernen()
        {
            string eingabe = tbxEingabe.Text;
            string ausgabe = eingabe.Replace(" ", "");
            tbxAusgabe.Text = ausgabe;
        }

        private void tbxEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter) LeerzeichenEntfernen();
        }

        private void tbxEingabe_TextChanged(object sender, TextChangedEventArgs e)
        {
            LeerzeichenEntfernen();
        }

        //Aufgabe
        //Erstellen Sie Eingabelogik, Methoden und Ausgabe zur
        //Nullstellenbestimmung quadratischer Funktionen (in R).

        private void Berechnen()
        {
            double a, b, c, p, q, D;
            if(!Double.TryParse(tbxA.Text, out a)) return;
            if(!Double.TryParse(tbxB.Text, out b)) return;
            if(!Double.TryParse(tbxC.Text, out c)) return;
            p = b / a;
            q = c / a;
            D = p * p / 2 - q;
            if (D < 0) tbxNst.Text = $"Es existieren keine reellen Nullstellen.";
            else if (D == 0)
            {
                double xn = -p * p / 2;
                tbxNst.Text = $"Die doppelte Nullstelle von f ist x_n={xn}.";
            }
            else
            {
                double x1, x2;
                x1 = -p * p / 2 + Math.Sqrt(D);
                x2 = -p * p / 2 - Math.Sqrt(D);
                tbxNst.Text = $"Die Nullstellen sind x1={x1} und x2={x2}.";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Berechnen();
        }
    }
}
