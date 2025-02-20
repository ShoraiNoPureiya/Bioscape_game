using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrder : MonoBehaviour
{
    public int _Order;
    public static SetOrder setorder;
    // Start is called before the first frame update
    void Start()
    {
        setorder = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Order", _Order);
    }

}
