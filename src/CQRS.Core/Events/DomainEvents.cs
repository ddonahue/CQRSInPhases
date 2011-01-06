using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Core.Events
{
    public static class DomainEvents
    { 
        private static List<Delegate> actions;
        
        //Registers a callback for the given domain event
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }
        
        //Raises the given domain event
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (actions == null) return;

            foreach (var action in actions.OfType<Action<T>>())
            {
                action(args);
            }
        }
    } 
}