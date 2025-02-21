using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision) // When the player touches the monster calls metod HitPlayer
    {
        if (collision.tag == "Player") // verify who touched the monster, if its the player calls the metod
        {
            Hud.hud.HitPlayer();
           
        }
        
    }







}
