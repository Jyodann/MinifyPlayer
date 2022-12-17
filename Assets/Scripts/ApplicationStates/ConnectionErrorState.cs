using System.Collections;
using Assets.Managers;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.ApplicationStates
{
    public class ConnectionErrorState : State<MainManager>
    {
        public int TimeToAttempt = 5;

        public ConnectionErrorState(StateMachine<MainManager> SM, MainManager manager) : base(SM, manager)
        {
        }

        public override void Enter()
        {
            Manager.UIManager.ShowUI(UIManager.UI.ConnectionError);
            ConnectBack();
        }

        private void ConnectBack()
        {
            Manager.StartCoroutine(AttemptToConnectBack());
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }

        private IEnumerator AttemptToConnectBack()
        {
            while (TimeToAttempt > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                TimeToAttempt -= 1;
                if (TimeToAttempt != 0) continue;
                using var response = Manager.GetUnityWebRequestObject("https://api.spotify.com/v1/me",
                    MainManager.RequestMethods.Get);
                yield return response.SendWebRequest();
                TimeToAttempt = 5;
                if (response.result != UnityWebRequest.Result.ConnectionError)
                {
                    StateMachine.ChangeState(Manager.LoginState);
                    yield break;
                }

                ConnectBack();
                yield break;
            }
        }
    }
}