using System.Collections;
using System.Collections.Generic;

namespace Bank_Simul {
    public class Bank {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }

        public static Bank CreateNewBankAccount (string _bankName) {
            Bank newBank = new Bank ();
            newBank.Name = _bankName;
            newBank.Accounts = new List<Account> ();
            newBank.Accounts.Add (new Account () { Owner = 0, Balance = 0, Type = "checking" });
            newBank.Accounts.Add (new Account () { Owner = 0, Balance = 0, Type = "corporate_invest" });
            newBank.Accounts.Add (new Account () { Owner = 0, Balance = 0, Type = "individual_invest" });

            return newBank;
        }
    }
}