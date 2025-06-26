using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxOrderMission1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DataPersistenceManager.instance.CurrentOrder);
        DataPersistenceManager.instance.CurrentOrder += 1;

        if (gameObject.name.Equals("TextBoxEnd"))
        {
            DataPersistenceManager.instance.CurrentOrder = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
