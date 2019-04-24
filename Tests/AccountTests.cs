using System;
using System.Collections.Generic;
using Xunit;

namespace Bank_Simul {
    public class AccountTests {
        [Fact]
        public void Withdraw () {
            // Arrange
            float expected = 750F;

            Account corpInvest = new Account ();
            corpInvest.Balance = 1000F;
            corpInvest.Type = "corporate_invest";

            // Act
            float actual = Account.Withdraw (250F, corpInvest);

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
            float actual = Account.Deposit (250F, checking);

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
            Account.Transfer (5000F, corporate_invest, checking);

            // Assert
            Assert.Equal (expectedChecking, checking.Balance);
            Assert.Equal (expectedCorp, corporate_invest.Balance);
        }

        [Fact]
        public void Withdraw_Overdraft () {
            // Arrange
            float expected = 1000F;

            Account checking = new Account ();
            checking.Balance = 1000F;
            checking.Type = "checking";

            // Act
            float actual = Account.Withdraw (1250F, checking);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Individual_Withdrawal_Cap(){
            // Arrange
            float expected = 40_637F;

            Account individual = new Account();
            individual.Balance = 40_637F;
            individual.Type = "individual_invest";

            // Act
            float actual = Account.Withdraw(5000F, individual);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Individual_Transfer_Cap(){
            // Arrange
            float expectedChecking = 6000F;
            float expectedindiv = 63_000F;

            Account checking = new Account ();
            checking.Balance = 1000F;
            checking.Type = "checking";

            Account individual_invest = new Account ();
            individual_invest.Balance = 100_000F;
            individual_invest.Type = "individual_invest";

            // Act
            Account.Transfer (5000F, individual_invest, checking);

            // Assert
            Assert.Equal (expectedChecking, checking.Balance);
            Assert.Equal (expectedCorp, individual_invest.Balance);
        }
    }
}