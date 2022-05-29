using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsContent : MonoBehaviour
{
    public void ClearContent()
    {
        List<Transform> children = new List<Transform>();
        int countChildren = transform.childCount;

        for (int i = 0; i < countChildren; i++)
        {
            children.Add(transform.GetChild(i));
        }

        foreach (Transform item in children)
        {
            Destroy(item.gameObject);
        }
    }
}
