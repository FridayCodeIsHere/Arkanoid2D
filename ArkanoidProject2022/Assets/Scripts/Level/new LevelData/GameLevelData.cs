using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace ArkanoidProj
{
    public class GameLevelData
    {
        private List<ProgressLevel> _levelsProgress;
        private readonly string _levelsPath;
        public int CountLevels => _levelsProgress.Count;
        

        public GameLevelData(string pathLevels)
        {
            _levelsPath = pathLevels;
            _levelsProgress = new List<ProgressLevel>();
            InitLevels();
            
        }



        private void InitLevels()
        {
            GameLevel[] levels = Resources.LoadAll<GameLevel>(_levelsPath);

            for (int i = 0; i < levels.Length; i++)
            {
                _levelsProgress.Add(new ProgressLevel());
                _levelsProgress[i].SetLevel(levels[i]);
            }

            _levelsProgress[0].IsOpen = true;
        }

        public void SetLevelsData(XElement elementsData)
        {
            XElement[] elements = elementsData.Elements("LevelData").ToArray();
            for (int i = 0; i < elements.Length; i++)
            {
                bool isOpen = Convert.ToBoolean(elements[i].Attribute("IsOpen").Value);
                bool isSelected = Convert.ToBoolean(elements[i].Attribute("IsSelected").Value);
                _levelsProgress[i].IsOpen = isOpen;
                _levelsProgress[i].IsSelected = isSelected;
            }
        }

        public ProgressLevel GetLevelProgress(int levelIndex)
        {
            return _levelsProgress[levelIndex];
        }

        public XElement GetXMlData(TypeOfLevel typeSectionLevels)
        {
            XElement element = new XElement("LevelsSection");
            foreach(ProgressLevel levelProgress in _levelsProgress)
            {
                XAttribute isOpen = new XAttribute("IsOpen", levelProgress.IsOpen);
                XAttribute isSelected = new XAttribute("IsSelected", levelProgress.IsSelected);
                XElement levelData = new XElement("LevelData", isOpen, isSelected);
                element.Add(levelData);
            }
            element.SetAttributeValue("TypeLevel", typeSectionLevels);
            return element;
        }

        public ProgressLevel GetSelectedLevelProgress()
        {
            foreach (ProgressLevel level in _levelsProgress)
            {
                if (level.IsSelected)
                {
                    return level;
                }
            }
            return null;
        }

        public int GetIndexSelectLevel()
        {
            for (int i = 0; i < _levelsProgress.Count; i++)
            {
                if (_levelsProgress[i].IsSelected == true)
                    return i;
            }
            return -1;
        }

        public bool IsCompletedTypeLevel()
        {
            foreach(ProgressLevel level in _levelsProgress)
            {
                if (level.IsOpen == false)
                {
                    return false;
                    break;
                }
            }
            return true;
        }

        public void SelectLevel(int index)
        {
            foreach(ProgressLevel level in _levelsProgress)
            {
                if (level.IsSelected) level.IsSelected = false;
            }
            _levelsProgress[index].IsSelected = true;
            _levelsProgress[index].IsOpen = true;
        }
    }

    [System.Serializable]
    public class ProgressLevel
    {
        public GameLevel Level { get; set; }
        public bool IsOpen { get; set; }
        public bool IsSelected { get; set; }
        

        public void SetLevel(GameLevel level)
        {
            Level = level;
        }
        
    }
}
