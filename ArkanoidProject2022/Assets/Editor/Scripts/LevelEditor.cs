using UnityEngine;
using UnityEditor;

namespace ArkanoidProj
{
    public class LevelEditor : EditorWindow
    {
        private Transform _parent;
        private EditorData _data;
        private int _index = 0;
        private bool _isEnableEdit;
        private GameLevel _gameLevel;
        private SceneEditor _sceneEditor;

        [MenuItem("Window/Level Editor")]
        public static void Init()
        {
            LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
            levelEditor.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
            EditorGUILayout.Space(30);

            if (_data == null)
            {
                if (GUILayout.Button("Load Data"))
                {
                    _data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
                    _sceneEditor = CreateInstance<SceneEditor>();
                    _sceneEditor.SetLevelEditor(this, _parent);
                }
            }
            else
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Block Prefab", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                //Show arrows and texture of selected block
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _index--;
                    if (_index < 0)
                    {
                        _index = _data.BlockData.Count - 1;
                    }
                }
                GUILayout.FlexibleSpace();
                GUILayout.Label(_data.BlockData[_index].Texture2D);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _index++;
                    if (_index > _data.BlockData.Count - 1)
                    {
                        _index = 0;
                    }
                }
                GUILayout.EndHorizontal();

                //Show index of block
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label($"{_index + 1}/ {_data.BlockData.Count}", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                
                GUILayout.Space(20);
                GUI.color = _isEnableEdit ? Color.red : Color.white;
                if (GUILayout.Button("Create Blocks"))
                {
                    _isEnableEdit = !_isEnableEdit;

                    if (_isEnableEdit)
                    {
                        SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                    }
                    else
                    {
                        SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                    }
                    
                }
                GUI.color = Color.white;

                GUILayout.Space(30);
                _gameLevel = EditorGUILayout.ObjectField(_gameLevel, typeof(GameLevel), false) as GameLevel;
                GUILayout.Space(10);

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Save Level"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    saveLevel.Save(_gameLevel);
                    EditorUtility.SetDirty(_gameLevel);
                    Debug.Log("Level Saved");
                }

                if (GUILayout.Button("Load Level"))
                {
                    GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");
                    foreach (GameObject itemObj in allBlocks)
                    {
                        DestroyImmediate(itemObj.gameObject);
                    }

                    BlockGenerate generator = new BlockGenerate();
                    generator.Generate(_gameLevel, _parent);
                }
                GUILayout.EndHorizontal();

            }
        }
        
        public BlockData GetBlock()
        {
            return _data.BlockData[_index].BlockData;
        }
    }
}

