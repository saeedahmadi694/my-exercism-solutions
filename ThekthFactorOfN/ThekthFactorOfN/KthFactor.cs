public static class Solution
{
    public static int KthFactor(int n, int k)
    {
        if (k > n) return -1;
        List<int> list = [1];

        for (var i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                list.Add(i);
                if (list.Count() == k) break;
            }
        }

        list.Add(n);
        if (list.Count < k) return -1; ;
        return list[k - 1];
    }
}



