using System;
using System.Collections.Generic;
using Xunit;

namespace Bank_Simul {
    public class AccountTests {
        [Fact]
        public void Withdraw () {
            // Expect regular withdrawal
            float expected = 750F;

            Account corpInvest = new Account ();
            corpInvest.Balance = 1000F;
            corpInvest.Type = "corporate_invest";

            // Act
            float actual = Program.Withdraw (250F, corpInvest);

            // Assert
            Assert.Equal (expected, actual);
        }

        [Fact]
        public void Deposit () {
            // Arrange
            float expected = 1250F;

            Account checking = new Account ();
            checking.Balance = 1000F;
            checking.Type = "checking";

            // Act
            float actual = Program.Deposit (250F, checking);

            // Assert
            Assert.Equal (expected, actual);
        }

        [Fact]
        public void Transfer () {
            // Arrange
            float expectedChecking = 6000F;
            float expectedCorp = 95_000F;

            Account checking = new Account ();
            checking.Balance = 1000F;
            checking.Type = "checking";

            Account corporate_invest = new Account ();
            corporate_invest.Balance = 100_000F;
            corporate_invest.Type = "corporate_invest";

            // Act
            Program.Transfer (5000F, corporate_invest, checking);

            // Assert
            Assert.Equal (expectedChecking, checking.Balance);
            Assert.Equal (expectedCorp, corporate_invest.Balance);
        }

        [Fact]
        public void Withdraw_Overdraft () {
            // Expect withdrawal not to go through if it would overdraft their account
            float expected = 1000F;

            Account checking = new Account ();
            checking.Balance = 1000F;
            checking.Type = "checking";

            // Act
            float actual = Program.Withdraw (1250F, checking);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Individual_Withdrawal_Cap(){
            // Expect withdrawal over 1000 from an individual investment account to fail
            float expected = 40_637F;

            Account individual = new Account();
            individual.Balance = 40_637F;
            individual.Type = "individual_invest";

            // Act
            float actual = Program.Withdraw(5000F, individual);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Individual_Transfer_Cap(){
            // Expect a transfer of more than 1000 from an individual investment account to fail
            float expectedChecking = 1000F;
            float expectedIndiv = 67_000F;

            Account checking = new Account ();
            checking.Balance = 1000F;
            checking.Type = "checking";

            Account individual_invest = new Account ();
            individual_invest.Balance = 67_000F;
            individual_invest.Type = "individual_invest";

            // Act
            Program.Transfer (5000F, individual_invest, checking);

            // Assert
            Assert.Equal (expectedChecking, checking.Balance);
            Assert.Equal (expectedIndiv, individual_invest.Balance);
        }

        [Fact]
        public void Check_Owner(){
            // Expect every bank account to have an owner_id
            int expectedOwnerId = 0;

            // Act
            Bank testBank = Program.CreateNewBankAccount("Money Hoarder");

            // Assert
            foreach (Account _account in testBank.Accounts)
            {
                Assert.Equal(expectedOwnerId, _account.Owner_Id);
            }
        }
    }
}