using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IFreezable Deposit()
        {
            OnUnfreeze();
            return new Active(OnUnfreeze);
        }

        public IFreezable Withdraw()
        {
            OnUnfreeze();
            return new Active(OnUnfreeze);
        }

        public IFreezable Freeze() => this;
    }
}
