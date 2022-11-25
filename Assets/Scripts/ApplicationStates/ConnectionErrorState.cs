using System.Collections;
using UnityEngine;

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
                Debug.Log(TimeToAttempt);
                if (TimeToAttempt == 0)
                {
                    Debug.Log("Connecting back...");
                    using var response = Manager.GetUnityWebRequestObject("https://api.spotify.com/v1/me", MainManager.RequestMethods.GET);
                    yield return response.SendWebRequest();
                    TimeToAttempt = 5;
                    if (response.result != UnityEngine.Networking.UnityWebRequest.Result.ConnectionError)
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
}
