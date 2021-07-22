using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    class Closed : IAccountState
    {
        public IAccountState Close() => this;

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
