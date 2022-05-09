using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class SaveLevel
    {
        public List<BlockObject> GetBlocks()
        {
            List<BlockObject> objects = new List<BlockObject>();
            GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");

            foreach(GameObject blockItem in allBlocks)
            {
                BlockObject blockObject = new BlockObject();
                blockObject.Position = blockItem.gameObject.transform.position;
                
                if (blockItem.TryGetComponent(out Block block))
                {
                    blockObject.BlockData = block.BlockData;
                }
                objects.Add(blockObject);
            }

            return objects;
        }
    }
}

