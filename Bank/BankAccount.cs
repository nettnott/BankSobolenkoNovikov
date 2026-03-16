using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName = null!;

        private double m_balance;

        /// <summary>
        /// Сообщение об ошибке: сумма списания превышает баланс.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке: сумма списания меньше нуля.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private BankAccount() { }

        /// <summary>
        /// Инициализирует новый экземпляр банковского счёта.
        /// </summary>
        /// <param name="customerName">Имя клиента.</param>
        /// <param name="balance">Начальный баланс счёта.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Имя клиента — владельца счёта.
        /// </summary>
        /// <value>Строка с именем клиента.</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Текущий баланс счёта.
        /// </summary>
        /// <value>Числовое значение баланса.</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Списывает указанную сумму со счёта.
        /// </summary>
        /// <param name="amount">Сумма для списания.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если <paramref name="amount"/> превышает баланс
        /// или меньше нуля.
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Пополняет счёт на указанную сумму.
        /// </summary>
        /// <param name="amount">Сумма для зачисления.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если <paramref name="amount"/> меньше нуля.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        /// <summary>
        /// Точка входа программы.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}
