using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxOrderMission1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Order", PlayerPrefs.GetInt("Order", 1) + 1);
        if (gameObject.name.Equals("TextBoxEnd"))
        {
            PlayerPrefs.SetInt("Order", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
