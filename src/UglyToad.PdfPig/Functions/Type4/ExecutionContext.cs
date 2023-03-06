﻿namespace UglyToad.PdfPig.Functions.Type4
{
    using System;
    using System.Collections.Generic;

    internal sealed class ExecutionContext
    {
        private readonly Operators operators;
        private Stack<object> stack = new Stack<object>();

        /// <summary>
        /// Creates a new execution context.
        /// </summary>
        /// <param name="operatorSet">the operator set</param>
        public ExecutionContext(Operators operatorSet)
        {
            this.operators = operatorSet;
        }

        /// <summary>
        /// Returns the stack used by this execution context.
        /// </summary>
        /// <returns>the stack</returns>
        public Stack<object> GetStack()
        {
            return this.stack;
        }

        internal Stack<object> SetStack(Stack<object> stack)
        {
            this.stack = stack;
            return this.stack;
        }

        /// <summary>
        /// Returns the operator set used by this execution context.
        /// </summary>
        /// <returns>the operator set</returns>
        public Operators GetOperators()
        {
            return this.operators;
        }

        /// <summary>
        /// Pops a number (int or real) from the stack. If it's neither data type, a <see cref="InvalidCastException"/> is thrown.
        /// </summary>
        /// <returns>the number</returns>
        public object PopNumber()
        {
            object popped = this.stack.Pop();
            if (popped is int || popped is double || popped is float)
            {
                return popped;
            }
            throw new InvalidCastException("The object popped is neither an integer or a real.");
        }

        /// <summary>
        /// Pops a value of type int from the stack. If the value is not of type int, a <see cref="InvalidCastException"/> is thrown.
        /// </summary>
        /// <returns>the int value</returns>
        public int PopInt()
        {
            object popped = stack.Pop();
            if (popped is int poppedInt)
            {
                return poppedInt;
            }
            throw new InvalidCastException("PopInt cannot be done as the value is not integer");
        }

        /// <summary>
        /// Pops a number from the stack and returns it as a real value. If the value is not of a numeric type,
        /// a <see cref="InvalidCastException"/> is thrown.
        /// </summary>
        /// <returns>the real value</returns>
        public double PopReal()
        {
            return Convert.ToDouble(stack.Pop());
        }
    }
}