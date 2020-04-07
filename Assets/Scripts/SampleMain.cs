using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMain : MonoBehaviour
{
    public ulong a = 5;
    public ulong b = 6;
    private Abc _abc;
    public void Start()
    {
        var primeList = new PrimeList();
        var primeDecomposition = new PrimeDecomposition(primeList);
        var radical = new Radical(primeDecomposition);
        _abc = new Abc(radical);
        Calc();
    }

    public void Calc()
    {
        Debug.Log(a + "+" + b + "=" + (a + b) + "がABC予想に当てはまるか計算します");
        var result = _abc.IsAbc(a, b);
        switch (result.Status)
        {
            case Abc.AbcResult.AbcResultStatus.IsNotRelativelyPrime:
                Debug.Log("互いに素ではないのでABC予想の範囲に含まれていません");
                break;
            case Abc.AbcResult.AbcResultStatus.IsNotAbc:
                Debug.Log("ABC予想の例外です");
                break;
            case Abc.AbcResult.AbcResultStatus.IsAbc:
                Debug.Log("ABC予想に当てはまります");
                break;
            default:
                Debug.Log("なぜここに...!?");
                break;
        }
        Debug.Log("計算終わり");
    }
}
