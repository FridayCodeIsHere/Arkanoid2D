using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public enum State
    {
        Gameplay,
        Other,
        StopGame
    }

    public class GameState : MonoBehaviour
    {
        public State State { get; private set; }

        public void SetState(State state)
        {
            State = state;

            if (State == State.Gameplay || State == State.Other)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
        }
    }
}

