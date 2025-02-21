using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public int _Load = 0;
    public GameObject _;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        _Load++;
    }
}
