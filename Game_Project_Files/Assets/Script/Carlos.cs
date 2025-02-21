using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// asdasdad

public class Carlos : MonoBehaviour
{

    public GameObject Player;
    public Animator _CarlosAnimator;
    public float _InteractionDistance = 2f;
    bool _IsTalking;
    float _StillTimer;
    // Start is called before the first frame update
    void Start()
    {
        _CarlosAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) <= _InteractionDistance) //When the player is near and press the E button the talking animation starts
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Trigger the animation
                _IsTalking = true;
                _CarlosAnimator.SetTrigger("Talking");

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
                StartCoroutine(Joinha());
                _StillTimer = 0F;
            }
        }


    }
    IEnumerator Joinha() //controls the exact time of the still animation
    {
        _CarlosAnimator.SetBool("Joinha", true);
        yield return new WaitForSeconds(2.1f);
        _CarlosAnimator.SetBool("Joinha", false);
    }
}
