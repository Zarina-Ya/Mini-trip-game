using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;


namespace ZarinkinProject
{
    public class JsonLocalisationLoader : MonoBehaviour
    {
        private TextAsset _localisationFile;

        public void Load()
        {
            _localisationFile = Resources.Load<TextAsset>("Localisation");
        }

        public Dictionary<string, string> GetDictionaryValues(string attributeId)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string fileText;

            if (_localisationFile != null)
                fileText = _localisationFile.text;
            else
                throw new Exception("нет файла в ресурсах");

            List<LocalisationData> data = JsonHelper.FromJson<LocalisationData>(fileText).ToList();

            foreach (LocalisationData dataItem in data)
                dict.Add(dataItem._id, dataItem.CheckLenq(attributeId));

            return dict;
        }

        public void Add(string key, string en, string fr, string ru)
        {
            LocalisationData localisationData = new LocalisationData();
            localisationData._id = key;
            localisationData.EN = en;
            localisationData.FR = fr;
            localisationData.RU = ru;   

            var jsonData = JsonUtility.ToJson(localisationData);
        }
    }
}
