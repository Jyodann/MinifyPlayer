using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.ApplicationStates
{
    public class LoginState : State<MainManager>
    {
        private bool isLoggedIn = false;
        private bool isAttemptingLogin = false;
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
            if (!Manager.AuthToken.IsActvated) return;

            if (!isAttemptingLogin)
            {
                isAttemptingLogin = true;
                Manager.StartCoroutine(AttemptLogin());
            }
        }

        IEnumerator AttemptLogin()
        {
            using (var request = Manager.GetUnityWebRequestObject("https://api.spotify.com/v1/me", MainManager.RequestMethods.GET))
            {
                yield return request.SendWebRequest();
                Debug.Log(request.downloadHandler.text);
                if (request.result == UnityWebRequest.Result.ConnectionError)
                {
                    StateMachine.ChangeState(Manager.ConnectionErrorState);
                }
            } 
        }
    }
}
