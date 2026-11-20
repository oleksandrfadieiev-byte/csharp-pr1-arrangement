using System;

namespace ArrangementApp
{
    /// <summary>
    /// Комбінаторне розміщення A(n, m): скількома способами можна вибрати
    /// m елементів з n, якщо порядок вибраних елементів важливий (варіант 11).
    /// </summary>
    public class Arrangement : IArrangement
    {
        // Дані класу
        private int _n;
        private int _m;

        // Конструктори

        /// <summary>Конструктор за замовчуванням: A(0, 0).</summary>
        public Arrangement() : this(0, 0) { }

        /// <summary>Конструктор з параметрами.</summary>
        public Arrangement(int n, int m)
        {
            Check(n, m);
            _n = n;
            _m = m;
        }

        /// <summary>Конструктор копіювання.</summary>
        public Arrangement(Arrangement other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            _n = other._n;
            _m = other._m;
        }

        // Властивості замість функцій доступу

        public int N
        {
            get { return _n; }
            set { Check(value, _m); _n = value; }
        }

        public int M
        {
            get { return _m; }
            set { Check(_n, value); _m = value; }
        }

        private static void Check(int n, int m)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "n не може бути від'ємним.");
            if (m < 0 || m > n)
                throw new ArgumentOutOfRangeException(nameof(m), "m має бути в межах від 0 до n.");
        }

        // Функції з завдання

        /// <summary>Кількість розміщень: n * (n - 1) * ... * (n - m + 1).
        /// Якщо результат не вміщується в long, генерується OverflowException.</summary>
        public long Count()
        {
            long result = 1;
            for (int i = 0; i < _m; i++)
                result = checked(result * (_n - i));
            return result;
        }

        /// <summary>Порівняння двох розміщень за кількістю розміщень.</summary>
        public int CompareTo(IArrangement other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return Count().CompareTo(other.Count());
        }

        // Порівняння на рівність: розміщення рівні, якщо в них однакові n і m

        public override bool Equals(object? obj)
        {
            return obj is Arrangement a && a._n == _n && a._m == _m;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_n, _m);
        }

        public override string ToString()
        {
            return $"A({_n}, {_m})";
        }
    }
}
