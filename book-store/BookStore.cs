using System.Collections.Generic;
using System;
using System.Linq;

public class BookStore
{
    private static readonly Dictionary<int, double> Discounts = new Dictionary<int, double>
    {
        { 1, 0.00 },
        { 2, 0.05 },
        { 3, 0.10 },
        { 4, 0.20 },
        { 5, 0.25 }
    };

    private const double PricePerBook = 8.0;

    public static decimal Total(IEnumerable<int> books)
    {
        if (books == null || books.ToList().Count == 0)
        {
            return 0;
        }

        // Group books by their type and count how many of each type
        var bookCounts = books.GroupBy(book => book).Select(group => group.Count()).ToList();
        return (decimal)CalculateMinimumCost(bookCounts);
    }

    private static double CalculateMinimumCost(List<int> bookCounts)
    {
        // Remove all counts that are zero
        bookCounts.RemoveAll(count => count == 0);

        // If no books left, cost is zero
        if (bookCounts.Count == 0)
        {
            return 0;
        }

        double bestCost = double.MaxValue;

        // Try to form groups from 5 to 1 unique books
        for (int i = 5; i > 0; i--)
        {
            if (bookCounts.Count >= i)
            {
                // Create a new list with one less book for each unique book in the group
                var newBookCounts = bookCounts.Select(count => count - 1).Where(count => count > 0).ToList();

                // Calculate the current cost for this grouping and add the cost of the remaining books
                double currentCost = (PricePerBook * i * (1 - Discounts[i])) + CalculateMinimumCost(newBookCounts);

                // Find the minimum cost
                if (currentCost < bestCost)
                {
                    bestCost = currentCost;
                }
            }
        }

        return bestCost;
    }
}