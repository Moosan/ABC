using System;
using System.Collections;
using System.Collections.Generic;

public class PrimeDecomposition
{
    private readonly PrimeList _primeList;

    public PrimeDecomposition(PrimeList primeList)
    {
        _primeList = primeList;
    }
    public List<ulong> DoPrimeDecomposition(ulong num)
    {
        var primaryFactors = new List<ulong>();
        for (var i = 0; _primeList.Get(i) <= Math.Sqrt(num); i++)
        {
            var prime = _primeList.Get(i);
            while (num % prime == 0)
            {
                primaryFactors.Add(prime);
                num /= prime;
            }
        }
        primaryFactors.Add(num);
        return primaryFactors;
    }
}
