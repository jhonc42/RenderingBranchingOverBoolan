using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            //Here you can see how the callback pattern helps
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(OnUnfreeze);

        // Due to the requirements said that we can not substract money before the own has been verified. The method Withdraw in the NotVerified State will do nothing.
        // this are the results of ABSTRACT INTERFACE, EXPLICIT STATE CLASS AND CALLBACK PATTERN.
        public IAccountState Withdraw(Action substractFromBalance) => this;
    }
}
