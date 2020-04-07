using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Radical
{
    private readonly PrimeDecomposition _primeDecomposition;

    public Radical(PrimeDecomposition primeDecomposition)
    {
        _primeDecomposition = primeDecomposition;
    }

    public ulong Rad(ulong n)
    {
        if (n <= 1) return 0;
        return _primeDecomposition
            .DoPrimeDecomposition(n)
            .Distinct()
            .Aggregate((ulong)1, (current, val) => current * val);
    }

}
