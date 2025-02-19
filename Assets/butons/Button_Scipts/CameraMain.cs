using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System;

public class CameraMain : MonoBehaviour
{
    [Header("Preferences")]
    public int _iterations;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _uiManager;


    [Header("Timers")]
    Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "Camera Temporal: ";
    private string _nameB = "Camera Tag: ";
    private string _nameC = "Camera GameObject: ";
    private string _nameD = "Camera Global: ";

    public void Test()
    {
        _camera = Camera.main;
        Clear();

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            CamAspectRatio();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            CamTagAspectRatio();
        }
        _stopwatch.Stop();
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            CamFindObjectAspectRatio();
        }
        _stopwatch.Stop();
        _timeC = _stopwatch.Elapsed;
        print(_nameC + _timeC + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            CamGlobalAspectRatio();
        }
        _stopwatch.Stop();
        _timeD = _stopwatch.Elapsed;
        print(_nameD + _timeD + "\n");

        Results();
    }

    private void CamAspectRatio()
    {
        var camera = Camera.main;
        var aspectRatio = camera.aspect;
    }

    private void CamTagAspectRatio()
    {
        var camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        var aspectRatio = camera.aspect;
    }

    private void CamFindObjectAspectRatio()
    {
        var camera = FindObjectOfType<Camera>();
        var aspectRario = camera.aspect;
    }
    private void CamGlobalAspectRatio()
    {
        var aspectRatio = _camera.aspect;
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
