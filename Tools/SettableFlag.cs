using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beey.DataExchangeModel.Tools
{
    public class SettableFlag<T> : Flag<T>
        where T : IEquatable<T>
    {
        private readonly object locker = new object();
        private readonly bool[] leafMemory;

        private int currentLeafIndex;

        public bool CurrentEvaluation { get; private set; }

        public SettableFlag(Flag<T> flag) : base(flag.Tree)
        {
            leafMemory = CreateLeafMemory(Tree);
        }

        public void Reset()
        {
            for (int i = 0; i < leafMemory.Length; i++)
            {
                leafMemory[i] = false;
            }
        }
        public bool SetFlag(T value)
        {
            lock (locker)
            {
                currentLeafIndex = 0;
                CurrentEvaluation = Evaluate(Tree, value);
                return CurrentEvaluation;
            }
        }

        private static bool[] CreateLeafMemory(Node<T> tree)
        {
            var result = new List<bool>();
            var stack = new Stack<Node<T>>();
            stack.Push(tree);
            do
            {
                var current = stack.Pop();
                if (current is OperandNode<T> leaf)
                {
                    result.Add(false);
                }
                if (current is OperatorNode<T> operation)
                {
                    foreach (var node in operation.Nodes)
                    {
                        stack.Push(node);
                    }
                }
            } while (stack.Count > 0);
            return result.ToArray();
        }

        private bool Evaluate(Node<T> node, T value)
        {
            if (node is OperandNode<T> leaf)
            {
                bool result = leafMemory[currentLeafIndex] = (leafMemory[currentLeafIndex] || node.Evaluate(value));
                currentLeafIndex++;
                return result;
            }
            else
            {
                var operatorNode = node as OperatorNode<T>;
                var results = operatorNode.Nodes.Select(n => Evaluate(n, value));
                return operatorNode.Operation switch
                {
                    Operator.And => results.Aggregate((a, b) => a && b),
                    Operator.Or => results.Aggregate((a, b) => a || b),
                    Operator.Not => !results.First(),
                    _ => throw new InvalidOperationException("Unkwnown, operator."),
                };

            }
        }

        public static implicit operator bool(SettableFlag<T> flag) => flag.CurrentEvaluation;
    }
}
