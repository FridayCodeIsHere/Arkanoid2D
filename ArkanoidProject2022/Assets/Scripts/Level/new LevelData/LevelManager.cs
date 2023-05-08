using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Xml;

namespace ArkanoidProj {
    public class LevelManager
    {
        private Dictionary<TypeOfLevel, GameLevelData> _levels;

        private readonly string _pathData;
        private const string SaveKey = "LevelsDataKey";

        private const string pathBlueLevels = "Levels/BlueLevels";
        private const string pathLightBluelevels = "Levels/Light-BlueLevels";
        private const string pathRedLevels = "Levels/RedLevels";
        private const string pathRedLighLevels = "Levels/Light-RedLevels";

        public LevelManager()
        {
            _pathData = Application.persistentDataPath + "/saveLevels.xml";
            _levels = new Dictionary<TypeOfLevel, GameLevelData>();
            InitData();
            
        }

        private void InitData()
        {
            _levels.Add(TypeOfLevel.Blue, new GameLevelData(pathBlueLevels));
            _levels.Add(TypeOfLevel.LightBlue, new GameLevelData(pathLightBluelevels));
            _levels.Add(TypeOfLevel.Red, new GameLevelData(pathRedLevels));
            _levels.Add(TypeOfLevel.LightRed, new GameLevelData(pathRedLighLevels));

            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_pathData))
            {
                XElement allLevels = XDocument.Parse(File.ReadAllText(_pathData)).Element("Levels");
                
                foreach(var sectionLevel in _levels)
                {
                    XElement element = allLevels.Descendants().Where(x => (string)x.Attribute("TypeLevel") == sectionLevel.Key.ToString()).FirstOrDefault();
                    sectionLevel.Value.SetLevelsData(element);
                }
            }
        }

        public void SaveData()
        {
            Debug.Log("Saving data...");
            XElement element = new XElement("Levels");

            foreach (var sectionLevel in _levels)
            {
                element.Add(sectionLevel.Value.GetXMlData(sectionLevel.Key));
            }
            XDocument saveDoc = new XDocument(element);
            File.WriteAllText(_pathData, saveDoc.ToString());
        }

        public GameLevelData GetLevelData(TypeOfLevel typeLevel)
        {
            foreach (var level in _levels)
            {
                if (level.Key == typeLevel)
                {
                    return level.Value;
                }
            }
            return null;
        }

        public void SelectedLevel(TypeOfLevel typeLevel, int index)
        {
            foreach(var selectTypeLevel in _levels)
            {
                if (selectTypeLevel.Key == typeLevel)
                {
                    selectTypeLevel.Value.SelectLevel(index);
                    Debug.Log($"Index has set: {index}");
                    SaveData();
                }
            }
        }

        

    }
}
