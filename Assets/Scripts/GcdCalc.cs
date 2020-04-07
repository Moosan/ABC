public static class GcdCalc
{
    public static ulong Gcd(ulong a, ulong b) {
        return a > b ? GcdRecursive(a, b) : GcdRecursive(b, a);
    }

    private static ulong GcdRecursive(ulong a, ulong b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }
}
