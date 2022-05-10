using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class SaveLevel
    {
        public void Save(GameLevel gameLevel)
        {
            gameLevel.Blocks = new List<BlockObject>();
            BaseBlock[] baseBlocks = GameObject.FindObjectsOfType<BaseBlock>();

            foreach(BaseBlock blockItem in baseBlocks)
            {
                BlockObject blockObject = new BlockObject();
                blockObject.Position = blockItem.gameObject.transform.position;

                blockObject.BlockData = blockItem.BlockData;
                
                gameLevel.Blocks.Add(blockObject);
            }
        }
    }
}

