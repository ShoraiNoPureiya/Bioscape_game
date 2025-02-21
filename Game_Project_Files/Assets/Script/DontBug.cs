using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontBug : MonoBehaviour
{
    // Start is called before the first frame update

         private static DontBug instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persists between scenes
        }
        else
        {
            Destroy(gameObject); // Destroys duplicates
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
