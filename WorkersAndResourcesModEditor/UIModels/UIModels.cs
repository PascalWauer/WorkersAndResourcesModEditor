using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;

namespace WorkersAndResourcesModEditor
{
    public class UIModels : INotifyPropertyChanged
    {
        private string m_ModPath;

        public string ModPath
        {
            get { return m_ModPath; }
            set 
            { 
                m_ModPath = value;
                NotifyPropertyChanged();
            }
        }
        private string m_Search;

        public string Search
        {
            get { return m_Search; }
            set
            {
                m_Search = value;
                NotifyPropertyChanged();
            }
        }

        private ICollectionView m_UIModelBuildingListDataView { get; set; }
        private ObservableCollection<UIModelBuildingIni> m_UIModelBuildingList { get; set; }
        public ObservableCollection<UIModelBuildingIni> UIModelBuildingList
        {
            get
            {
                if (m_UIModelBuildingList == null)
                {
                    m_UIModelBuildingListDataView = CollectionViewSource.GetDefaultView(m_UIModelBuildingList);
                    m_UIModelBuildingListDataView.Filter = FilterUIModelBuildingList;
                }
                return m_UIModelBuildingList;
            }
            set
            {
                m_UIModelBuildingList = value;
                m_UIModelBuildingListDataView = CollectionViewSource.GetDefaultView(m_UIModelBuildingList);
                m_UIModelBuildingListDataView.Filter = FilterUIModelBuildingList;
            }
        }


        public UIModels()
        {
            this.ModPath = @"Z:\Spiele\Steam\steamapps\workshop\content\784150";
            UIModelBuildingList = new ObservableCollection<UIModelBuildingIni>();
        }

        public void SetFilters()
        {
            m_UIModelBuildingListDataView.Filter = this.FilterUIModelBuildingList; 
        }

        private bool FilterUIModelBuildingList(object item)
        {

            UIModelBuildingIni building = item as UIModelBuildingIni;
           
            if (this.Search == null || (this.Search != null && (building.BuildingName.ToLower().Contains(this.Search.ToLower()) || building.Type.ToLower().Contains(Search.ToLower()))))
                return true;
            else
                return false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

