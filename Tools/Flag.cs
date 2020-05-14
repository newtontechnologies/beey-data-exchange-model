using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Beey.DataExchangeModel.Tools
{
    public class Flag<T>
        where T : IEquatable<T>
    {
        public Node<T> Tree { get; }

        public Flag(T value) : this(new OperandNode<T>(value))
        { 
        }
        public Flag(Node<T> tree)
        {
            this.Tree = tree;
        }

        public static implicit operator Flag<T>(T value) => new Flag<T>(value);

        public static Flag<T> operator &(Flag<T> first, Flag<T> second)
            => new Flag<T>(new OperatorNode<T>(Operator.And, first, second));
        public static Flag<T> operator &(T first, Flag<T> second)
            => new Flag<T>(new OperatorNode<T>(Operator.And, first, second));
        public static Flag<T> operator &(Flag<T> first, T second)
            => new Flag<T>(new OperatorNode<T>(Operator.And, first, second));

        public static Flag<T> operator |(Flag<T> first, Flag<T> second)
            => new Flag<T>(new OperatorNode<T>(Operator.Or, first, second));
        public static Flag<T> operator |(T first, Flag<T> second)
            => new Flag<T>(new OperatorNode<T>(Operator.Or, first, second));
        public static Flag<T> operator |(Flag<T> first, T second)
            => new Flag<T>(new OperatorNode<T>(Operator.Or, first, second));

        public static Flag<T> operator ~(Flag<T> flag)
            => new Flag<T>(new OperatorNode<T>(Operator.Not, flag));

        public SettableFlag<T> CreateSettableFlag() => new SettableFlag<T>(this);
        public bool HasFlag(T value) => Tree.Evaluate(value);
    }
}
