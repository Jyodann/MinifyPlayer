using UnityEngine;

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Purposely Expire code:
                MainManager.Instance.LoginManager.RefreshToken();
            }
        }
    }
}
