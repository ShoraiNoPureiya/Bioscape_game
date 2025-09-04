using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miltinho : MonoBehaviour
{
    public GameObject Player;
    public Animator _MiltinhoAnimator;
    public float _InteractionDistance = 2f;
    bool _IsTalking;
    float _StillTimer;

    void Start()
    {
        _MiltinhoAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) <= _InteractionDistance) //When the player is near and press the E button the talking animation starts
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Trigger the animation
                _IsTalking = true;
                _MiltinhoAnimator.SetTrigger("Talking");
                
            }

            else 
            {
                _IsTalking = false;
            }

        }

        if (_IsTalking == false) // if the npc is still for more than 20 seconds a animation will play
        {
            _StillTimer += Time.deltaTime;
                            
            if (_StillTimer >= 20f)
            {
                StartCoroutine(Waving());
                _StillTimer = 0F;
            }
        }

       

    }

    IEnumerator Waving() //controls the exact time of the still animation
    {
        _MiltinhoAnimator.SetBool("Waving", true);
        yield return new WaitForSeconds(2.4f);
        _MiltinhoAnimator.SetBool("Waving", false);
    }
}
