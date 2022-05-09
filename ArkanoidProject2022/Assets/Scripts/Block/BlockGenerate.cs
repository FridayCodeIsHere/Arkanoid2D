using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ArkanoidProj
{
    public class BlockGenerate
    {
        public void Generate(GameLevel level, Transform parent)
        {
            for (int i = 0; i < level.Blocks.Count; i++)
            {
                GameObject game;

#if UNITY_EDITOR
                game = PrefabUtility.InstantiatePrefab(level.Blocks[i].BlockData.Block, parent) as GameObject;
                if (game.TryGetComponent(out Block block))
                {
                    block.BlockData = level.Blocks[i].BlockData;
                    block.SetData(level.Blocks[i].BlockData);
                }
#else

#endif
                game.transform.position = level.Blocks[i].Position;
            }
        }
    }
}

