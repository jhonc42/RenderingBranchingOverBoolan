using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    class Account
    {
        public decimal Balance { get; private set; }
        public bool IsVerified { get; set; }
        public bool IsClosed { get; set; }

        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }
        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return; // Or do something
            this.ManageUnfreezing();
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return; // Or do something...
            if (this.IsClosed)
                return; // Or do something else...
            this.ManageUnfreezing();
            this.Balance -= amount;
        }


        private void Unfreeze()
        {
            this.OnUnfreeze();
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        private void StayUnfrozen() { }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }
        public void Close()
        {
            this.IsVerified = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return; // Account must not be closed
            if (!this.IsVerified)
                return; // Account must be verified
            this.ManageUnfreezing = this.Unfreeze;
        }
    }
}
