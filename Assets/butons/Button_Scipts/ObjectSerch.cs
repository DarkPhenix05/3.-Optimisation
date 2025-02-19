using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System;

public class ObjectSerch : MonoBehaviour
{
    [Header("Preferences")]
    public int _iterations;
    [SerializeField] private GameObject _uiManager;


    [Header("Timers")]
    Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "Find Tag: ";
    private string _nameB = "Find Type: ";
    private string _nameC = null;
    private string _nameD = null;

    public void Test()
    {
        Clear();
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            CallTag();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            CallTipe();
        }
        _stopwatch.Stop();
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");

        Results();
    }

    private void CallTag()
    {
        var object1 = GameObject.FindGameObjectsWithTag("MainCamera");
        var object2 = GameObject.FindGameObjectsWithTag("Canvas");
    }

    private void CallTipe()
    {
        var object1 = GameObject.FindAnyObjectByType<FindHelper>();
        var object2 = GameObject.FindAnyObjectByType<FindHelper>();
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
