using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMissionChico : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Chico1")
        {
            if (StartDialog2._TurnedOn)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if (gameObject.name == "Pecuarista")
        { 
            if (!StartDialog2._TurnedOn)
            {
                gameObject.SetActive(true);
            }
                    else
            {
                gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
