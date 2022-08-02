using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace WorkersAndResourcesModEditor
{
    public static class IniReader
    {
        public static UIModelBuildingIni ReadBuildingIni(string file, ref string errorMessage)
        {
            string line = "";
            UIModelBuildingIni building = new UIModelBuildingIni();

            try
            {
                building.ProductionList = new ObservableCollection<UIModelWareAmount>();
                building.ConsumptionList = new ObservableCollection<UIModelWareAmount>();

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
                    while((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("$ITEM_NAME "))
                        {
                            string[] lineArray = line.Split("\"");
                            building.ModID = lineArray[lineArray.Length - 2];
                        }                        
                        //if (line.Contains("OBJECT_BUILDING "))
                        //{
                        //    string[] lineArray = line.Split(" ");
                        //    building.ObjectName = lineArray[1];
                        //}
                        if (line.Contains("WORKSHOP_ITEMTYPE_BUILDINGSKIN"))
                        {
                            building.Skin = true;
                        }
                    }
                }

                line = string.Empty;
                building.FilePath = file;
                using (StreamReader sr = new StreamReader(file))
                {
                    if (file.Contains("2000613131"))
                        line = "";

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace("\t", " ").Replace("  ", " ");

                        if (line.StartsWith(@"//") || line.StartsWith(@"--") || line.StartsWith(@";"))
                            continue;

                        line = line.Replace("\t", " ").Trim(); ;

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
                            building.Workers_Capacity = int.Parse(lineElements[lineElements.Length - 1]);
                        }
                        if (line.Contains("$STORAGE_LIVING_AUTO"))
                        {
                            //string[] lineElements = line.Split(' ');
                            //building.Workers_Capacity = lineElements[lineElements.Length - 1];
                            building.Workers_Capacity = -1;
                        }

                        if (line.Contains("$QUALITY_OF_LIVING"))
                        {
                            string[] lineElements = line.Split(' ');

                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.Quality = result;
                        }
                        if (line.Contains("$WORKERS_NEEDED"))
                        {
                            string[] lineElements = line.Split(' ');
                            building.Workers_Needed = int.Parse(lineElements[1]);
                        }
                        if (line.Contains("$ELETRIC_WITHOUT_LIGHTING_FACTOR"))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.ElectronicLightning = result;
                        }
                        if (line.Contains("$ELETRIC_WITHOUT_WORKING_FACTOR "))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.ElectronicWorking = result;
                        }
                        if (line.Contains("$ELETRIC_CONSUMPTION_LIVING_WORKER_FACTOR "))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.ElectronicLiving = result;
                        }
                        if (line.Contains("$PRODUCTION_CONNECT_TO_WIND"))
                        {
                            string[] lineElements = line.Split(' ');
                            building.ProductionWind = int.Parse(lineElements[1]);
                            //if (building.Type == "powerplant" || building.Type == "factory")
                            //{
                            //    string[] filePathArray = building.FilePath.Split('\\');
                            //    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], line, "powerplant_wind");
                            //}
                        }
                        if (line.Contains("$PRODUCTION_CONNECT_TO_SUN"))
                        {
                            string[] lineElements = line.Split(' ');
                            building.ProductionSun = int.Parse(lineElements[1]);
                            //if (building.Type == "powerplant" || building.Type == "factory")
                            //{
                            //    string[] filePathArray = building.FilePath.Split('\\');
                            //    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], line, "powerplant_sun");
                            //}
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
                        //subtypes
                        if (line.Contains("$SUBTYPE_"))
                        {
                            building.SubType = line.Replace("$SUBTYPE_", "").ToLower();
                            //if (building.Type == "broadcast")
                            //{
                            //    string[] filePathArray = building.FilePath.Split('\\');
                            //    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], line, building.SubType);
                            //}
                        }

                        //storage
                        if (line.Contains("$STORAGE RESOURCE_TRANSPORT_") || line.Contains("$STORAGE_IMPORT") || line.Contains("$STORAGE_EXPORT"))
                        {
                            SetStorage(line, building);
                        }
                        if (line.Contains("$STORAGE_SPECIAL RESOURCE_TRANSPORT_"))
                        {
                            SetSpecialStorage(line, building);
                        }
                        //attractive
                        if (line.Contains("$ATTRACTIVE_SCORE "))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.AttractiveScore = result;
                        }
                        //heat
                        if (line.Contains("$HEATING_DISABLE"))
                        {
                            building.Heating = "Disabled";
                        }
                        //loyalty
                        if (line.Contains("$MONUMENT_GOVERNMENT_LOYALTY_RADIUS"))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.LoyaltyRadius = result;
                        }
                        if (line.Contains("MONUMENT_GOVERNMENT_LOYALTY_STRENGTH"))
                        {
                            string[] lineElements = line.Split(' ');
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.LoyaltyStrength = result;
                        }
                        //production
                        if (line.Contains("$PRODUCTION "))
                        {
                            string[] lineElements = line.Split(' ');
                            string wareID = line.Split(' ')[1];
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.ProductionList.Add(new UIModelWareAmount(wareID, result));
                            //string[] filePathArray = building.FilePath.Split('\\');
                            //ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length -2], line, building.SubType);
                        }
                        //consumption
                        if (line.Contains("$CONSUMPTION "))
                        {
                            string[] lineElements = line.Split(' ');
                            string wareID = line.Split(' ')[1];
                            Double.TryParse(lineElements[lineElements.Length - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                            building.ConsumptionList.Add(new UIModelWareAmount(wareID, result));
                        }
                        //serve citizens
                        if (line.Contains("$CITIZEN_ABLE_SERVE"))
                        {
                            string[] lineElements = line.Split(' ');
                            building.CitizensServe = double.Parse(lineElements[1]);
                        }
                    }
                }
                if (building.Type == null)
                    building.Type = "unknown";

                string[] filePathArray = building.FilePath.Split('\\');

                if (building.ProductionSun > 0 && building.ProductionList.Any(x => x.Ware == "eletric"))
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "connect_to_sun", building.SubType);
                else if (building.ProductionWind > 0)
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "connect_to_wind", building.SubType);
                else if (building.ProductionList.Any(x => x.Ware == "eletric") && building.ProductionList.Any(x => x.Ware == "nuclearfuelburned"))
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "nuclear_power", building.SubType);
                else if (building.ProductionList != null && building.ProductionList.Count == 1 && building.ProductionList[0].Ware == "plants" && building.ConsumptionList != null && building.ConsumptionList.Any(x => x.Ware == "chemicals"))
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "greenhouse", building.SubType);
                else if (building.ProductionList != null && building.ProductionList.Count == 1)
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], building.ProductionList[0].Ware, building.SubType);
                else if (building.ProductionList != null && building.ProductionList.Count > 1)
                {
                    if (building.ProductionList.Any(x => x.Ware == "fuel" || x.Ware == "bitumen"))
                        ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "fuel", building.SubType);
                    else if (building.ProductionList.Any(x => x.Ware == "uf6"))
                        ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "uf6", building.SubType);
                }
                else if (building.SubType != null)
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "", building.SubType);
                else if (building.Type != null && building.Type == "secret_police")
                    ResearchFileWriter.InsertIntoList(building.WorkshopID + "/" + filePathArray[filePathArray.Length - 2], "secret_police", building.SubType);

                building.CalculatPrices();
                return building;
            }
            catch (global::System.Exception ex)
            {
                //MessageBox.Show("Error in line: " + line + Environment.NewLine + ex.Message);
                errorMessage += "An error occured while reading mod with WorkshopID: " + building.WorkshopID + " in building: \"" + building.BuildingName + "\" in line: " + line + Environment.NewLine + ex.Message + Environment.NewLine;
#if DEBUG
                throw new Exception("An error occured while reading mod with WorkshopID: " + building.WorkshopID + " in building: \"" + building.BuildingName + "\" in line: " + line + Environment.NewLine + ex.Message + Environment.NewLine);
#endif
                return building;
            }
        }
        private static void SetStorage(string line, UIModelBuildingIni building)
        {
            if (line.Contains("RESOURCE_TRANSPORT_OPEN"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityOpen = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_COVERED"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityCovered = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_LIVESTOCK"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityLivestock = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_CEMENT"))
            {
                double result = ExtractStorageAmount(line);

                building.StorageCapacityCement = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_COOLER"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityCooler = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_PASSANGER"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityPassenger = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_GRAVEL"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityGravel = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_CONCRETE"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityConcrete = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_VEHICLES"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityVehicles = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_OIL"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityOil = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_GENERAL"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityGeneral = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_NUCLEAR1"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityNuclear1 = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_NUCLEAR2"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityNuclear2 = result;
                return;
            }            
            if (line.Contains("RESOURCE_TRANSPORT_WATER"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacityWater = result;
                return;
            }
            if (line.Contains("RESOURCE_TRANSPORT_SEWAGE"))
            {
                double result = ExtractStorageAmount(line);
                building.StorageCapacitySewage = result;
                return;
            }
            // not yet supported but no error
            if (line.Contains("RESOURCE_TRANSPORT_ELETRIC"))
            {
                // do nothing
                //double result = ExtractStorageAmount(line);
                return;
            }
            else
            {
                throw new Exception("Unknown storage type in file " + building.FilePath);
            }
        }

        private static double ExtractStorageAmount(string line)
        {
            string[] lineElements = line.Split(' ');
            if (lineElements.Length >= 3)
            {
                Double.TryParse(lineElements[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                return result;
            }
            else
                return 0;
        }

        private static void SetSpecialStorage(string line, UIModelBuildingIni building)
        {
            try
            {
                if (building.SpecialStorageList == null)
                    building.SpecialStorageList = new ObservableCollection<UIModelWareAmount>();

                string[] lineElements = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                Double.TryParse(lineElements[2], out double amount);
                UIModelWareAmount specialStorage = new UIModelWareAmount(lineElements[3], amount);
                building.SpecialStorageList.Add(specialStorage);
            }
            //if (string.IsNullOrEmpty(building.StorageSpecialID1))
            //{
            //    string[] lineElements = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                
            //    int end = lineElements.Length - 1;
            //    if (string.IsNullOrEmpty(lineElements[lineElements.Length -1]))
            //        end = lineElements.Length - 2;
            //    building.StorageSpecialID1 = lineElements[end];

            //    Double.TryParse(lineElements[end - 1], out double result);
            //    building.StorageSpecial1Capacity = result;
            //    return;
            //}
            //else if (string.IsNullOrEmpty(building.StorageSpecialID2))
            //{
            //    string[] lineElements = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //    int end = lineElements.Length - 1;
            //    if (string.IsNullOrEmpty(lineElements[lineElements.Length - 1]))
            //        end = lineElements.Length - 2;
            //    building.StorageSpecialID2 = lineElements[end];
            //    Double.TryParse(lineElements[end -1], out double result);
            //    building.StorageSpecial2Capacity = result;
            //    return;
            //}
            catch
            {
                //throw new Exception("More than 2 special storages detected in file " + building.FilePath);
                throw new Exception("An error occured while reading mod with workshopID: " + building.WorkshopID + " in building: " + building.BuildingName + Environment.NewLine + " in line: " + line);
            }
        }
    }
}
