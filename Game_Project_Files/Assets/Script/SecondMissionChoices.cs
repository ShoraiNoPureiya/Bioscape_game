using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMissionChoices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (TalkedToMilton._I)
        {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
             }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
