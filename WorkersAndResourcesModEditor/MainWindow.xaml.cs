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

namespace WorkersAndResourcesModEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }
        private void OnMainWindowCellRightClick(object sender, MouseButtonEventArgs e)
        {
            WRCommands.RightClickOnModCommand.Execute(null, this);
        }

        private void KeyPressedOnSearchBox(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                WRCommands.SearchCommand.Execute(null, this); 
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WRCommands.MouseDoubleClickCommand.Execute(null, this);
        }
    }
}
