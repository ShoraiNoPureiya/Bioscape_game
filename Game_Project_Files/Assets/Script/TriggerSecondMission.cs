using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSecondMission : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Task1.Result == "Red")
        {
            _Door.SetActive(false);
        }
        else
        {
            _Door.SetActive(true);
        }
    }
}
