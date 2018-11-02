using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Petrovich._07
{
    /// <summary>
    /// Enumeration of accounts status.
    /// </summary>
    public enum AccStatus
    {
        Base, Silver, Gold, Platinum
    }

    /// <summary>
    /// Abstract class for accounts.
    /// </summary>
    public abstract class AbstractAccount : IFormattable
    {
        //Properties
        internal string AccNumber { get; set; }
        internal string Name { get; set; }
        internal string Email { get; set; }
        internal decimal Balance { get; set; }
        internal int BonusPoints { get; set; }
        internal AccStatus Status { get; set; }
        internal decimal MinEdgeWithdraw { get; set; }
        
        protected AbstractAccount(string accNumber)
        {
            if (string.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException(nameof(accNumber));

            AccNumber = accNumber;
        }

        #region IFormattable implement

        /// <summary>
        /// Return string representation of bank account.
        /// </summary>
        /// <param name="format">
        /// Format name.
        /// </param>
        /// <param name="formatProvider">
        /// Format provider.
        /// </param>
        /// <exception cref="FormatException">
        /// Throws if current format doesn't exist.
        /// </exception>>
        /// <returns>
        /// String representation.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";

            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return $"#{AccNumber}| name: {Name}| email: {Email}| balance: {Balance.ToString("C", formatProvider)}| bonus: {BonusPoints}| status: {Status}";
                default:
                    throw new FormatException($"Incorrect format '{format}'");
            }
        }

        /// <summary>
        /// Overloaded version to ToString(format, formatProvider);
        /// </summary>
        /// <param name="format">
        /// Format name.
        /// </param>
        /// <exception cref="FormatException">
        /// Throws if current format doesn't exist.
        /// </exception>>
        /// <returns>
        /// Return string representation.
        /// </returns>
        public string ToString(string format)
            => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Overloaded object method ToString();
        /// </summary>
        /// <returns>
        /// Return string representation.
        /// </returns>
        public override string ToString()
            => this.ToString("G", CultureInfo.CurrentCulture);
        
        #endregion
    }

    /// <summary>
    /// Base account class.
    /// Minimal edge of withdraw is 0.
    /// </summary>
    internal sealed class BaseAccount : AbstractAccount
    {
        /// <summary>
        /// Base account ctor.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number is null or empty.
        /// </exception>
        internal BaseAccount(string accNumber) : base(accNumber)
        {
            Status = AccStatus.Base;
            MinEdgeWithdraw = 0;
        }
    }

    /// <summary>
    /// Silver account class.
    /// Minimal edge of withdraw is -200.
    /// </summary>
    internal sealed class SilverAccount : AbstractAccount
    {
        /// <summary>
        /// Silver account ctor.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number is null or empty.
        /// </exception>
        internal SilverAccount(string accNumber) : base(accNumber)
        {
            Status = AccStatus.Silver;
            MinEdgeWithdraw = -200;
        }
    }

    /// <summary>
    /// Gold account class.
    /// Minimal edge of withdraw is -500.
    /// </summary>
    internal sealed class GoldAccount : AbstractAccount
    {
        /// <summary>
        /// Gold account ctor.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number is null or empty.
        /// </exception>
        internal GoldAccount(string accNumber) : base(accNumber)
        {
            Status = AccStatus.Gold;
            MinEdgeWithdraw = -500;
        }
    }

    /// <summary>
    /// Platinum account class.
    /// Minimal edge of withdraw is -1000.
    /// </summary>
    internal sealed class PlatinumAccount : AbstractAccount
    {
        /// <summary>
        /// Platinum account ctor.
        /// </summary>
        /// <param name="accNumber">
        /// Account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if current account number is null or empty.
        /// </exception>
        internal PlatinumAccount(string accNumber) : base(accNumber)
        {
            Status = AccStatus.Platinum;
            MinEdgeWithdraw = -1000;
        }
    }
}
