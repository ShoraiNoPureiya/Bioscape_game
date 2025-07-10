using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starttextbox : MonoBehaviour
{
    public GameObject _TextBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(starttextbox());
    }

    public IEnumerator starttextbox()
    {
        yield return new WaitForSeconds(5);
        _TextBox.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
