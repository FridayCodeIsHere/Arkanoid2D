using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(BallMovement))]
    public class BallCollision : MonoBehaviour
    {
        private BallMovement _ballMovement;

        private void Awake()
        {
            _ballMovement = GetComponent<BallMovement>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ballMovement.MoveCollision(collision);
        }
    }
}

