namespace Assets.ApplicationStates
{
    public class StateMachine<T>
    {
        public State<T> CurrentState;

        public void Initialise(State<T> startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State<T> newState)
        {
            CurrentState.Exit();

            CurrentState = newState;

            CurrentState.Enter();
        }

        public void UpdateState()
        {
            CurrentState?.Update();
        }
    }
}