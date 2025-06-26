using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrder : MonoBehaviour
{
    public int _Order;
    public static SetOrder setorder;
    // Start is called before the first frame update
    void Start()
    {
       
        setorder = this;
        StartCoroutine("Order");
    }
    public IEnumerator Order()
    {
        yield return new WaitForSeconds(0.2f);
        DataPersistenceManager.instance.CurrentOrder = _Order;
    }
    public void SetOrdercs(int i)
    {
        DataPersistenceManager.instance.CurrentOrder = i;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
