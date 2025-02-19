using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Booleans : MonoBehaviour
{
    [Header("Preferences")]
    public int _iterations;
    [SerializeField] private bool[] _booleans;
    private int index;
    [SerializeField] private GameObject _uiManager;


    [Header("Timers")]
    Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "Bool For: ";
    private string _nameB = "Bool While: ";
    private string _nameC = null;
    private string _nameD = null;

    public void Test()
    {
        Clear();
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            BoolFor();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            BoolWhile();
        }
        _stopwatch.Stop();
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");

        Results();
    }

    private void BoolFor()
    {
        var index = 0;

        for ( index = 0; index < _booleans.Length ; index++) 
        {
            _booleans[index] = !_booleans[index];
        }
    }

    private void BoolWhile()
    {
        var index = 0;

        while (index < _booleans.Length-1)
        {
            _booleans[index] = !_booleans[index];
            index++;
        }
    }

    public void Results()
    {
        _uiManager.GetComponent<SistemManager>().Results(_nameA, _timeA, _nameB, _timeB, _nameC, _timeC, _nameD, _timeD);
    }
    public void Clear()
    {
        _uiManager.GetComponent<SistemManager>().Clear();
    }
}
