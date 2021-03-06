using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace RulesEngine
{
    public class ForClassEndIf<T, ENDIF> : IMustPassRule<ForClassEndIf<T, ENDIF>, T, T>
    {
        private Engine _rulesEngine;
        private ENDIF _parent;
        private ConditionalInvoker<T> _conditionalInvoker;
        private IRule _lastRule;

        internal ForClassEndIf(Engine rulesEngine, ConditionalInvoker<T> conditionalInvoker, ENDIF parent)
        {
            _rulesEngine = rulesEngine;
            _parent = parent;
            _conditionalInvoker = conditionalInvoker;
        }
        public SetupClassEndIf<T, R, ENDIF> Setup<R>(Expression<Func<T, R>> expression)
        {
            return new SetupClassEndIf<T, R, ENDIF>(_rulesEngine, this, expression);
        }

        public ForClassEndIf<T, ENDIF> MustPassRule(IRule<T> rule)
        {
            Expression<Func<T, T>> expression = t => t;
            _rulesEngine.RegisterRule<T, T>(rule, expression, expression);
            _lastRule = rule;
            return this;
        }
        public ForClassElseEndIf<T, ForClassEndIf<T, ENDIF>> If(Expression<Func<T, bool>> conditionalExpression)
        {
            var invoker = _rulesEngine.RegisterCondition(conditionalExpression);
            return new ForClassElseEndIf<T, ForClassEndIf<T, ENDIF>>(invoker.IfTrueEngine, invoker, this);
        }
        public ENDIF EndIf()
        {
            return _parent;
        }
        public Expression<Func<T, T>> Expression
        {
            get
            {
                return Utilities.ReturnSelf<T>();
            }
        }

        /// <summary>
        /// Gets RulesEngine
        /// </summary>
        public Engine RulesEngine
        {
            get { return _rulesEngine; }
        }



        public ForClassEndIf<T, ENDIF> GetSelf()
        {
            return this;
        }


        public IRule LastRule
        {
            get { return _lastRule; }
        }
    }
}
