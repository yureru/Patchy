using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class BankAccount
    {

        #region Private Members

        decimal _balance;
        string _name, _lastName;
        bool _isFrozen;

        #endregion // Private Members

        #region Public Members

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        #endregion // Public Members

        #region Exception Messages

        public const string AmountToWithdrawIsBiggerThanBalance
            = "The amount desired to withdraw is bigger than the current funds.";

        public const string AmountToWithdrawIsZeroOrLess
            = "Can't withdraw a quantity equal or less than zero.";

        public const string AmountToDepositIsZeroOrLess
            = "Can't deposit a quantity equal or less than zero.";

        public const string AccountIsFrozen
            = "Account is currently frozen.";

        public const string WithdrawingInFrozenAccount
            = "Can't withdraw, account currently frozen.";

        public const string DepositInFrozenAccount
            = "Can't deposit, account currently frozen.";

        #endregion // Exception Messages

        #region Constructors

        private BankAccount() { }

        public BankAccount(string name, string lastName, decimal begginingBalance)
        {
            _name = name;
            _lastName = lastName;
            Deposit(begginingBalance);
        }

        #endregion // Constructors

        #region Public Methods

        /// <summary>
        /// Retires some funds.
        /// </summary>
        /// <param name="amount">A positive non-zero number.</param>
        public void WithDraw(decimal amount)
        {
            CheckIfAccountIsFrozen(WithdrawingInFrozenAccount);

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException(AmountToWithdrawIsBiggerThanBalance);
            }

            AmountGreaterThanZero(amount, AmountToWithdrawIsZeroOrLess);

            _balance -= amount;
        }

        /// <summary>
        /// Deposits some funds.
        /// </summary>
        /// <param name="amount">A positive non-zero number.</param>
        public void Deposit(decimal amount)
        {
            CheckIfAccountIsFrozen(DepositInFrozenAccount);
            AmountGreaterThanZero(amount, AmountToDepositIsZeroOrLess);

            _balance += amount;
        }

        public void FreezeAccount()
        {
            _isFrozen = true;
        }

        public void UnfreezeAccount()
        {
            _isFrozen = false;
        }

        public void PrintCurrentFunds()
        {
            Console.WriteLine("Current funds are $" + Balance);
        }

        #endregion // Public Methods

        #region Validations

        static void AmountGreaterThanZero(decimal amount, string message)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        void CheckIfAccountIsFrozen(string messageError)
        {
            if (_isFrozen)
            {
                throw new InvalidOperationException(messageError);
            }
        }

        #endregion // Validations

    }
}
