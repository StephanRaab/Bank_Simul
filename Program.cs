using System;
using System.Collections.Generic;

namespace Bank_Simul {
    class Program {
        static void Main (string[] args) {}

         public static Bank CreateNewBankAccount (string _bankName) {
            Bank newBank = new Bank ();
            newBank.Name = _bankName;
            newBank.Accounts = new List<Account> ();
            newBank.Accounts.Add (new Account () { Owner_Id = 0, Balance = 0, Type = "checking" });
            newBank.Accounts.Add (new Account () { Owner_Id = 0, Balance = 0, Type = "corporate_invest" });
            newBank.Accounts.Add (new Account () { Owner_Id = 0, Balance = 0, Type = "individual_invest" });

            return newBank;
        }

        public static float Withdraw (float withdrawalAmount, Account startAccount) {
            //exceptions:
            if (startAccount.Type == "individual_invest" && withdrawalAmount > 1000){
                return startAccount.Balance;
            }
            if ((startAccount.Balance - withdrawalAmount) >= 0){
                startAccount.Balance -= withdrawalAmount;            
            }

            return startAccount.Balance;
        }

        public static float Deposit (float depositAmount, Account targetAccount) {
            targetAccount.Balance += depositAmount;
            return targetAccount.Balance;
        }

        public static void Transfer (float transferAmount, Account startAccount, Account targetAccount) {
            Withdraw (transferAmount, startAccount);
            if (startAccount.Type == "individual_invest" && transferAmount <= 1000){
                Deposit(transferAmount, targetAccount);
            }
            if (startAccount.Type != "individual_invest"){
                Deposit(transferAmount, targetAccount);
            }
        }

    }
}