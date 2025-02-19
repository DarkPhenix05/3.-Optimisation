using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using UnityEngine;

public class Operations : MonoBehaviour
{
    [Header("Preferences")]
    public int _iterations;
    [SerializeField] private float _valFloat1;
    [SerializeField] private float _valFloat2;
    [SerializeField] private Vector3 _valVector3;
    [SerializeField] private GameObject _uiManager;


    [Header("Timers")]
    Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "F*F*V: ";
    private string _nameB = "F*V*F: ";
    private string _nameC = "V*F*F: ";
    private string _nameD = null;

    public void Test()
    {
        Clear();
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            OperationFFV();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            OperationFVF();
        }
        _stopwatch.Stop();
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");
        
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            OperationVFF();
        }
        _stopwatch.Stop();
        _timeC = _stopwatch.Elapsed;
        print(_nameC + _timeC + "\n");

        Results();
    }

    private void OperationFFV()
    {
        var operation = _valFloat1 * _valFloat2 * _valVector3;
    }

    private void OperationFVF()
    {
        var operation = _valFloat1 * _valVector3 * _valFloat2 ;
    }

    private void OperationVFF()
    {
        var operation = _valVector3 * _valFloat1 * _valFloat2;
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
