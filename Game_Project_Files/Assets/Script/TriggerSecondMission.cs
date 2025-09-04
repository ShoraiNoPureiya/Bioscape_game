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
        if (Task1.Result == "Green" || Task1.Result == "Yellow" )
        {
            _Door.SetActive(true);
        }
        else
        {
            _Door.SetActive(false);
        }
    }
}
