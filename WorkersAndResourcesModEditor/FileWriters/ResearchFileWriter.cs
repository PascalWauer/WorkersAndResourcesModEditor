﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkersAndResourcesModEditor
{
    public enum ResearchType
    {
        TYPE_MEDICAL,
        TYPE_TECHNICAL,
        TYPE_SOVIET
    }
    public static class ResearchIds
    {
        // chemical/medical researches
        public static string Chemistry_1 = "chemistry_1";
        public static string Chemistry_2 = "chemistry_2";
        public static string OilProcessing = "oilprocessing";
        public static string SolarEnergy = "solar_energy";
        public static string Fertilizer = "fertilizer";

        public static string NuclearSafety = "nuclearsafety";
        public static string Nuclear_1 = "nuclear_1";
        public static string Nuclear_2 = "nuclear_2";
        public static string Nuclear_3 = "nuclear_3";
        public static string Nuclear_4 = "nuclear_4";

        public static string Aluminum_1 = "aluminum_1";
        public static string Aluminum_2 = "aluminum_2";

        // technical researches
        public static string Engineering_1 = "engineering_1";
        public static string Engineering_2 = "engineering_2";
        public static string Electronics_1 = "electronics_1";
        public static string Electronics_2 = "electronics_2";
        public static string Electronics_3 = "electronics_3";
        public static string OilMining = "oilmining";
        
        public static string Vehicles = "production_vehicle";
        public static string Ships = "production_ship";
        public static string Trains = "production_train";
        public static string Airplanes = "production_airplane";
        public static string Wind = "wind_energy";

        // civilian/soviet researches
        public static string SecretPolice = "secretpolice";
        public static string radio_1 = "radio_1";
        public static string tv_2 = "tv_1";
    }
    public class Research
    {
        public string ResearchId;
        public ResearchType Type;
        public string BuildingId;

    }
    public class ResearchGroup
    {
        public string ResearchId;
        public ResearchType Type;
        public string Name;
        public string Description;
        public int Cost;
        public bool IsAvailableAtStart;
        public List<string> NextResearches;
    }
    public static class ResearchFileWriter
    {
        private static List<Research> ResearchBuildings = new List<Research>();

        public static void RecreateResearchList()
        {
            ResearchBuildings.Clear();
            AddVanillaResearchBuildings();
        }

        public static void InsertIntoList(string buildingId, string line, string subtype = null)
        {
            // Medical Research
            if (line.Contains("chemicals"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Chemistry_1, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("plastics"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Chemistry_2, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("rawbauxite"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Aluminum_1, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("bauxite"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Aluminum_1, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("aluminiumoxide"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Aluminum_2, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("aluminium"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Aluminum_2, Type = ResearchType.TYPE_MEDICAL });

            else if (line.Contains("rawuranium") || line.Contains("uranium"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Nuclear_1, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("uraniumoxide"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Nuclear_2, Type = ResearchType.TYPE_MEDICAL });            
            else if (line.Contains("uf6"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Nuclear_2, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("nuclearfuel"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Nuclear_3, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("nuclear_power"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Nuclear_4, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("connect_to_sun"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.SolarEnergy, Type = ResearchType.TYPE_MEDICAL });
            else if (line.Contains("fuel") || line.Contains("bitumen"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.OilProcessing, Type = ResearchType.TYPE_MEDICAL });            
            else if (line.Contains("greenhouse"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Fertilizer, Type = ResearchType.TYPE_MEDICAL });

            // Technical Research
            else if (line.Contains("mcomponents"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Engineering_1, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("oil"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.OilMining, Type = ResearchType.TYPE_TECHNICAL });

            else if (line.Contains("ecomponents"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Electronics_1, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("eletronics"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Electronics_2, Type = ResearchType.TYPE_TECHNICAL });

            else if (line.Contains("vehicles") && subtype == null)
                return;

            else if (line.Contains("vehicles") && subtype == "road")
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Vehicles, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("vehicles") && subtype == "ship")
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Ships, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("vehicles") && subtype == "rail")
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Trains, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("vehicles") && subtype.Contains("plane"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Airplanes, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("nuclearfuelburned"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Nuclear_4, Type = ResearchType.TYPE_TECHNICAL });
            else if (line.Contains("connect_to_wind"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.Wind, Type = ResearchType.TYPE_TECHNICAL });

            // Soviet Research

            else if (line.Contains("secret_police"))
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.SecretPolice, Type = ResearchType.TYPE_SOVIET });
            else if (subtype == "radio")
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.radio_1, Type = ResearchType.TYPE_SOVIET });
            else if (subtype == "television")
                ResearchBuildings.Add(new Research() { BuildingId = buildingId, ResearchId = ResearchIds.tv_2, Type = ResearchType.TYPE_SOVIET });

        }

        public static void WriteResearchFile()
        {
            //AddVanillaResearchBuildings();
            string path = Environment.CurrentDirectory;
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, "research", "research.ini")))
            {
                //List<ResearchGroup> groups = ResearchBuildings.Select(x => new ResearchGroup { ResearchId = x.ResearchId, Type = x.Type }).DistinctBy(x => x.ResearchId).ToList();
                //CreateResearchGroups(groups);
                List<ResearchGroup> groups = new List<ResearchGroup>();
                groups.AddRange(CreateResearchGroups());
                foreach (var group in groups)
                {
                    sw.WriteLine("$RESEARCH " + group.ResearchId);
                    sw.WriteLine("$" + group.Type);
                    sw.WriteLine("$NAME " + group.Name);
                    sw.WriteLine("$DESC " + group.Description);
                    sw.WriteLine("");

                    // new group setting type, name, description, cost, availability and next research
                    if (group.IsAvailableAtStart)
                    {
                        sw.WriteLine("$AVAILABLE");
                    }
                    sw.WriteLine("$COST " + group.Cost);
                    sw.WriteLine("");

                    var buildingsToThisGroup = ResearchBuildings.Where(x => x.ResearchId == group.ResearchId);

                    //sw.WriteLine(AddVanillaResearchBuildings(group.ResearchId));

                    if (group.NextResearches != null)
                    {
                        foreach (var nextResearch in group.NextResearches)
                        {
                            sw.WriteLine("$UNLOCK_RESEARCH " + nextResearch);
                        }
                        sw.WriteLine("");
                    }

                    foreach (var building in buildingsToThisGroup)
                    {
                        sw.WriteLine("$UNLOCK_BUILDING " + building.BuildingId);
                    }

                    sw.WriteLine("$RESEARCH_ADD");
                    sw.WriteLine(";=======================================");
                    sw.WriteLine("");
                }
            }
        }
        private static List<ResearchGroup> CreateResearchGroups()
        {
            List<ResearchGroup> groups = new List<ResearchGroup>();

            // "TYPE_MEDICAL"

            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Chemistry_1,
                Type = ResearchType.TYPE_MEDICAL,
                IsAvailableAtStart = true,
                Name = "12101",
                Cost = 2000,
                Description = "12201",
                NextResearches = new List<string>() { ResearchIds.OilProcessing, ResearchIds.SolarEnergy, ResearchIds.Fertilizer, ResearchIds.NuclearSafety }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.SolarEnergy,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12104",
                Cost = 2500,
                Description = "12204"
            });            
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Fertilizer,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12105",
                Cost = 2500,
                Description = "12205"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.OilProcessing,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12103",
                Cost = 4000,
                Description = "12203",
                NextResearches = new List<string>() { ResearchIds.Chemistry_2 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.NuclearSafety,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12106",
                Cost = 3000,
                Description = "12206",
                NextResearches = new List<string>() { ResearchIds.Nuclear_1 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Chemistry_2,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12102",
                Cost = 4000,
                Description = "12202"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Aluminum_1,
                Type = ResearchType.TYPE_MEDICAL,
                IsAvailableAtStart = true,
                Name = "12111",
                Cost = 4000,
                Description = "12211",
                NextResearches = new List<string>() { ResearchIds.Aluminum_2 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Aluminum_2,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12112",
                Cost = 4000,
                Description = "12212"
            });
            
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Nuclear_1,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12107",
                Cost = 5000,
                Description = "12207",
                NextResearches = new List<string>() { ResearchIds.Nuclear_2 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Nuclear_2,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12108",
                Cost = 10000,
                Description = "12208",
                NextResearches = new List<string>() { ResearchIds.Nuclear_3 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Nuclear_3,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12109",
                Cost = 20000,
                Description = "12209",
                NextResearches = new List<string>() { ResearchIds.Nuclear_4 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Nuclear_4,
                Type = ResearchType.TYPE_MEDICAL,
                Name = "12110",
                Cost = 50000,
                Description = "12210"
            });

            // "TYPE_TECHNICAL"

            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Engineering_1,
                Type = ResearchType.TYPE_TECHNICAL,
                IsAvailableAtStart = true,
                Name = "12120",
                Cost = 2000,
                Description = "12220",
                NextResearches = new List<string>() { ResearchIds.Engineering_2, ResearchIds.OilMining, ResearchIds.Vehicles, ResearchIds.Ships, ResearchIds.Trains }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Engineering_2,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12121",
                Cost = 2500,
                Description = "12221"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.OilMining,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12129",
                Cost = 3000,
                Description = "12229"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Vehicles,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12122",
                Cost = 4000,
                Description = "12222",
                NextResearches = new List<string>() { ResearchIds.Airplanes }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Ships,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12123",
                Cost = 5000,
                Description = "12223"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Trains,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12124",
                Cost = 4000,
                Description = "12224"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Airplanes,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12125",
                Cost = 20000,
                Description = "12225"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Electronics_1,
                IsAvailableAtStart = true,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12126",
                Cost = 3000,
                Description = "12226",
                NextResearches = new List<string>() { ResearchIds.Electronics_2, ResearchIds.Wind }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Electronics_2,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12127",
                Cost = 8000,
                Description = "12227"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.Wind,
                Type = ResearchType.TYPE_TECHNICAL,
                Name = "12128",
                Cost = 2500,
                Description = "12228"
            });

            // "TYPE_SOVIET"

            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.SecretPolice,
                Type = ResearchType.TYPE_SOVIET,
                IsAvailableAtStart = true,
                Name = "12140",
                Cost = 2500,
                Description = "12240"
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.radio_1,
                Type = ResearchType.TYPE_SOVIET,
                IsAvailableAtStart = true,
                Name = "12141",
                Cost = 10000,
                Description = "12241",
                NextResearches = new List<string>() { ResearchIds.tv_2 }
            });
            groups.Add(new ResearchGroup()
            {
                ResearchId = ResearchIds.tv_2,
                Type = ResearchType.TYPE_SOVIET,
                Name = "12142",
                Cost = 40000,
                Description = "12242"
            });

            return groups;
        }
        private static void AddVanillaResearchBuildings()
        {
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Vehicles, BuildingId = "production_vehicle", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Vehicles, BuildingId = "spaceforvehicles_small", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Vehicles, BuildingId = "spaceforvehicles_big", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Ships, BuildingId = "drydock", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Trains, BuildingId = "production_train2", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Airplanes, BuildingId = "production_airplane", Type = ResearchType.TYPE_TECHNICAL });

            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_1, BuildingId = "uranium_mine", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_2, BuildingId = "uranium_processing", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_2, BuildingId = "uranium_conversion", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_3, BuildingId = "nuclear_fuel_plant", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_4, BuildingId = "powerplant_nuclear_single", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_4, BuildingId = "powerplant_nuclear_double", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Nuclear_4, BuildingId = "zaporozie_reactor", Type = ResearchType.TYPE_TECHNICAL });

            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Electronics_1, BuildingId = "eletronic_components_factory", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Electronics_2, BuildingId = "eletronic_factory", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_1, BuildingId = "mechanical_components_factory", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_station_small", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_station_big", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_station_cargo", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_station_cargo2", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_gravel_loading_big", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_gravel_unloading_big", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_light_1", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_light_2", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_light_3", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_light_4", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_heavy_1", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_heavy_2", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_heavy_3", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "cableway_pole_heavy_4", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "trolleybus_depo", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "rail_trafo", Type = ResearchType.TYPE_TECHNICAL });
            //ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Engineering_2, BuildingId = "road_trafo", Type = ResearchType.TYPE_TECHNICAL });

            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Wind, BuildingId = "powerplant_wind1", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Wind, BuildingId = "powerplant_wind2", Type = ResearchType.TYPE_TECHNICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.OilMining, BuildingId = "oil_mine", Type = ResearchType.TYPE_TECHNICAL });

            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Chemistry_1, BuildingId = "chemical_plant", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Chemistry_2, BuildingId = "plastics_factory", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.OilProcessing, BuildingId = "oil_rafinery", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.OilProcessing, BuildingId = "oil_rafinery_v2", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.SolarEnergy, BuildingId = "powerplant_solar", Type = ResearchType.TYPE_TECHNICAL });

            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Aluminum_1, BuildingId = "bauxite_mine", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Aluminum_1, BuildingId = "bauxite_processing", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Aluminum_2, BuildingId = "alumina_plant", Type = ResearchType.TYPE_MEDICAL });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.Aluminum_2, BuildingId = "aluminium_plant", Type = ResearchType.TYPE_MEDICAL });

            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.SecretPolice, BuildingId = "secretpolice", Type = ResearchType.TYPE_SOVIET });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.radio_1, BuildingId = "rozhlas", Type = ResearchType.TYPE_SOVIET });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.radio_1, BuildingId = "rozhlas_v2", Type = ResearchType.TYPE_SOVIET });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.tv_2, BuildingId = "televizia", Type = ResearchType.TYPE_SOVIET });
            ResearchBuildings.Add(new Research() { ResearchId = ResearchIds.tv_2, BuildingId = "televizia_v2", Type = ResearchType.TYPE_SOVIET });
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return _(); IEnumerable<TSource> _()
            {
                var knownKeys = new HashSet<TKey>(comparer);
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                        yield return element;
                }
            }
        }
    }
}
