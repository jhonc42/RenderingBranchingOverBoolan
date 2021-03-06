using System;
using System.Collections.Generic;
using System.Text;

namespace BranchComplexToStatePart1
{
    class Account
    {
        public decimal Balance { get; private set; }
        //public bool IsVerified { get; set; }
        //public bool IsClosed { get; set; }

        // private Action OnUnfreeze { get; }
        private IAccountState State { get; set; }
        // private Action ManageUnfreezing { get; set; }
        public Account(Action onUnfreeze)
        {
            // this.OnUnfreeze = onUnfreeze;
            // this.ManageUnfreezing = this.StayUnfrozen;
            State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            //if (this.IsClosed)
            //    return; // Or do something
            // this.ManageUnfreezing();

            this.State = this.State.Deposit(() => { this.Balance += amount; });
            
            //this.State = this.State.Deposit();
            //this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            //if (!this.IsVerified)
            //    return; // Or do something...
            //if (this.IsClosed)
            //    return; // Or do something else...
            // this.ManageUnfreezing();

            this.State = this.State.Withdraw(() => { this.Balance -= amount; });

            //this.State = this.State.Withdraw();
            //this.Balance -= amount;
        }

        // I wanted to extract this methods of the responsability of this class.
        //private void Unfreeze()
        //{
        //    this.OnUnfreeze();
        //    this.ManageUnfreezing = this.StayUnfrozen;
        //}

        //private void StayUnfrozen() { }

        public void HolderVerified()
        {
            // this.IsVerified = true;
            this.State = this.State.HolderVerified();
        }
        public void Close()
        {
            // this.IsVerified = true;
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            //if (this.IsClosed)
            //    return; // Account must not be closed
            //if (!this.IsVerified)
            //    return; // Account must be verified
            //this.ManageUnfreezing = this.Unfreeze;
            this.State = this.State.Freeze();
        }
    }
}
