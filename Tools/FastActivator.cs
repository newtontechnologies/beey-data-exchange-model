using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Beey.DataExchangeModel.Tools
{
    class FastActivator<T> where T : class
    {
        private static readonly Type tType = typeof(T);
        private delegate T ObjectActivator(params object[] args);

        public static T CreateInstance()
            => CreateInstance(new Type[0], new object[0]);
        public static T CreateInstance(params object[] argsWithValue)
            => CreateInstance(argsWithValue.Select(a => a.GetType()).ToArray(), argsWithValue);
        public static T CreateInstance(Type[] argTypes, params object[] args)
            => CreateInstance(GetConstructor(argTypes), args);
        public static T CreateInstance(ConstructorInfo constructorInfo, params object[] args)
        {
            if (constructorInfo == null)
            {
                throw new ArgumentNullException(nameof(constructorInfo));
            }
            var activator = GetActivator(constructorInfo);
            return activator.Invoke(args);
        }

        private static ConstructorInfo GetConstructor(Type[] argTypes)
        {
            return tType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, argTypes, null);
        }

        private static ObjectActivator GetActivator(ConstructorInfo constructor)
        {
            Type type = constructor.DeclaringType;
            ParameterInfo[] parameterInfos = constructor.GetParameters();

            //create a single param of type object[]
            ParameterExpression param =
                Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp =
                new Expression[parameterInfos.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = parameterInfos[i].ParameterType;

                Expression parameterAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression parameterCastExp =
                    Expression.Convert(parameterAccessorExp, paramType);

                argsExp[i] = parameterCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(constructor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            LambdaExpression lambda =
                Expression.Lambda(typeof(ObjectActivator), newExp, param);

            //compile it
            ObjectActivator compiled = (ObjectActivator)lambda.Compile();
            return compiled;
        }
    }
}
