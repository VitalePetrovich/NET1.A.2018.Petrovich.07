using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Petrovich._07
{
    /// <summary>
    /// Interface for repositories.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Return account from repository by account number. 
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <returns>
        /// Bank account.
        /// </returns>
        AbstractAccount GetAccount(string accNumber);

        /// <summary>
        /// Delete account from repository by account number.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        void DeleteAccount(string accNumber);
        
        /// <summary>
        /// Save account to repository.
        /// </summary>
        /// <param name="acc">
        /// Account number.
        /// </param>
        void Save(AbstractAccount acc);
    }

    /// <summary>
    /// Fake repository for testing.
    /// </summary>
    public sealed class FakeRepository : IRepository
    {
        private Dictionary<string, AbstractAccount> dictionaryRepository = new Dictionary<string, AbstractAccount>();

        public AbstractAccount GetAccount(string accNumber)
        {
            if (string.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException(nameof(accNumber));

            return dictionaryRepository[accNumber];
        }

        public void DeleteAccount(string accNumber)
        {
            if (string.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException(nameof(accNumber));

            dictionaryRepository.Remove(accNumber);
        }

        public void Save(AbstractAccount acc)
        {
            if (ReferenceEquals(acc, null))
                throw new ArgumentNullException(nameof(acc));

            if (dictionaryRepository.ContainsKey(acc.AccNumber))
            {
                dictionaryRepository[acc.AccNumber] = acc;
                return;
            }

            dictionaryRepository.Add(acc.AccNumber, acc);
        }
    }
}
