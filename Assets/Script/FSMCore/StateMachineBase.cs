using System.Collections.Generic;

namespace FSM
{
    public abstract class State
    {
        protected StateMachineBase fsm;
        public State(StateMachineBase _fsm)
        {
            fsm = _fsm;
        }

        public async virtual void Enter() { }
        public async virtual void Exit() { }
        public async virtual void Update() { }
    }

    [System.Serializable]
    public class StateMachineBase
    {
        protected Dictionary<int, State> states = new Dictionary<int, State>();
        public int currentState = -1;
        public int CurrentState => currentState;
        public StateMachineBase()
        {
        }

        public void Add(int key, State state)
        {
            states.Add(key, state);
        }

        public State GetState(int key)
        {
            return states[key];
        }

        public void SetCurrentState(int key)
        {
            if (key == currentState || !states.ContainsKey(key))
                return;
            if (currentState >= 0)
            {
                states[currentState].Exit();
            }

            currentState = key;

            if (currentState >= 0)
            {
                states[currentState].Enter();
            }
        }

        public void Update()
        {
            if (currentState >= 0)
            {
                states[currentState].Update();
            }
        }
    }
}