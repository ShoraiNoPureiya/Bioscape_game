using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSequence : MonoBehaviour
{
    public GameObject _Object;
    public static bool _I;
    // Start is called before the first frame update
    void Start()
    {
        _I = true;
        _Object.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
