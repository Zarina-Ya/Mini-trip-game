using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject {
    public class LocalisationSystem
    {
        public enum Lanquage
        {
            English,
            French,
            Russian
        }

        public static Lanquage lanquage = Lanquage.French;

        private static Dictionary<string, string> localisedEN = new Dictionary<string, string>();
        private static Dictionary<string, string> localisedFR = new Dictionary<string, string>();
        private static Dictionary<string, string> localisedRU = new Dictionary<string, string>();

        public static bool isInit;
        public static void Init()
        {
            JsonLocalisationLoader loader = new JsonLocalisationLoader();
            loader.Load();

            localisedEN = loader.GetDictionaryValues("EN");
            localisedFR = loader.GetDictionaryValues("FR");
            localisedRU = loader.GetDictionaryValues("RU");
            isInit = true;
        }

        public static string GetLocalisedValue(string key)
        {
            if(!isInit) Init();

            string val = key;
            switch (lanquage)
            {
                case Lanquage.English:
                    localisedEN.TryGetValue(key, out val);
                    break;
                case Lanquage.French:
                    localisedFR.TryGetValue(key, out val);
                    break;
                case Lanquage.Russian:
                    localisedRU.TryGetValue(key, out val);
                    break;
            }

            return val;
        }
        
    }
}
