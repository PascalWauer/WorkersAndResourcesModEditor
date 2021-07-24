﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorkersAndResourcesModEditor
{
    public static class IniReader
    {
        public static UIModelBuildingIni ReadBuildingIni(string file)
        {

            try
            {
                UIModelBuildingIni building = new UIModelBuildingIni();

                string[] ModPathArray = file.Split('\\');
                int modPathIndex = 0;
                string ModFolder = "";
                for (int i = 0; i <= ModPathArray.Length -1; i++)
                {   if (i == 0)
                        ModFolder = ModPathArray[i];
                    else
                        ModFolder = ModFolder + "\\" + ModPathArray[i];
                    if (ModPathArray[i].Contains("784150"))
                    {
                        modPathIndex = i;
                        break;
                    }
                }
                building.WorkshopID = ModPathArray[modPathIndex + 1];

                

                building.ModID = ModFolder + "\\" + ModPathArray[modPathIndex + 1];

                using (StreamReader sr = new StreamReader(ModFolder + "\\" + ModPathArray[modPathIndex + 1] + "\\" + "workshopconfig.ini"))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("$ITEM_NAME "))
                        {
                            string[] lineArray = line.Split("\"");
                            building.ModID = lineArray[lineArray.Length - 2];
                            break;
                        }
                    }
                }

                building.FilePath = file;
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("$NAME "))
                        {
                            string[] lineElements = line.Split(' ');
                            building.BuildingName = lineElements[lineElements.Length - 1].Replace("\"", "");
                        }
                        if (line.Contains("$NAME_STR") )
                        {
                            string[] lineElements = line.Split("\"");
                            building.BuildingName = lineElements[lineElements.Length - 2];
                        }

                        if (line.Contains("$STORAGE RESOURCE_TRANSPORT_PASSANGER"))
                        {
                            string[] lineElements =line.Split(' ');
                            building.Workers_Capacity = lineElements[lineElements.Length - 1];
                        }
                        if (line.Contains("$STORAGE_LIVING_AUTO"))
                        {
                            string[] lineElements = line.Split(' ');
                            building.Workers_Capacity = lineElements[lineElements.Length - 1];
                        }

                        if (line.Contains("$QUALITY_OF_LIVING"))
                        {
                            string[] lineElements = line.Split(' ');

                            Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                            building.Quality = result;

                        }
                        if (line.Contains("$WORKERS_NEEDED"))
                        {
                            string[] lineElements = line.Split(' ');
                            building.Workers_Needed = lineElements[lineElements.Length - 1];
                            
                        }
                        if (line.Contains("$ELETRIC_WITHOUT_LIGHTING_FACTOR"))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                            building.ElectronicLightning = result;
                        }
                        if (line.Contains("$ELETRIC_WITHOUT_WORKING_FACTOR "))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                            building.ElectronicWorking = result;
                        }
                        if (line.Contains("$ELETRIC_CONSUMPTION_LIVING_WORKER_FACTOR "))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                            building.ElectronicLiving = result;
                        }
                        //category
                        if (line.Contains("$CIVIL_BUILDING"))
                        {
                            building.Category = "Civil";
                        }
                        
                        if (line.Contains("$TYPE_CONSTRUCTION_OFFICE_RAIL"))
                        {
                            building.Category = "Construction Rail";
                        }

                        //types
                        if (line.Contains("$TYPE_"))
                        {
                            building.Type = line.Replace("$TYPE_", "").ToLower();
                        }
                        
                        //storage
                        if (line.Contains("$STORAGE RESOURCE_TRANSPORT_"))
                        {
                            SetStorage(line, building);
                        }
                        if (line.Contains("$STORAGE_SPECIAL RESOURCE_TRANSPORT_"))
                        {
                            SetSpecialStorage(line, building);
                        }          
                        
                        //heat
                        if (line.Contains("$HEATING_DISABLE"))
                        {
                            building.Heating = "Disabled";
                        }
                    }
                }
                if (building.Type == null)
                    building.Type = "unknown";
                return building;
            }
            catch (global::System.Exception)
            {
                throw;
            }
        }
        private static void SetStorage(string line, UIModelBuildingIni building)
        {
            if (line.Contains("RESOURCE_TRANSPORT_OPEN"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityOpen = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_COVERED"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityCovered = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_LIVESTOCK"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityLivestock = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_CEMENT"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityCement = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_COOLER"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityCooler = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_PASSANGER"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityPassenger = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_GRAVEL"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityGravel = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_VEHICLES"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityVehicles = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_OIL"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityOil = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_GENERAL"))
            {
                string[] lineElements = line.Split(' ');
                Double.TryParse(lineElements[lineElements.Length - 1], out double result);
                building.StorageCapacityGeneral = result;
                return;
            }
            else
            {
                throw new Exception("Unknown storage type in file " + building.FilePath);
            }
        }
        private static void SetSpecialStorage(string line, UIModelBuildingIni building)
        {
            if (string.IsNullOrEmpty(building.StorageSpecialID1))
            {
                
                string[] lineElements = line.Split(' ');
                int end = lineElements.Length - 1;
                if (string.IsNullOrEmpty(lineElements[lineElements.Length -1]))
                    end = lineElements.Length - 2;
                building.StorageSpecialID1 = lineElements[end];

                Double.TryParse(lineElements[end - 1], out double result);
                building.StorageSpecial1Capacity = result;
                return;
            }
            else if (string.IsNullOrEmpty(building.StorageSpecialID2))
            {
                string[] lineElements = line.Split(' ');
                int end = lineElements.Length - 1;
                if (string.IsNullOrEmpty(lineElements[lineElements.Length - 1]))
                    end = lineElements.Length - 2;
                building.StorageSpecialID2 = lineElements[end];
                Double.TryParse(lineElements[end -1], out double result);
                building.StorageSpecial2Capacity = result;
                return;
            }
            else
            {
                throw new Exception("More than 2 special storages detected in file " + building.FilePath);
            }
        }
    }
}
