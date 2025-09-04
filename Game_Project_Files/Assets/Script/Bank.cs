using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Bank : MonoBehaviour
{
    public int _Balance;
    public Text _BalanceTxt;
    // Start is called before the first frame update
    void Start()
    {
        _BalanceTxt.text = PlayerPrefs.GetInt("_Balance").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBalance();
    }

    public void UpdateBalance()
    {
        PlayerPrefs.SetInt("_Balance", _Balance);
        _BalanceTxt.text = PlayerPrefs.GetInt("_Balance").ToString();
    }
}
