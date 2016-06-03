using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Reflection;
namespace MiniMvc
{
    public class ActionExecutor
    {
        private static Dictionary<MethodInfo, Func<object, object[], object>> executors = new Dictionary<MethodInfo, Func<object, object[], object>>();

        private static object syncHelper = new object();

        public MethodInfo MethodInfo { get; private set; }

        public ActionExecutor(MethodInfo method)
        {
            this.MethodInfo = method;
        }

        public object Execute(object target,object[] arguments)
        {
            Func<object, object[], object> executor;
            if (!executors.TryGetValue(this.MethodInfo, out executor))
            {
                lock (syncHelper)
                {
                    if (!executors.TryGetValue(this.MethodInfo, out executor))
                    {
                        executor = CreateExecutor(MethodInfo);
                        executors[MethodInfo] = executor;
                    }
                }
            }
            return executor(target, arguments);
        }
        private Func<object, object[], object> CreateExecutor(MethodInfo method)
        {
            ParameterExpression target = Expression.Parameter(typeof(object), "target");
            ParameterExpression arguments = Expression.Parameter(typeof(object[]), "arguments");

            List<Expression> parameters = new List<Expression>();
            ParameterInfo[] paraminfos = method.GetParameters();
            for (var i = 0; i < paraminfos.Length; i++)
            {
                ParameterInfo p = paraminfos[i];
                BinaryExpression getElementByIndex = Expression.ArrayIndex(arguments, Expression.Constant(i));
                UnaryExpression convertToparamenter = Expression.Convert(getElementByIndex,p.ParameterType);

                parameters.Add(convertToparamenter);
            }
            UnaryExpression instanceCast = Expression.Convert(target, method.ReflectedType);

            MethodCallExpression call = Expression.Call(instanceCast, method, parameters);

            UnaryExpression convertToObjectType = Expression.Convert(call,typeof(object));

            return Expression.Lambda<Func<object, object[], object>>(convertToObjectType, target, arguments).Compile();
        }

    }
}