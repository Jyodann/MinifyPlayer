﻿using UnityEngine;

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
            if (Manager.LoginManager.GetRefreshTokenFromMemory(out var token))
            {
                Debug.Log(token);
                MainManager.Instance.LoginManager.SetRefreshToken(token);

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
