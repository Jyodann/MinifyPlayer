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

            var refresh_Token = PlayerPrefs.GetString("refresh_token", string.Empty);

            if (!refresh_Token.Equals(string.Empty))
            {
                MainManager.Instance.LoginManager.AuthToken.refresh_token = refresh_Token;

                MainManager.Instance.LoginManager.RefreshToken(true);
            }
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }
    }
}
