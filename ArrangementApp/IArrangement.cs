namespace ArrangementApp
{
    /// <summary>
    /// Ключова функціональність комбінаторного розміщення A(n, m).
    /// </summary>
    public interface IArrangement
    {
        /// <summary>Кількість усіх елементів n (n >= 0).</summary>
        int N { get; set; }

        /// <summary>Скільки елементів вибираємо m (0 <= m <= n).</summary>
        int M { get; set; }

        /// <summary>Кількість розміщень A(n, m) = n! / (n - m)!.</summary>
        long Count();

        /// <summary>Порівняння двох розміщень за кількістю: від'ємне число, 0 або додатне.</summary>
        int CompareTo(IArrangement other);
    }
}
