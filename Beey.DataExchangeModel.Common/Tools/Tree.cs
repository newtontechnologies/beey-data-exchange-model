using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beey.DataExchangeModel.Tools
{
    public abstract class Node<T>
        where T : IEquatable<T>
    {
        public static implicit operator Node<T>(Flag<T> flag) => flag.Tree;
        public abstract bool Evaluate(T value);
    }

    public enum Operator { And, Or, Not }
    public class OperatorNode<T> : Node<T>
        where T : IEquatable<T>
    {
        public Operator Operation { get; }
        public Node<T>[] Nodes { get; }

        public OperatorNode(Operator operation, params Flag<T>[] flags) : this(operation, flags.Select(f => f.Tree).ToArray())
        { }
        public OperatorNode(Operator operation, params Node<T>[] nodes)
        {
            this.Operation = operation;
            this.Nodes = nodes;
        }

        public override bool Evaluate(T value)
        {
            return Operation switch
            {
                Operator.And => Nodes.Aggregate(true, (b, n) => b && n.Evaluate(value)),
                Operator.Or => Nodes.Aggregate(false, (b, n) => b || n.Evaluate(value)),
                Operator.Not => Nodes.Length == 1 ? !Nodes.First().Evaluate(value) : throw new InvalidOperationException("Multiple operands for unary 'Not' operator."),
                _ => throw new InvalidOperationException("Unknown operator.")
            };
        }
    }

    public class OperandNode<T> : Node<T>
        where T : IEquatable<T>
    {
        private readonly T value;
        public OperandNode(T value)
        {
            this.value = value;
        }

        public override bool Evaluate(T value)
            => this.value.Equals(value);

        public static implicit operator OperandNode<T>(T value) => new OperandNode<T>(value);
    }
}
