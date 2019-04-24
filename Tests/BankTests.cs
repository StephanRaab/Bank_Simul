using System;
using System.Collections.Generic;
using Xunit;

namespace Bank_Simul {

    public class BankTests {
        [Fact]
        public void CreateBankAccount () {
            // Arrange
            List<Account> accounts = new List<Account> ();
            accounts.Add (new Account () { Owner_Id = 0, Balance = 0, Type = "checking" });
            accounts.Add (new Account () { Owner_Id = 0, Balance = 0, Type = "corporate_invest" });
            accounts.Add (new Account () { Owner_Id = 0, Balance = 0, Type = "individual_invest" });

            Bank expectedBank = new Bank {
                Name = "Money Hoarder",
                Accounts = accounts
            };

            //Act
            Bank actualBank = Bank.CreateNewBankAccount ("Money Hoarder");

            // Assert
            Assert.Equal (expectedBank.Name, actualBank.Name);
            Assert.Equal (expectedBank.Accounts.Count, actualBank.Accounts.Count);
        }
    }
}