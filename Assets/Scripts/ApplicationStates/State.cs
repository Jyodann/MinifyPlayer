namespace Assets.ApplicationStates
{
    public abstract class State<T>
    {
        protected T Manager;

        protected StateMachine<T> StateMachine;

        protected State(StateMachine<T> SM, T manager)
        {
            StateMachine = SM;
            Manager = manager;
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
    }
}