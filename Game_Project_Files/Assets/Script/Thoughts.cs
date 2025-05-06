using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thoughts : MonoBehaviour
{
    public static Thoughts thoughts;
    public GameObject TextBoxA; // Primeiro TextBox
    public GameObject TextBoxB; // Segundo TextBox
    public bool _HasRunned = false;
    Transform _Child;
    public int _Order;
    private void Start()
    {

    }
    void Update()
    {
        PlayerPrefs.SetInt("_CanRun", 1);
        Debug.Log(PlayerPrefs.GetInt("Order"));

        thoughts = this;
        // Se o TextBoxA estiver desativado, liga o TextBoxB
        if (PlayerPrefs.GetInt("_CanRun") == 1 && PlayerPrefs.GetInt("Order") == _Order)
        {
            if (TextBoxA != null && TextBoxB != null)
            {
                if (!TextBoxA.activeSelf && !_HasRunned)
                {
                    TextBoxB.SetActive(true);
                    _Child = transform.GetChild(0);
                    _Child.gameObject.SetActive(true);
                    _HasRunned = true;
                }
            }
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("_CanRun", 0);
    }

}

