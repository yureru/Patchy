using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace BankTests
{
    /// <summary>
    /// Tests provided for BankAccount testing, it covers all the use cases.
    /// We could improve it by creating a wrapper to create an OperationQuantities and BankAccount since
    /// they're used in every test method.
    /// </summary>
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Deposit_WithValidAmount_UpdatesBalance()
        {
            var operation = new OperationQuantities(20.99M, 11.3M, OperationQuantities.Operation.Deposit);

            var account = new BankAccount("Dennis", "Ritchie", operation.BeginningBalance);
            account.Deposit(operation.OperationAmount);

            AssertPlus.AreEqual(operation.Expected, account.Balance, 0.001M, "Account's deposit not implemented correctly.");
        }

        [TestMethod]
        public void Withdraw_WithValidAmount_UpdatesBalance()
        {
            var operation = new OperationQuantities(132.20M, 10.9M, OperationQuantities.Operation.Withdraw);

            var account = new BankAccount("Dennis", "Ritchie", operation.BeginningBalance);
            account.WithDraw(operation.OperationAmount);

            AssertPlus.AreEqual(operation.Expected, account.Balance, 0.001M, "Account's withdraw not implemented correctly.");
        }

        [TestMethod]
        public void Deposit_WithNegativeAmount_ShouldThrowArgumentOutOfRange()
        {
            var operation = new OperationQuantities(25.3M, -50M, OperationQuantities.Operation.Deposit);

            var account = new BankAccount("Dennis", "Ritchie", operation.BeginningBalance);

            try
            {
                account.Deposit(operation.OperationAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.AmountToDepositIsZeroOrLess);
                return;
            }

            Assert.Fail("Account allowed deposit of negative amount.");
        }

        [TestMethod]
        public void Withdraw_WithNegativeAmount_ShouldThrowArgumentOutOfRange()
        {
            var operation = new OperationQuantities(10.8M, -.1M, OperationQuantities.Operation.Withdraw);

            var account = new BankAccount("Dennis", "Ritchie", operation.BeginningBalance);

            try
            {
                account.WithDraw(operation.OperationAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.AmountToWithdrawIsZeroOrLess);
                return;
            }

            // Didn't raise an exception, therefore something is wrong.
            Assert.Fail("Account allowed witdrawing of negative amount.");
        }

        [TestMethod]
        public void Withdraw_WithFreezeAccount_ShouldThrowInvalidOperation()
        {
            var operation = new OperationQuantities(10.5M, 4.1M, OperationQuantities.Operation.Withdraw);

            var account = new BankAccount("Dennis", "Ritchie", operation.BeginningBalance);
            account.FreezeAccount();
            try
            {
                account.WithDraw(operation.OperationAmount);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, BankAccount.WithdrawingInFrozenAccount);
                return;
            }

            // Didn't raise an exception, therefore something is wrong.
            Assert.Fail("Account frozen allowed withdraw operation.");
        }

        [TestMethod]
        public void Deposit_WithFreezeAccount_ShouldThrowInvalidOperation()
        {
            var operation = new OperationQuantities(90.2M, 11.3M, OperationQuantities.Operation.Deposit);

            var account = new BankAccount("Dennis", "Ritchie", operation.BeginningBalance);
            account.FreezeAccount();

            try
            {
                account.Deposit(operation.OperationAmount);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DepositInFrozenAccount);
                return;
            }

            // Didn't raise an exception, therefore something is wrong.
            Assert.Fail("Account frozen allowed deposit operation.");
        }

        #region Helper Methods

        #endregion // Helper Methods

    }
}
