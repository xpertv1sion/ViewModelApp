﻿using System;
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
using ViewModelApp.VM;

namespace ViewModelApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();

        public MainWindow()
        {
            ViewModel = ViewModel.LoadSettings();

            InitializeComponent();
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SaveSettings();

                MessageBox.Show("Settings saved");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
    }
}
