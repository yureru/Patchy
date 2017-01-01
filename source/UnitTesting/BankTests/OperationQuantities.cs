using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTests
{
    /// <summary>
    /// Simple wrapper to specify quantities and an operation to make in a BankAccount class.
    /// </summary>
    struct OperationQuantities
    {
        public enum Operation
        {
            Deposit, Withdraw
        };

        Operation _operation;
        public decimal BeginningBalance { get; private set; }
        public decimal OperationAmount { get; private set; }
        public decimal Expected
        {
            get
            {
                switch (_operation)
                {
                    case Operation.Deposit:
                        return BeginningBalance + OperationAmount;
                    case Operation.Withdraw:
                        return BeginningBalance - OperationAmount;
                    default:
                        throw new InvalidOperationException("Operation not specified");
                }
            }
        }

        #region Constructors

        public OperationQuantities(decimal begginingBalance, decimal operationAmmount, Operation operation)
        {
            BeginningBalance = begginingBalance;
            OperationAmount = operationAmmount;
            _operation = operation;
        }

        #endregion // Constructors

    }
}
