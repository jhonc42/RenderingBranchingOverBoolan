using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    class Active : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IFreezable Deposit() => this;
        public IFreezable Withdraw() => this;

        public IFreezable Freeze() => new Frozen(this.OnUnfreeze);
    }
}
