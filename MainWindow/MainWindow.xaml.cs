using System;
using System.Windows;

namespace task1_c
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new RealNumberViewModel();
        }
    }
}
