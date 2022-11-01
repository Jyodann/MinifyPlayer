namespace Assets.ApplicationStates
{
    public class LoginState : State<MainManager>
    {
        public LoginState(StateMachine<MainManager> SM, MainManager manager) : base(SM, manager)
        {
            
        }

        public override void Enter()
        {
            Manager.UIManager.ShowUI(UIManager.UI.Login);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            // Detect for Login:
            if (!Manager.LoginManager.isAuthorized) return;

            MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.MainState);
        }
    }
}
