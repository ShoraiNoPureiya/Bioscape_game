using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingDong : MonoBehaviour
{
    public GameObject _DingDong;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DingDongi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator DingDongi()
    {
        yield return new WaitForSeconds(1);
        _DingDong.SetActive(true);
    }
}
