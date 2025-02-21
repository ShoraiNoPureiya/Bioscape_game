using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    public static CatchObjects catchobjects;
    public List<GameObject> _Objects = new List<GameObject>();
    public int _HeHasTheKey;
    // Start is called before the first frame update
    void Start()
    {
        catchobjects = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
           
            _Objects.Add(collision.gameObject);
            if (collision.tag == "HealItem") // if its a Heal item
            {
                Hud.hud.HealingLife(10);
            }
            if (collision.tag == "SpeedItem") // if its a Speed item
            {
                PlayerController.playercontroller.IncreaseSpeed(1.5f);
            }
            if (collision.tag == "ArmorItem") // if its a Armor item
            {
                Hud.hud.Armor();
            }
            
            if (collision.name == "Key")
            {
                PlayerPrefs.SetInt("_Key", 1);
                PlayerPrefs.SetInt("MissionCompleted", 1);
            }
            collision.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("_Key", 0);
    }
    public void GetKey()
    {
        PlayerPrefs.SetInt("_Key",1);
        PlayerPrefs.SetInt("MissionCompleted", 1);
    }
}
