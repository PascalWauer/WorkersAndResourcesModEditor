using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersAndResourcesModEditor
{
    static class PriceLists
    {
        public static Dictionary<string, double> PriceListSell;
        static PriceLists()
        {
            // prices taken from in game 01.01.1960 on default settings (medium)
            PriceListSell = new Dictionary<string, double>()
            { 
                {"alcohol", 242.56}, 
                {"aluminium", 735.08}, 
                {"aluminiumoxide", 314.26}, 
                {"asphalt", 34.14},
                {"bauxite", 43.42},
                {"concrete", 12.52}, 
                {"bitumen", 197.88}, 
                {"boards", 12.67},
                {"rawgravel", 3.62}, 
                {"chemicals", 932.97}, 
                {"iron", 19.68}, 
                {"rawiron", 6.68}, 
                {"ecomponents", 1064.24}, 
                {"eletronics", 1112.52}, 
                {"food", 115.72},
                {"meat", 297.24}, 
                {"used nuclear fuel", -1085.85}, 
                {"wood", 8.56},
                {"nuclearfuel", 42128.84}, 
                {"gravel", 8.14}, 
                {"clothes", 1338.15}, 
                {"coal", 17.57}, 
                {"rawcoal", 7.35}, 
                {"plastics", 682.56}, 
                {"mcomponents", 569.26}, 
                {"plants", 16.25}, 
                {"prefabpanels", 21.27},  
                {"rawbauxite", 23.14}, 
                {"steel", 355.49}, 
                {"fabric", 349.12}, 
                {"fuel", 120.65}, 
                {"uf6", 3550.57}, 
                {"rawuranium", 20.73},
                {"uraniumoxide", 949.03}, 
                {"livestock", 146.49}, 
                {"cement", 36.12}, 
                {"bricks", 27.12}, 
                {"oil", 40.82}, 
                {"eletric", 0.96},
                {"water", 8.74},
                {"sewage", -8.55}
            };

            /*
             * 20 food = 42 plants + 8.5 water / 170 workers
             * 6 alcohol = 30 plants + 13 water + 10 electric / 100 workers
             * 10 lifestock = 20 plant + 12 water / 50 workers
             * 60 meat = 150 lifestock / 50 workers
             * 140 boards = 180 wood + 1.6 electric / 20 workers
             * 5 textile  = 20 plant + 0.5 chemcials + 11 water + 10 electric / 100 workers
             * 1.2 clothes = 2.4 textiles / 80
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             *
             */
        }
    }
}
