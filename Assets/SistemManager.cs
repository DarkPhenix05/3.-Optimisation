using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using TMPro;

public class SistemManager : MonoBehaviour
{
    [SerializeField] private int _multiplier;

    [SerializeField] private TMP_Text _finalResult1;
    [SerializeField] private TMP_Text _finalResult2;
    [SerializeField] private TMP_Text _finalResult3;
    [SerializeField] private TMP_Text _finalResult4;
    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Results(string _name1, TimeSpan _result1, string _name2, TimeSpan _result2 , string _name3, TimeSpan _result3, string _name4, TimeSpan _result4)
    {
        if (_name1 != "")
        {
            _finalResult1.text = "";
            _finalResult1.text = _name1 + "\n" + (_result1 * _multiplier);
        }
        if (_name1 == "" || _name1 == null)
        {
            _finalResult1.text = " ";
        }

        if (_name2 != "")
        {
            _finalResult2.text = "";
            _finalResult2.text = _name2 + "\n" + (_result2 * _multiplier);
        }
        if (_name2 == "" || _name2 == null)
        {
            _finalResult2.text = " ";
        }

        if (_name3 != "")
        {
            _finalResult3.text = "";
            _finalResult3.text = _name3 + "\n" + (_result3 * _multiplier);
        }
        if (_name3 == "" || _name3 == null)
        {
            _finalResult3.text = " ";
        }

        if (_name4 != "")
        {
            _finalResult4.text = "";
            _finalResult4.text = _name4 + "\n" + (_result4 * _multiplier);
        }
        if (_name4 == "" || _name4 == null)
        {
            _finalResult4.text = " ";
        }
    }
    public void Clear()
    {
        _finalResult1.text = null;
        _finalResult2.text = null;
        _finalResult3.text = null;
        _finalResult4.text = null;

        print("CLEAR \n");
    }
}
