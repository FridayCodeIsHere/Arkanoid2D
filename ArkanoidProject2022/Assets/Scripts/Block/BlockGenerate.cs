#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

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
                game = PrefabUtility.InstantiatePrefab(level.Blocks[i].BlockData._block, parent) as GameObject;
                if (game.TryGetComponent(out Block block))
                {
                    block.BlockData = level.Blocks[i].BlockData;
                    block.SetData(level.Blocks[i].BlockData);
                }


#else
                game = GameObject.Instantiate(level.Blocks[i].BlockData._block, parent);
                if (game.TryGetComponent(out Block block1))
                {
                    BlockData blockData = level.Blocks[i].BlockData;
                    block.SetData(blockData);
                }
#endif
                game.transform.position = level.Blocks[i].Position;
            }
        }
    }
}

