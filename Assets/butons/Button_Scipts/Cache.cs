using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System;

public class Cache : MonoBehaviour
{
    [Header ("Preferences")]
    [SerializeField] private Transform _transform;
    public int _iterations;
    [SerializeField] private GameObject _uiManager;


    [Header ("Timers")]
    Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "Game Object Transform: ";
    private string _nameB = "Game Object Temporal: ";
    private string _nameC = "Game Object Global: ";
    private string _nameD = null;
    public void Test()
    {
        _transform = transform;
        Clear();

        _stopwatch.Restart();
        _stopwatch.Start();        
        for (int i = 0; i < _iterations; i++) 
        {
            CallC();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            TemporalVar();
        }
        _stopwatch.Stop();
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            GlobalVar();
        }
        _stopwatch.Stop();
        _timeC = _stopwatch.Elapsed;
        print(_nameC + _timeC + "\n");

        Results();
    }

    private void CallC()
    {
        var pos = transform.position;
        var rot = transform.rotation;
        var scale = transform.localScale;
    }

    private void TemporalVar()
    {
        var _object = transform;
        var pos = _object.position;
        var rot = _object.rotation;
        var scale = _object.localScale;
    }

    private void GlobalVar()
    {
        var pos = _transform.position;
        var rot = _transform.rotation;
        var scale = _transform.localScale;
    }

    public void Results()
    {
        _uiManager.GetComponent<SistemManager>().Results(_nameA, _timeA, _nameB, _timeB, _nameC, _timeC, _nameD, _timeD);
    }

    public void Clear()
    {
        _uiManager.GetComponent <SistemManager>().Clear();
    }
}
