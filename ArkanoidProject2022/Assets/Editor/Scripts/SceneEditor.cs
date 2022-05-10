using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArkanoidProj
{
    public class SceneEditor : EditorWindow
    {
        private readonly EditorGrid _grid = new EditorGrid();
        private LevelEditor _levelEditor;
        private Transform _parent;

        public void SetLevelEditor(LevelEditor levelEditor, Transform parent)
        {
            _parent = parent;
            _levelEditor = levelEditor;
            Debug.Log($"LevelEditor: {_levelEditor.GetBlock()._block}");
            Debug.Log($"LevelEditor-1: {_levelEditor}");
        }

        public void OnSceneGUI(SceneView sceneView)
        {
            Event current = Event.current;
            if (current.type == EventType.MouseDown)
            {
                Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x, sceneView.camera.pixelHeight - current.mousePosition.y, sceneView.camera.nearClipPlane));
                Vector3 position = _grid.CheckPosition(point);

                if (position != Vector3.zero)
                {
                    if (IsEmpty(position))
                    {
                        GameObject game = PrefabUtility.InstantiatePrefab(_levelEditor.GetBlock()._block, _parent) as GameObject;
                        Debug.Log(game);
                        Debug.Log($"LevelEditor2: {_levelEditor.GetBlock()._block}");
                        game.transform.position = position;

                        if (game.TryGetComponent(out Block block))
                        {
                            block.BlockData = _levelEditor.GetBlock();
                            block.SetData(_levelEditor.GetBlock());
                        }
                    }
                }
            }

            if (current.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
            }
        }

        public bool IsEmpty(Vector3 position)
        {
            Collider2D collider = Physics2D.OverlapCircle(position, 0.01f);
            return collider == null;
        }
    }
}

