using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class Instance : MonoBehaviour
{
    [Header("Preferences")]
    public int _iterations;
    [SerializeField] private GameObject _gameObjectDestroy;
    [SerializeField] private GameObject _gameObjectActive;
    [SerializeField] private GameObject newInstance = null;
    [SerializeField] private GameObject _uiManager;


    [Header("Timers")]
    [SerializeField] private Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private TimeSpan _timeA;
    [SerializeField] private TimeSpan _timeB;
    [SerializeField] private TimeSpan _timeC;
    [SerializeField] private TimeSpan _timeD;

    private string _nameA = "Instance Destoy: ";
    private string _nameB = "Instance Active: ";
    private string _nameC = null;
    private string _nameD = null;

    public void Test()
    {
        Clear();
        _stopwatch.Restart();
        _stopwatch.Start();
        for (int i = 0; i < _iterations; i++)
        {
            InstanceDestroy();
        }
        _stopwatch.Stop();
        _timeA = _stopwatch.Elapsed;
        print(_nameA + _timeA + "\n");

        _stopwatch.Restart();
        _stopwatch.Start();
        newInstance =Instantiate(_gameObjectActive, new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 0; i < _iterations; i++)
        {
            InstanceActive();
        }
        _stopwatch.Stop();
        Destroy(newInstance);
        _timeB = _stopwatch.Elapsed;
        print(_nameB + _timeB + "\n");

        Results();
    }

    private void InstanceDestroy()
    {
        newInstance= Instantiate(_gameObjectDestroy, new Vector3(0,0,0) , Quaternion.identity);
        _gameObjectDestroy.transform.position += new Vector3 (10, 0, 0);
        Destroy(newInstance);
    }

    private void InstanceActive()
    {
        newInstance.SetActive(true);
        newInstance.transform.position += new Vector3(10, 0, 0);
        newInstance.SetActive(false);
        newInstance.transform.position = new Vector3(0, 0, 0);
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
