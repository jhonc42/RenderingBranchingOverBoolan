using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    interface IAccountState
    {
        // the action will execute when the situation will be correct to add money to balance
        IAccountState Deposit(Action addToBalance);
        // the action will execute after everithing must be done to updating balance
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
