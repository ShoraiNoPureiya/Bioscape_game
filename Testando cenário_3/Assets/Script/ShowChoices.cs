using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChoices : MonoBehaviour
{
    public static ShowChoices showchoices;
    public GameObject Buttons;
    public GameObject Buttons2;
    public GameObject Buttons3;
    public int c = 1;
    // Start is called before the first frame update
    void Start()
    {
        showchoices = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowButton()
    {
        if (c == 1) { Buttons.SetActive(true); }
        if (c == 2) { Buttons2.SetActive(true); }
        if (c == 3) { Buttons3.SetActive(true); }
        c++; 

    }
}
