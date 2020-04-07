using System;
using System.Collections;
using System.Collections.Generic;

public class PrimeList
{
    private readonly List<ulong?> _ownPrimeList = new List<ulong?>();

    public PrimeList()
    {
        //ここまで入れないとバグる
        _ownPrimeList.Add(2);
        _ownPrimeList.Add(3);
    }
    public ulong Get(int i)
    {
        if (i < 0)
        {
            return 0;
        }
        if (i >= _ownPrimeList.Count || _ownPrimeList[i] == null)
        {
            Set(i);
        }

        var value = _ownPrimeList[i];
        if (value == null)
        {
            throw new Exception("Nullやで");
        }

        return value.Value;

    }

    private void Set(int i)
    {
        var prev = Get(i - 1);
        var next = prev + 2;
        while (!IsPrime(next))
        {
            next += 2;
        }
        _ownPrimeList.Add(next);
    }

    private static bool IsPrime(ulong num)
    {
        if (num < 2) return false;
        else if (num == 2) return true;
        else if (num % 2 == 0) return false; // 偶数はあらかじめ除く

        var sqrtNum = Math.Sqrt(num);
        for (ulong i = 3; i <= sqrtNum; i += 2)
        {
            if (num % i == 0)
            {
                // 素数ではない
                return false;
            }
        }

        // 素数である
        return true;
    }
}
