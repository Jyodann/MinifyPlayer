using Assets.Managers;
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
            MainManager.Instance.UIManager.SetLoginErrorText(string.Empty);
            Manager.UIManager.SetVersionText($"{Application.productName} v{Application.version}");

            if (!Manager.LoginManager.GetRefreshTokenFromMemory(out var token))
                return;

            MainManager.Instance.LoginManager.SetRefreshToken(token);
            MainManager.Instance.LoginManager.RefreshToken(true);
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }
    }
}