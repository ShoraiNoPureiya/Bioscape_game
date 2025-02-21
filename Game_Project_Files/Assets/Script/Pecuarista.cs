using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecuarista : MonoBehaviour

{
    public GameObject Player;
    public Animator _PecuaristaAnimator;
    public float _InteractionDistance = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, Player.transform.position) <= _InteractionDistance) //When the player is near and press the E button the talking animation starts
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                
               _PecuaristaAnimator.SetTrigger("Talking");
            }
        }
    }
}
