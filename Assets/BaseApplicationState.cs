

namespace Assets
{
    public abstract class State
    {
        protected StateMachine StateMachine;
        protected State(StateMachine SM)
        {
            StateMachine = SM;
        }

        public abstract void Enter();

        public abstract void Update();
        public abstract void Exit();
    }
}
