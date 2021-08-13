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
        private string m_WIPPath;

        public string WIPPath
        {
            get { return m_WIPPath; }
            set 
            { 
                m_WIPPath = value;
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

        #region Filters

        private bool m_Factories;
        public bool Factories
        {
            get { return m_Factories; }
            set
            {
                m_Factories = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Residential;
        public bool Residential
        {
            get { return m_Residential; }
            set
            {
                m_Residential = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Storage;
        public bool Storage
        {
            get { return m_Storage; }
            set
            {
                m_Storage = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Connectors;
        public bool Connectors
        {
            get { return m_Connectors; }
            set
            {
                m_Connectors = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Education;
        public bool Education
        {
            get { return m_Education; }
            set
            {
                m_Education = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_FireHealth;
        public bool FireHealth
        {
            get { return m_FireHealth; }
            set
            {
                m_FireHealth = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Shop;
        public bool Shop
        {
            get { return m_Shop; }
            set
            {
                m_Shop = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Power;
        public bool Power
        {
            get { return m_Power; }
            set
            {
                m_Power = value;
                NotifyPropertyChanged();
            }
        }

        private bool m_Entertain;

        public bool Entertain
        {
            get { return m_Entertain; }
            set
            {
                m_Entertain = value;
                NotifyPropertyChanged();
            }
        }


        private bool m_Attraction;

        public bool Attraction
        {
            get { return m_Attraction; }
            set
            {
                m_Attraction = value;
                NotifyPropertyChanged();
            }
        }


        private bool m_CityHall;

        public bool CityHall
        {
            get { return m_CityHall; }
            set
            {
                m_CityHall = value;
                NotifyPropertyChanged();
            }
        }


        private bool m_Heating;

        public bool Heating
        {
            get { return m_Heating; }
            set
            {
                m_Heating = value;
                NotifyPropertyChanged();
            }
        }


        private bool m_Office;

        public bool Office
        {
            get { return m_Office; }
            set
            {
                m_Office = value;
                NotifyPropertyChanged();
            }
        }


        private bool m_Station;

        public bool Station
        {
            get { return m_Station; }
            set
            {
                m_Station = value;
                NotifyPropertyChanged();
            }
        }


        private bool m_Others;
        public bool Others
        {
            get { return m_Others; }
            set
            {
                m_Others = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

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
            //Z:\Spiele\Steam\steamapps\workshop\content\784150
            this.ModPath = @"Z:\Spiele\Steam\steamapps\workshop\content\784150";
            this.WIPPath = @"Z:\Spiele\Steam\steamapps\common\SovietRepublic\media_soviet\workshop_wip";
            UIModelBuildingList = new ObservableCollection<UIModelBuildingIni>();
        }

        public void SetFilters()
        {
            m_UIModelBuildingListDataView.Filter = this.FilterUIModelBuildingList; 
        }

        private bool FilterUIModelBuildingList(object item)
        {
            UIModelBuildingIni building = item as UIModelBuildingIni;

            if (this.Factories && (building.Type == "factory" || building.Type == "production_line") 
                || this.Storage && building.Type == "storage" 
                || this.FireHealth && (building.Type == "firestation" || building.Type == "hospital") 
                || this.Residential && building.Type == "living" 
                || this.Education && (building.Type == "school" || building.Type == "university" || building.Type == "kindergarten") 
                || this.Power && (building.Type == "transformator" || building.Type == "powerplant" || building.Type == "rail_trafo") 
                || this.Shop && (building.Type == "shop" || building.Type == "pub") 
                || this.Connectors && (building.Type == "heating_switch" || building.Type == "engine")
                || this.Station && (building.Type == "passanger_station" || building.Type == "cargo_station")
                || this.Entertain && (building.Type == "church" || building.Type == "kino" || building.Type == "sport")
                || this.Others && (building.Type == "monument" || building.Type == "gas_station" || building.Type == "pollution_meter")
                || this.Attraction && (building.Type == "attraction" || building.Type =="hotel")
                || this.Office && (building.Type == "distribution_office" || building.Type == "garbage_office" || building.Type == "forklift_garage")
                || this.CityHall && building.Type == "cityhall"
                || this.Heating && building.Type == "heating_plant"
                || (!this.Factories && !this.Education && !this.Connectors && !this.FireHealth && !this.Power && !this.Residential && !this.Shop && !this.Storage && !this.Heating && !this.Entertain && !this.CityHall && !this.Attraction && !this.Office && !this.Station && !this.Others)
                )
            /* missing types: 
                church, kino, sport -> entertainment/church
                cargo_station -> cargo station 
                city_hall -> city hall 
                distribution_office, garbage_office -> DO/TO 
                forklift_garage -> forklift 
                gas_station -> others 
                hotel -> attractio 
                pollution_meter -> others  
                passanger_station -> passenger station
            */
            {
                if (this.Search == null || (this.Search != null && building.BuildingName != null && (building.BuildingName.ToLower().Contains(this.Search.ToLower()) || building.Type.ToLower().Contains(Search.ToLower()))))
                    return true;
                else
                    return false;
            }
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

