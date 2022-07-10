using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace WorkersAndResourcesModEditor
{
    public class UIModelWareAmount : INotifyPropertyChanged
    {

        private string m_Ware;

        public string Ware
        {
            get { return m_Ware; }
            set
            {
                if (m_Ware != value)
                {
                    m_Ware = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private double m_Amount;

        public double Amount
        {
            get { return m_Amount; }
            set
            {
                if (m_Amount != value)
                {
                    m_Amount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public UIModelWareAmount(string ware, double amount)
        {
            Ware = ware;
            Amount = amount;
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
    public class UIModelBuildingIni : INotifyPropertyChanged
    {
        private int m_Workers_Capacity;
        private string m_WorkshopID;
        private string m_ModID;
        private string m_ObjectName;
        private string m_BuildName;
        private string m_FilePath;
        private string m_Category;
        private string m_Type;
        private string m_SubType;
        private double m_Quality;
        private int m_WorkersNeeded;
        private string m_Heating;
        private double m_StorageCapacityOpen;
        private double m_StorageCapacityCovered;
        private double m_StorageCapacityLivestock;
        private double m_StorageCapacityCement;
        private double m_StorageCapacityCooler;
        private double m_StorageCapacityPassenger;
        private double m_StorageCapacityGravel;
        private double m_StorageCapacityConcrete;
        private double m_StorageCapacityVehicles;
        private double m_StorageCapacityOil;
        private double m_StorageCapacityGeneral;
        private double m_StorageCapacityNuclear1;
        private double m_StorageCapacityNuclear2;
        private double m_StorageCapacityWater;
        private double m_StorageCapacitySewage;
        private string m_StorageSpecialID1;
        private double m_StorageSpecial1Capacity;
        private string m_StorageSpecialID2;
        private double m_StorageSpecial2Capacity;
        private double m_ElectronicLiving;
        private double m_ElectronicWorking;
        private double m_ElectronicLightning;
        private double m_ProductionWind;
        private double m_ProductionSun;
        public int Workers_Capacity
        {
            get { return m_Workers_Capacity; }
            set 
            { 
                m_Workers_Capacity = value;
                this.NotifyPropertyChanged();
            }
        }
        public string WorkshopID
        {
            get { return m_WorkshopID; }
            set
            {
                m_WorkshopID = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool m_WIP;
        public bool WIP
        {
            get { return m_WIP; }
            set
            {
                m_WIP = value;
                NotifyPropertyChanged();
            }
        }

        public string ModID
        {
            get { return m_ModID; }
            set
            {
                m_ModID = value;
                this.NotifyPropertyChanged();
            }
        }        
        public string ObjectName
        {
            get { return m_ObjectName; }
            set
            {
                m_ObjectName = value;
                this.NotifyPropertyChanged();
            }
        }
        public string BuildingName
        {
            get { return m_BuildName; }
            set
            {
                m_BuildName = value;
                this.NotifyPropertyChanged();
            }
        }
        public string FilePath
        {
            get { return m_FilePath; }
            set
            {
                m_FilePath = value;
                this.NotifyPropertyChanged();
            }
        }

        public string PreviewImage
        {
            get 
            { 
                return this.GetModFolderPath(new DirectoryInfo(this.FilePath), this.WorkshopID).FullName + @"\previewimage.png"; 
            }
        }

        public string Category
        {
            get { return m_Category; }
            set
            {
                m_Category = value;
                this.NotifyPropertyChanged();
            }
        }
        public string Type
        {
            get { return m_Type; }
            set
            {
                m_Type = value;
                this.NotifyPropertyChanged();
            }
        }        
        public string SubType
        {
            get { return m_SubType; }
            set
            {
                m_SubType = value;
                this.NotifyPropertyChanged();
            }
        }
        public double Quality
        {
            get { return m_Quality; }
            set
            {
                m_Quality = value;
                this.NotifyPropertyChanged();
            }
        }
        public int Workers_Needed
        {
            get { return m_WorkersNeeded; }
            set
            {
                m_WorkersNeeded = value;
                this.NotifyPropertyChanged();
            }
        }

        private double m_CitizensServe;

        public double CitizensServe
        {
            get { return m_CitizensServe; }
            set
            {
                if (m_CitizensServe != value)
                {
                    m_CitizensServe = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<UIModelWareAmount> _ProductionList;
        public ObservableCollection<UIModelWareAmount> ProductionList
        {
            get { return _ProductionList; }
            set
            {
                if (_ProductionList != value)
                {
                    if (_ProductionList != value)
                    {
                        _ProductionList = value;
                        this.NotifyPropertyChanged();
                    }
                }
            }
        }

        public string ProductionSorting
        {
            get 
            {
                if (ProductionList.Count > 0)
                    return ProductionList[0].Ware + ProductionList[0].Amount;
                else
                    return string.Empty;
            }
        }

        private ObservableCollection<UIModelWareAmount> _ConsumptionList;
        public ObservableCollection<UIModelWareAmount> ConsumptionList
        {
            get { return _ConsumptionList; }
            set
            {
                if (_ConsumptionList != value)
                {
                    if (_ConsumptionList != value)
                    {
                        _ConsumptionList = value;
                        this.NotifyPropertyChanged();
                    }
                }
            }
        }

        private bool m_Skin;
        public bool Skin
        {
            get { return m_Skin; }
            set
            {
                m_Skin = value;
                NotifyPropertyChanged();
            }
        }

        private double m_PriceConsumption;
        private double m_PriceProduction;
        public double PriceConsumption
        {
            get { return m_PriceConsumption; }
        }
        public double PriceProduction
        {
            get { return m_PriceProduction; }
        }
        private double m_Margin;
        public double Margin
        {
            get {
                    return m_Margin;
                }
        }
        public string ConsumptionSorting
        {
            get
            {
                if (ConsumptionList.Count > 0)
                    return ConsumptionList[0].Ware + ConsumptionList[0].Amount;
                else
                    return string.Empty;
            }
        }

        private double m_AttractiveScore;

        public double AttractiveScore
        {
            get { return m_AttractiveScore; }
            set
            {
                m_AttractiveScore = value;
                NotifyPropertyChanged();
            }
        }
        private double m_LoyaltyRadius;

        public double LoyaltyRadius
        {
            get { return m_LoyaltyRadius; }
            set
            {
                m_LoyaltyRadius = value;
                NotifyPropertyChanged();
            }
        }
        private double m_LoyaltyStrength;

        public double LoyaltyStrength
        {
            get { return m_LoyaltyStrength; }
            set
            {
                m_LoyaltyStrength = value;
                NotifyPropertyChanged();
            }
        }

        public double ElectronicLiving
        {
            get { return m_ElectronicLiving; }
            set 
            { 
                m_ElectronicLiving = value;
                NotifyPropertyChanged();
            }
        }

        public double ElectronicWorking
        {
            get { return m_ElectronicWorking; }
            set 
            {
                m_ElectronicWorking = value;
                NotifyPropertyChanged();
            }
        }
        public double ElectronicLightning
        {
            get { return m_ElectronicLightning; }
            set 
            { 
                m_ElectronicLightning = value;
                NotifyPropertyChanged();
            }
        }
        public double ProductionWind
        {
            get { return m_ProductionWind; }
            set
            {
                m_ProductionWind = value;
                NotifyPropertyChanged();
            }
        }        
        public double ProductionSun
        {
            get { return m_ProductionSun; }
            set
            {
                m_ProductionSun = value;
                NotifyPropertyChanged();
            }
        }
        public string Heating
        {
            get { return m_Heating; }
            set
            {
                m_Heating = value;
                NotifyPropertyChanged();
            }
        }
        public double StorageCapacityOpen
        {
            get { return m_StorageCapacityOpen; }
            set
            {
                m_StorageCapacityOpen = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityCovered
        {
            get { return m_StorageCapacityCovered; }
            set
            {
                m_StorageCapacityCovered = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityLivestock
        {
            get { return m_StorageCapacityLivestock; }
            set
            {
                m_StorageCapacityLivestock = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityCement
        {
            get { return m_StorageCapacityCement; }
            set
            {
                m_StorageCapacityCement = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityCooler
        {
            get { return m_StorageCapacityCooler; }
            set
            {
                m_StorageCapacityCooler = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityPassenger
        {
            get { return m_StorageCapacityPassenger; }
            set
            {
                m_StorageCapacityPassenger = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityGravel
        {
            get { return m_StorageCapacityGravel; }
            set
            {
                m_StorageCapacityGravel = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityConcrete
        {
            get { return m_StorageCapacityConcrete; }
            set
            {
                m_StorageCapacityConcrete = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityVehicles
        {
            get { return m_StorageCapacityVehicles; }
            set
            {
                m_StorageCapacityVehicles = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityOil
        {
            get { return m_StorageCapacityOil; }
            set
            {
                m_StorageCapacityOil = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityGeneral
        {
            get { return m_StorageCapacityGeneral; }
            set
            {
                m_StorageCapacityGeneral = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityNuclear1
        {
            get { return m_StorageCapacityNuclear1; }
            set
            {
                m_StorageCapacityNuclear1 = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageCapacityNuclear2
        {
            get { return m_StorageCapacityNuclear2; }
            set
            {
                m_StorageCapacityNuclear2 = value;
                this.NotifyPropertyChanged();
            }
        }        
        public double StorageCapacityWater
        {
            get { return m_StorageCapacityWater; }
            set
            {
                m_StorageCapacityWater = value;
                this.NotifyPropertyChanged();
            }
        }        
        public double StorageCapacitySewage
        {
            get { return m_StorageCapacitySewage; }
            set
            {
                m_StorageCapacitySewage = value;
                this.NotifyPropertyChanged();
            }
        }
        public string StorageSpecialID1
        {
            get { return m_StorageSpecialID1; }
            set
            {
                m_StorageSpecialID1 = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageSpecial1Capacity
        {
            get { return m_StorageSpecial1Capacity; }
            set
            {
                m_StorageSpecial1Capacity = value;
                this.NotifyPropertyChanged();
            }
        }
        public string StorageSpecialID2
        {
            get { return m_StorageSpecialID2; }
            set
            {
                m_StorageSpecialID2 = value;
                this.NotifyPropertyChanged();
            }
        }
        public double StorageSpecial2Capacity
        {
            get { return m_StorageSpecial2Capacity; }
            set
            {
                m_StorageSpecial2Capacity = value;
                this.NotifyPropertyChanged();
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private double CalculatePrice(ObservableCollection<UIModelWareAmount> Wares)
        {
            double sum = 0;
            foreach (UIModelWareAmount ware in Wares)
            {
                double value;
                if (PriceLists.PriceListSell.TryGetValue(ware.Ware, out value))
                    sum = sum + ware.Amount * value;
            }
            return sum;
        }

        public void CalculatPrices()
        {
            if (BuildingName == "Asphalt plant_2")
            {
                m_Margin = 0;
            }
            m_PriceConsumption = this.CalculatePrice(ConsumptionList);
            m_PriceProduction = this.CalculatePrice(ProductionList);
            if (PriceConsumption != 0)
                m_Margin = (PriceProduction * 100 / PriceConsumption) - 100;
            NotifyPropertyChanged("PriceProduction");
            NotifyPropertyChanged("PriceConsumption");
            NotifyPropertyChanged("Margin");
        }
    }
}
