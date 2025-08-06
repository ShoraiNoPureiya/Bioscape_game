using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMissionS : MonoBehaviour
{
    public GameObject _DialogBox;
    public GameObject _DialogBox2;
    public bool _Active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_DialogBox2.activeSelf)
        {
            _Active = true;
        }
        if (_Active) { _DialogBox.SetActive(false); }
    }
}
