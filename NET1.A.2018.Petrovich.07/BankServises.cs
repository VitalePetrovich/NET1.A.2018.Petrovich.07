using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Petrovich._07
{
    /// <summary>
    /// Abstract class for bank services. 
    /// </summary>
    public abstract class AbstractBankService
    {
        protected IRepository repository;
        
        protected AbstractBankService(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Return new bank account.
        /// </summary>
        /// <param name="name">
        /// Holder name.
        /// </param>
        /// <param name="email">
        /// Holder email.
        /// </param>
        /// <param name="accountFactory">
        /// Factory for current account status.
        /// </param>
        public abstract void NewAccount(string name, string email, AbstractAccountFactory accountFactory);

        /// <summary>
        /// Close current account.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        public abstract void CloseAccount(string accNumber);

        /// <summary>
        /// Deposit to current account.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <param name="amount">
        /// Amount of deposit.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if deposit amount less than 0.
        /// </exception>>
        public void Deposit(string accNumber, decimal amount)
        {
            if (string.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException(nameof(accNumber));

            if (amount < 0)
                throw new ArgumentException($"Deposit amount ({nameof(amount)}) must be more than 0");

            AbstractAccount tempAcc = repository.GetAccount(accNumber);

            tempAcc.Balance += amount;
            tempAcc.BonusPoints += CalculateBonusPoints(tempAcc.Status, amount);

            repository.Save(tempAcc);
        }

        /// <summary>
        /// Withdraw from current account.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <param name="amount">
        /// Amount of withdraw.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if withdraw amount less than 0.
        /// </exception>>
        public void Withdraw(string accNumber, decimal amount)
        {
            if (string.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException(nameof(accNumber));

            if (amount < 0)
                throw new ArgumentException($"Withdraw amount ({nameof(amount)}) must be more than 0");

            AbstractAccount tempAcc = repository.GetAccount(accNumber);

            if ((tempAcc.Balance - tempAcc.MinEdgeWithdraw) < amount)
                throw new Exception("Not enough money");

            tempAcc.Balance -= amount;
            tempAcc.BonusPoints -= CalculateBonusPoints(tempAcc.Status, amount);

            repository.Save(tempAcc);
        }

        /// <summary>
        /// Method contain logic of calculating bonus points.
        /// </summary>
        /// <param name="status">
        /// Status of current account.
        /// </param>
        /// <param name="amount">
        /// Amount money for operation.
        /// </param>
        /// <returns>
        /// Amount of bonus points.
        /// </returns>
        protected abstract int CalculateBonusPoints(AccStatus status, decimal amount);
    }

    /// <summary>
    /// Bank service class.
    /// </summary>
    public sealed class BankService : AbstractBankService
    {
        /// <summary>
        /// Bank service ctor.
        /// </summary>
        /// <param name="repository">
        /// Repository.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if repository is null.
        /// </exception>
        public BankService(IRepository repository) : base(repository)
        {
        }
        
        /// <summary>
        /// Close current account.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if account number is null.
        /// </exception>
        public override void CloseAccount(string accNumber)
        {
            if (string.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException(nameof(accNumber));
            
            repository.DeleteAccount(accNumber);
        }

        /// <summary>
        /// Add new account to repository.
        /// </summary>
        /// <param name="name">
        /// Holder name.
        /// </param>
        /// <param name="email">
        /// Holder e-mail.
        /// </param>
        /// <param name="accountFactory">
        /// Factory for current account status.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if name or e-mail is null.
        /// </exception>.
        public override void NewAccount(string name, string email, AbstractAccountFactory accountFactory)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            AbstractAccount newAccount = accountFactory.GetNewAccount(new NumGenerator());
            newAccount.Name = name;
            newAccount.Email = email;

            repository.Save(newAccount);
        }

        /// <summary>
        /// Override method of base class.
        /// </summary>
        protected override int CalculateBonusPoints(AccStatus status, decimal amount)
        {
            return (int)status * (int)(amount / 100);
        }
    }
}
