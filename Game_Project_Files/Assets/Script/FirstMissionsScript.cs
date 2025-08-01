using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMissionsScript : MonoBehaviour
{
    public GameObject _Dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FarmMission._I == 5)
        {
            _Dialog.tag = "Untagged";
        }
    }
}
