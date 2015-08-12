using System;
using System.Collections.Generic;

namespace Marsman.Toolkit
{
    public static class ActionExtensions
    {
        private static Dictionary<IAsyncResult, Action> _invokedActions = new Dictionary<IAsyncResult, Action>();

        public static void FireAndForget(this Action action, object state = null)
        {
            lock (_invokedActions)
            {
                _invokedActions.Add(action.BeginInvoke(Forget, state), action);
            }
        }

        private static void Forget(IAsyncResult result)
        {
            lock (_invokedActions)
            {
                _invokedActions[result].EndInvoke(result);
                _invokedActions.Remove(result);
            }
        }
    }
}