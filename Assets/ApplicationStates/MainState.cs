using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ApplicationStates
{
    public class MainState : State<MainManager>
    {
        public MainState(StateMachine<MainManager> SM, MainManager manager) : base(SM, manager)
        {
        }

        public override void Enter()
        {
            Manager.UIManager.ShowUI(UIManager.UI.Main);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}
