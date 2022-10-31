using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState = null;
        public void Initialise(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;

            CurrentState.Enter();
        }

        private void Update()
        {
            CurrentState?.Update();
        }
    }
}
