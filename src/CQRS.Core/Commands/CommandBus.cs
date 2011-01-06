using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CQRS.Core.Commands
{
    public class CommandBus
    {
        private readonly Dictionary<Type, Action<ICommand>> handlers  = new Dictionary<Type, Action<ICommand>>();

        public void Send<T>(T command) where T : ICommand
        {
            Action<ICommand> handler;
            handlers.TryGetValue(typeof (T), out handler);
            handler(command);
        }

        public void RegisterHandler<T>(Action<T> handler) where T : ICommand
        {
            handlers.Add(typeof(T), DelegateAdjuster.CastArgument<ICommand, T>(x => handler(x)));
        }
    }

    public class DelegateAdjuster
    {
        public static Action<BaseT> CastArgument<BaseT, DerivedT>(Expression<Action<DerivedT>> source) where DerivedT : BaseT
        {
            if (typeof(DerivedT) == typeof(BaseT))
            {
                return (Action<BaseT>)((Delegate)source.Compile());

            }
            ParameterExpression sourceParameter = Expression.Parameter(typeof(BaseT), "source");
            var result = Expression.Lambda<Action<BaseT>>(
                Expression.Invoke(
                    source,
                    Expression.Convert(sourceParameter, typeof(DerivedT))),
                sourceParameter);
            return result.Compile();
        }
    }
}