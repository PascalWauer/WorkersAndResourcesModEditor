using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WorkersAndResourcesModEditor
{
    public class UIManager
    {
        public UIModels UIModel { get; set; }
        public MainWindow MainWindow { get; set; }
        private List<FileInfo> m_ModFiles { get; set; }
        public UIManager()
        {
            MainWindow = new MainWindow();
            UIModel = new UIModels();

            MainWindow.DataContext = UIModel;
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.RightClickOnModCommand, this.ExecuteRightClickOnModCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.ReadModsCommand, this.ExecuteReadModsCommand, this.CanExecuteReadModsCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.SearchCommand, this.ExecuteSearchCommand, this.CanExecuteSearchCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.FilterCommand, this.ExecuteFilterCommand, this.CanExecuteFilterCommand));

            m_ModFiles = new List<FileInfo>();

            MainWindow.Show();

        }

        private void CanExecuteFilterCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExecuteFilterCommand(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CanExecuteSearchCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(this.UIModel.Search);
        }

        private void ExecuteSearchCommand(object sender, ExecutedRoutedEventArgs e)
        {
            UIModel.SetFilters();
        }

        private void CanExecuteReadModsCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }

        private void ExecuteReadModsCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (!Directory.Exists(UIModel.ModPath))
            {
                MessageBox.Show("Enter a valid folder path for the Workers and Resources mods to read", "No valid folder", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DirectoryInfo di = new DirectoryInfo(UIModel.ModPath);

            List<FileInfo> tmpModFiles = new List<FileInfo>();
            m_ModFiles.AddRange(di.GetFiles("building.ini", SearchOption.AllDirectories));

            this.UIModel.UIModelBuildingList.Clear();

            foreach(FileInfo file in m_ModFiles)
            {
                this.UIModel.UIModelBuildingList.Add(IniReader.ReadBuildingIni(file.FullName));
            }
        }

        private void ExecuteRightClickOnModCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.MainWindow.DG_Mods.SelectedCells.Count == 1)
            {
                DataGridCellInfo dataGridCell = this.MainWindow.DG_Mods.SelectedCells[0];
                var item = dataGridCell.Item as UIModelBuildingIni;
                Process.Start("notepad.exe", item.FilePath);
            }
        }
    }
}
