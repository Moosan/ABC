using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abc
{
    private readonly Radical _radical;

    public Abc(Radical radical)
    {
        _radical = radical;
    }

    public AbcResult IsAbc(ulong a,ulong b)
    {
        if (!TagSo(a, b))
        {
            return AbcResult.ResultIsNotRelativelyPrime();
        }
        var c = a + b;
        var rad = _radical.Rad(a * b * c);
        return c < rad * rad ? AbcResult.ResultIsAbc() : AbcResult.ResultIsNotAbc();
    }
    private static bool TagSo(ulong a,ulong b)
    {
        return GcdCalc.Gcd(a, b) == 1;
    }
    public class AbcResult
    {
        public bool IsAbc { get; private set; } = false;
        public AbcResultStatus Status { get; private set; }


        public enum AbcResultStatus
        {
            IsAbc = 0,
            IsNotAbc,
            IsNotRelativelyPrime
        }

        public static AbcResult ResultIsNotRelativelyPrime()
        {
            return new AbcResult(){IsAbc = false,Status = AbcResultStatus.IsNotRelativelyPrime};
        }

        public static AbcResult ResultIsAbc()
        {
            return new AbcResult(){IsAbc = true,Status = AbcResultStatus.IsAbc};
        }

        public static AbcResult ResultIsNotAbc()
        {
            return new AbcResult(){IsAbc = false,Status = AbcResultStatus.IsNotAbc};
        }
    }
}
