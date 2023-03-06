﻿namespace UglyToad.PdfPig.Functions.Type4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides the conditional operators such as "if" and "ifelse".
    /// </summary>
    internal sealed class ConditionalOperators
    {
        private ConditionalOperators()
        {
            // Private constructor.
        }

        /// <summary>
        /// Implements the "if" operator.
        /// </summary>
        internal sealed class If : Operator
        {
            public void Execute(ExecutionContext context)
            {
                Stack<object> stack = context.GetStack();
                InstructionSequence proc = (InstructionSequence)stack.Pop();
                bool condition = (bool)stack.Pop();
                if (condition)
                {
                    proc.Execute(context);
                }
            }
        }

        /// <summary>
        /// Implements the "ifelse" operator.
        /// </summary>
        internal sealed class IfElse : Operator
        {
            public void Execute(ExecutionContext context)
            {
                Stack<object> stack = context.GetStack();
                InstructionSequence proc2 = (InstructionSequence)stack.Pop();
                InstructionSequence proc1 = (InstructionSequence)stack.Pop();
                bool condition = Convert.ToBoolean(stack.Pop());
                if (condition)
                {
                    proc1.Execute(context);
                }
                else
                {
                    proc2.Execute(context);
                }
            }
        }
    }
}