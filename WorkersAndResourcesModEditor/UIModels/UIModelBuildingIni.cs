using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WorkersAndResourcesModEditor
{
    public class UIModelBuildingIni : INotifyPropertyChanged
    {
        private string m_Workers_Capacity;
        private string m_WorkshopID;
        private string m_ModID;
        private string m_BuildName;
        private string m_FilePath;
        private string m_Category;
        private string m_Type;
        private double m_Quality;
        private string m_WorkersNeeded;
        private string m_Heating;
        private double m_StorageCapacityOpen;
        private double m_StorageCapacityCovered;
        private double m_StorageCapacityLivestock;
        private double m_StorageCapacityCement;
        private double m_StorageCapacityCooler;
        private double m_StorageCapacityPassenger;
        private double m_StorageCapacityGravel;
        private double m_StorageCapacityVehicles;
        private double m_StorageCapacityOil;
        private double m_StorageCapacityGeneral;
        private string m_StorageSpecialID1;
        private double m_StorageSpecial1Capacity;
        private string m_StorageSpecialID2;
        private double m_StorageSpecial2Capacity;
        private double m_ElectronicLiving;
        private double m_ElectronicWorking;
        private double m_ElectronicLightning;
        public string Workers_Capacity
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
        
        public string ModID
        {
            get { return m_ModID; }
            set
            {
                m_ModID = value;
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
        public double Quality
        {
            get { return m_Quality; }
            set
            {
                m_Quality = value;
                this.NotifyPropertyChanged();
            }
        }
        public string Workers_Needed
        {
            get { return m_WorkersNeeded; }
            set
            {
                m_WorkersNeeded = value;
                this.NotifyPropertyChanged();
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
        }public double ElectronicLightning
        {
            get { return m_ElectronicLightning; }
            set 
            { 
                m_ElectronicLightning = value;
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
