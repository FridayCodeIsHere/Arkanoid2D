using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineField : MonoBehaviour
{
    [SerializeField] private Vector3 _size;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, _size);
    }
}
