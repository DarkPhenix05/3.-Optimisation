using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class Sting : MonoBehaviour
{
    [Header("Preferences")]
    public int _iterations;
    [SerializeField] private const string _phrase = "BenchMark";
    [SerializeField] StringBuilder builder = new StringBuilder();
    [SerializeField] private string _text;
    [SerializeField] private GameObject _uiManager;


    [Header("Timers")]
    Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "String Add: ";
    private string _nameB = "String Builder: ";
    private string _nameC = null;
    private string _nameD = null;

    public void Test()
    {
        _text = "";
        Clear();
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            StringAdd();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _text = "";
        
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            StringBuild();
        }
        _stopwatch.Stop();
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");

        Results();
    }

    private void StringAdd()
    {
        _text += _phrase;
    }

    private void StringBuild()
    {
        builder.Append(_phrase);
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
