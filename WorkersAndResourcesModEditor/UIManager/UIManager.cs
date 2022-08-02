using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WorkersAndResourcesModEditor
{
    public class UIManager
    {
        public UIModel UIModel { get; set; }
        public MainWindow MainWindow { get; set; }
        private List<FileInfo> m_ModFiles { get; set; }
        public UIManager()
        {
            MainWindow = new MainWindow();
            UIModel = new UIModel();

            MainWindow.DataContext = UIModel;
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.RightClickOnModCommand, this.ExecuteRightClickOnModCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.MouseDoubleClickCommand, this.ExecuteMouseDoubleClickCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.ReadModsCommand, this.ExecuteReadModsCommand, this.CanExecuteReadModsCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.SearchCommand, this.ExecuteSearchCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.FilterCommand, this.ExecuteFilterCommand, this.CanExecuteFilterCommand));
            MainWindow.CommandBindings.Add(new CommandBinding(WRCommands.ToWIPCommand, this.ExecuteToWIPCommand, this.CanExecuteToWIPCommand));

            m_ModFiles = new List<FileInfo>();
            ReadConfig();
            MainWindow.Show();

        }

        private void ExecuteMouseDoubleClickCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridCellInfo dataGridCell = this.MainWindow.DG_Mods.SelectedCells[0];
            var item = dataGridCell.Item as UIModelBuildingIni;
            DirectoryInfo dir = GetModFolderPath(new DirectoryInfo(item.FilePath), item.WorkshopID);
            Process.Start("explorer.exe", dir.FullName);
        }

        private void CanExecuteToWIPCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecuteToWIPCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var WipList = this.UIModel.UIModelBuildingList.Where(x => x.WIP).ToList();
            foreach (var item in WipList)
            {
                DirectoryInfo dir = GetModFolderPath(new DirectoryInfo(item.FilePath), item.WorkshopID);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + item.FilePath);
                }
                DirectoryInfo[] dirs = dir.GetDirectories();

                // If the destination directory doesn't exist, create it.       
                Directory.CreateDirectory(UIModel.WIPPath + "\\" + item.WorkshopID);

                //FileInfo[] files = dir.GetFiles();

                CopyAll(dir, Directory.CreateDirectory(UIModel.WIPPath + "\\" + item.WorkshopID));
            }
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                if (!File.Exists(Path.Combine(target.FullName, fi.Name)))
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), false);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private DirectoryInfo GetModFolderPath(DirectoryInfo dir, string WorkshopID)
        {
            DirectoryInfo ParentFolder = dir.Parent;
            string[] ModFolderArray = ParentFolder.FullName.Split("\\");

            if (ModFolderArray[ModFolderArray.Length - 1] == WorkshopID)
            {
                return ParentFolder;
            }
            else
                return GetModFolderPath(dir.Parent, WorkshopID);
        }
        private void CanExecuteFilterCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExecuteFilterCommand(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void ExecuteSearchCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (UIModel.Search == "createresearch")
            {
                ResearchFileWriter.WriteResearchFile();
                Process.Start("explorer.exe", Environment.CurrentDirectory);
            }
            else
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

            if(!UIModel.ModPath.Contains("784150"))
            {
                MessageBox.Show("This is not the correct mods path. The mods folder is named 784150");
                return;
            }
            this.MainWindow.Cursor = Cursors.Wait;

            ResearchFileWriter.RecreateResearchList();
            DirectoryInfo di = new DirectoryInfo(UIModel.ModPath);

            List<FileInfo> tmpModFiles = new List<FileInfo>();
            m_ModFiles.Clear();
            m_ModFiles.AddRange(di.GetFiles("building.ini", SearchOption.AllDirectories));

            this.UIModel.UIModelBuildingList.Clear();

            string errorMessage = "";
            foreach(FileInfo file in m_ModFiles)
            {
                this.UIModel.UIModelBuildingList.Add(IniReader.ReadBuildingIni(file.FullName, ref errorMessage));
            }
            if (errorMessage.Length > 1)
                MessageBox.Show(errorMessage);

            this.MainWindow.Cursor = Cursors.Arrow;
            WriteConfigFile();
        }

        private void ReadConfig()
        {
            string path = Environment.CurrentDirectory;
            if (File.Exists(Path.Combine(path, "Config.txt")))
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path, "Config.txt")))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("Mods folder: "))
                            UIModel.ModPath = line.Substring(13);
                        if (line.Contains("WIP folder: "))
                            UIModel.WIPPath = line.Substring(12);
                    }
                }
            }
        }
        private void WriteConfigFile()
        {
            string path = Environment.CurrentDirectory;
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, "Config.txt")))
            {
                sw.WriteLine("Mods folder: " + UIModel.ModPath);
                sw.WriteLine("WIP folder: " + UIModel.WIPPath);
            }
        }

        private void ExecuteRightClickOnModCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.MainWindow.DG_Mods.SelectedCells.Count >= 1)
            {
                DataGridCellInfo dataGridCell = this.MainWindow.DG_Mods.SelectedCells[0];
                var item = dataGridCell.Item as UIModelBuildingIni;
                if (File.Exists(@"C:\Program Files (x86)\Notepad++\notepad++.exe"))
                    Process.Start(@"C:\Program Files (x86)\Notepad++\notepad++.exe", item.FilePath);
                else
                    Process.Start("notepad.exe", item.FilePath);
            }
        }
    }
}
