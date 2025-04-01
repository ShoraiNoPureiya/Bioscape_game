using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontBug : MonoBehaviour
{
    // Start is called before the first frame update

         private static DontBug instance = null;
         public string audioSourceName = "Musics";
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persists between scenes
        }
        else
        {
            // Check if the duplicate has the correct name
            if (gameObject.name == instance.gameObject.name && gameObject.GetComponent<AudioSource>() != null && gameObject.GetComponent<AudioSource>().clip != null && gameObject.name.Contains(audioSourceName))
            {
                Destroy(gameObject); // Destroys duplicates with the specified name
            }

        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
