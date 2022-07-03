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
        public static JsonLocalisationLoader loader;

        private static Dictionary<string, string> localisedEN = new Dictionary<string, string>();
        private static Dictionary<string, string> localisedFR = new Dictionary<string, string>();
        private static Dictionary<string, string> localisedRU = new Dictionary<string, string>();

        public static bool isInit;


        public static Dictionary<string, string> GetDictionaryForEditor()
        {
            if(!isInit) 
                Init();
            return localisedEN;
        }
        public static void Init()
        {
            loader = new JsonLocalisationLoader();
            loader.Load();

            UpdateDictionaries();
            isInit = true;
        }

        static void UpdateDictionaries()
        {
            //localisedEN = loader.GetDictionaryValues("EN");
            localisedFR = loader.GetDictionaryValues("FR");
            //localisedRU = loader.GetDictionaryValues("RU");
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

        public static void Add(string key, string en, string fr, string ru)
        {
            if (loader == null)
                loader = new JsonLocalisationLoader();
            loader.Load();
            loader.Add(key, en, fr, ru);
            loader.Load();
            UpdateDictionaries();
        }

        public static void Replace(string key, string en, string fr, string ru)
        {
            if (loader == null)
                loader = new JsonLocalisationLoader();
            loader.Load();
            loader.Edit(key, en, fr, ru);
            loader.Load();
            UpdateDictionaries();
        }

        public static void Remove(string key)
        {
            if (loader == null)
                loader = new JsonLocalisationLoader();
            loader.Load();
            loader.Remove(key);
            loader.Load();
            UpdateDictionaries();
        }
        
    }
}
