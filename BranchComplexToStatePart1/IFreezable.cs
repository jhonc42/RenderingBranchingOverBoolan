using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();
    }
}
