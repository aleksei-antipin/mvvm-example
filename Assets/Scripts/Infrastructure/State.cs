using UnityEngine;

namespace Test.Infrastructure
{
    public abstract class State
    {
        protected virtual void OnStateEnter()
        {
        }

        protected virtual void OnStateExit()
        {
        }

        #region Methods

        public void Enter()
        {
            OnStateEnter();
        }

        public void Exit()
        {
            OnStateExit();
        }

        #endregion
    }
}