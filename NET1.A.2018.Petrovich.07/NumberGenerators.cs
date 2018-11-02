using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Petrovich._07
{
    /// <summary>
    /// Interface for account number generators.
    /// </summary>
    public interface IAccountNumberGenerator
    {
        /// <summary>
        /// Generate new account number.
        /// </summary>
        /// <returns>
        /// New account number.
        /// </returns>
        string GenerateNewNumber();
    }
    
    /// <summary>
    /// Account number generator.
    /// </summary>
    public class NumGenerator : IAccountNumberGenerator
    {
        public string GenerateNewNumber()
        {
            Random rnd = new Random();

            return rnd.Next(100000000, 999999999).ToString();
        }
    }
}
