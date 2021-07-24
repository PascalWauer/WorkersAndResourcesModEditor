using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WorkersAndResourcesModEditor
{
    public static class WRCommands
    {
        public static readonly RoutedUICommand RightClickOnModCommand;
        public static readonly RoutedUICommand ReadModsCommand;
        public static readonly RoutedUICommand SearchCommand;
        public static readonly RoutedUICommand FilterCommand;
        

        static WRCommands()
        {
            RightClickOnModCommand = new RoutedUICommand("Execute RightClickOnModCommand", "RightClickOnModCommand", typeof(WRCommands));
            ReadModsCommand = new RoutedUICommand("Execute ReadModsCommand", "ReadModsCommand", typeof(WRCommands));
            SearchCommand = new RoutedUICommand("Execute SearchCommand", "SearchCommand", typeof(WRCommands));
            FilterCommand = new RoutedUICommand("Execute FilterCommand", "FilterCommand", typeof(WRCommands));
        }
    }
}
