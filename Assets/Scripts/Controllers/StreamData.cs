using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ZarinkinProject
{
    public class StreamData<T> : ISaveData<PlayerData>, ISaveData<BonusData>
    {
        string _savePath = Path.Combine(Application.dataPath, "StreamData.txt");

        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(_savePath))
            {
                Debug.Log("File Not Exist");
                return result;
            }

            using(StreamReader sr = new StreamReader(_savePath))
            {
                result.PlayerName = sr.ReadLine();
                result.PlayerHealth = Convert.ToInt32(sr.ReadLine());
               // result.PlayerDead = sr.ReadLine().TryBool();
               // result.PlayerPosition = Convert.ToString(sr.ReadLine());
            }

            return result;
        }

        public void SaveData(PlayerData _player)
        {
           using(StreamWriter sw = new StreamWriter(_savePath))
            {
                sw.WriteLine(_player.PlayerName);
                sw.WriteLine(_player.PlayerHealth);
                sw.WriteLine(_player.PlayerDead);
                sw.WriteLine(_player.PlayerPosition);
                
            }
        }

        public void SaveData(BonusData bonus)
        {
            using (StreamWriter sw = new StreamWriter(_savePath, true))
            {
                sw.WriteLine(bonus.BonusName);
                sw.WriteLine(bonus.BonusType);
                sw.WriteLine(bonus.BonusPosition);

            }
        }

        BonusData ISaveData<BonusData>.Load()
        {
            BonusData result = new BonusData();
            if (!File.Exists(_savePath))
            {
                Debug.Log("File Not Exist");
                return result;
            }

            using (StreamReader sr = new StreamReader(_savePath))
            {
                result.BonusName = sr.ReadLine();
                result.BonusType = sr.ReadLine();
               // result.BonusPosition = sr.ReadLine();
            }

            return result;
        }
    }

}