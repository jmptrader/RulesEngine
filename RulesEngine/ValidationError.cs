using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace RulesEngine
{
    public class ValidationError
    {
        private IRule _rule;
        private EquatableExpression _expression;
        private object[] _validationArguments;
        private object _value;

        /// <summary>
        /// Gets Rule
        /// </summary>
        public IRule Rule
        {
            get { return _rule; }
        }

        /// <summary>
        /// Gets Expression
        /// </summary>
        public EquatableExpression Expression
        {
            get { return _expression; }
        }

        /// <summary>
        /// Gets ValidationArguments
        /// </summary>
        public object[] ValidationArguments
        {
            get { return _validationArguments; }
        }

        /// <summary>
        /// Gets Value
        /// </summary>
        public object Value
        {
            get { return _value; }
        }

        public ValidationError(IRule rule, EquatableExpression expression, object[] validationArguments, object value)
        {
            if (validationArguments == null) throw new System.ArgumentNullException("validationArguments");
            if (value == null) throw new System.ArgumentNullException("value");
            if (expression == null) throw new System.ArgumentNullException("cachedExpression");
            if (rule == null) throw new System.ArgumentNullException("rule");

            _rule = rule;
            _expression = expression;
            _validationArguments = validationArguments;
            _value = value;
        }
    }
}
