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
    }
}
