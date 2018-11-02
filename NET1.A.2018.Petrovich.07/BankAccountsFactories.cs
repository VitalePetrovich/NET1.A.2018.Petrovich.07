using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Petrovich._07
{
    /// <summary>
    /// Abstract account factory.
    /// </summary>
    public abstract class AbstractAccountFactory
    {
        /// <summary>
        /// Return new abstract account.
        /// </summary>
        /// <param name="numGenerator">
        /// Account number generator.
        /// </param>
        /// <returns>
        /// Return new abstract account.
        /// </returns>
        public abstract AbstractAccount GetNewAccount(IAccountNumberGenerator numGenerator);
    }

    /// <summary>
    /// Base account factory.
    /// </summary>
    public sealed class BaseAccountFactory : AbstractAccountFactory
    {
        /// <summary>
        /// Return new base account.
        /// </summary>
        /// <param name="numGenerator">
        /// Account number generator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number generator is null.
        /// </exception>>
        /// <returns>
        /// Return new base account.
        /// </returns>
        public override AbstractAccount GetNewAccount(IAccountNumberGenerator numGenerator)
        {
            if (ReferenceEquals(numGenerator, null))
                throw new ArgumentNullException(nameof(numGenerator));

            return new BaseAccount(numGenerator.GenerateNewNumber());
        }
    }

    /// <summary>
    /// Silver account factory.
    /// </summary>
    public sealed class SilverAccountFactory : AbstractAccountFactory
    {
        /// <summary>
        /// Return new silver account.
        /// </summary>
        /// <param name="numGenerator">
        /// Account number generator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number generator is null.
        /// </exception>>
        /// <returns>
        /// Return new silver account.
        /// </returns>
        public override AbstractAccount GetNewAccount(IAccountNumberGenerator numGenerator)
        {
            if (ReferenceEquals(numGenerator, null))
                throw new ArgumentNullException(nameof(numGenerator));

            return new SilverAccount(numGenerator.GenerateNewNumber());
        }
    }

    /// <summary>
    /// Gold account factory.
    /// </summary>
    public sealed class GoldAccountFactory : AbstractAccountFactory
    {
        /// <summary>
        /// Return new gold account.
        /// </summary>
        /// <param name="numGenerator">
        /// Account number generator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number generator is null.
        /// </exception>>
        /// <returns>
        /// Return new gold account.
        /// </returns>
        public override AbstractAccount GetNewAccount(IAccountNumberGenerator numGenerator)
        {
            if (ReferenceEquals(numGenerator, null))
                throw new ArgumentNullException(nameof(numGenerator));
            
            return new GoldAccount(numGenerator.GenerateNewNumber());
        }
    }

    /// <summary>
    /// Platinum account factory.
    /// </summary>
    public sealed class PlatinumAccountFactory : AbstractAccountFactory
    {
        /// <summary>
        /// Return new platinum account.
        /// </summary>
        /// <param name="numGenerator">
        /// Account number generator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number generator is null.
        /// </exception>>
        /// <returns>
        /// Return new platinum account.
        /// </returns>
        public override AbstractAccount GetNewAccount(IAccountNumberGenerator numGenerator)
        {
            if (ReferenceEquals(numGenerator, null))
                throw new ArgumentNullException(nameof(numGenerator));

            return new PlatinumAccount(numGenerator.GenerateNewNumber());
        }
    }
}
