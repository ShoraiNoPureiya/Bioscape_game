using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour


{

    public static PlayerController playercontroller;
    private Vector2 _playerDirection; //Player direction
    public float _playerSpeed; //Player speed
    private Rigidbody2D _playerRigidBody2d; //Player Rigidbody2d
    private Animator _playerAnimator; // Player animator
    private float _Player_initial_speed; // Player initial speed
    private float _StillTimer; // Player still timer
    private bool _CanInteract = true; //Gets if the player can interact or not
    private float _InteractionCooldown = 2.0f; //Cooldown of 2 seconds to repeat the interaction
    private bool _isMoving; //Detects if the player is moving
    public bool _InDialog = true; //Detects if the player is in a dialog
    public Transform _Player;
    public int spawnID ;
    [SerializeField] private GameObject pauseMenu;
    



    void Start()
    {
        spawnar(); 
        _playerRigidBody2d = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
       

       
        playercontroller = this;
        StartCoroutine(PlayFootstepSound());
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            PlayerPrefs.SetInt("_Key", 1);
            PlayerPrefs.SetInt("MissionCompleted", 1);
            PlayerPrefs.SetInt("_DidHeGo", 1);
        }

        if (_InDialog) {
        _playerSpeed = 5;
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Gets the player vertical and horizontal components
        _playerAnimator.SetFloat("Horizontal_walk", _playerDirection.x); //If the player walks horizontally the horizontal walk animation starts playing
        _playerAnimator.SetFloat("Vertical_walk", _playerDirection.y); //If the player walks vertically the vertical walk animation starts playing
        _playerAnimator.SetFloat("Movement", _playerDirection.sqrMagnitude); //Gets the player movement
        } else { _playerSpeed = 0; }

        if (_playerDirection != Vector2.zero) //Checks if the player is still
        {
            _playerAnimator.SetFloat("Horizontal_Idle", _playerDirection.x); // If the player is still horizontally the horizontal idle animation starts playing
            _playerAnimator.SetFloat("Vertical_Idle", _playerDirection.y); // If the player is still vertically the vertical idle animation starts playing
            _playerAnimator.SetFloat("Movement", _playerDirection.sqrMagnitude);


        }


        _isMoving = _playerDirection != Vector2.zero;

        









        if (_isMoving)  //Player is moving reset the timer
        {

            _StillTimer = 0.0f; //Resets the variable still timer


        }

        else
        {
            //Player is not moving timer start to count
            _StillTimer += Time.deltaTime;

            if (_StillTimer > 20.0f)
            {
                //  Player has been still for more than 20 seconds, active the waiting animatio
                StartCoroutine(PlayWaitingAnimation());
                _StillTimer = 0.0f; //Reset the timer



            }


        }


        if (Input.GetKeyDown(KeyCode.E) && _CanInteract)// If player press E the interaction animation starts playing
        {
            _playerAnimator.SetBool("Interaction", true);
            _CanInteract = false;
            StartCoroutine(InteractionCooldown());
        }




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }





    }






    void FixedUpdate()
    {
        
        _playerDirection.Normalize();

        _playerRigidBody2d.MovePosition(_playerRigidBody2d.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
        
    }


    public void IncreaseSpeed(float Speed) // increases character speed
    {
        _playerSpeed = _playerSpeed * Speed; // increases character speed
        StartCoroutine(Sleep());


    }
    IEnumerator Sleep()
    {

        yield return new WaitForSeconds(3); // 3 sec cooldown
        _playerSpeed = 5; // speed return to normal

    }
    IEnumerator PlayFootstepSound()
    {
        while (true)
        {
            if ( _playerSpeed != 0 && _playerDirection != Vector2.zero)
            {
                SongPlayer.songplayer._AudioSource.PlayOneShot(SongPlayer.songplayer._Walk);
            }
            yield return new WaitForSeconds(0.5f); // Adjust delay between sounds
        }


    }

    IEnumerator PlayWaitingAnimation() //Coroutine that controls the player waiting animation
    {
        _playerAnimator.SetBool("Waiting", true);
        yield return new WaitForSeconds(3.4f);
        _playerAnimator.SetBool("Waiting", false);



        bool _StopAnimation = false;

        while (!_StopAnimation && Time.deltaTime > 0f) 
        {
           
            if (_playerDirection != Vector2.zero)
            {
                _StopAnimation = true;
                _playerAnimator.SetBool("Waiting", false);
            }

            yield return new WaitForEndOfFrame(); 
        }

        

       
    }

    IEnumerator InteractionCooldown() //Coroutine that controls the interaction animation
    {
        _playerAnimator.SetBool("Interaction", true);
        _CanInteract = false;
        yield return new WaitForSeconds(1.1f); //wait 1.1 seconds to the animation to play fully
        _playerAnimator.SetBool("Interaction", false);
        yield return new WaitForSeconds(_InteractionCooldown);
        _CanInteract = true;
    }
    public void GetValues(int id)
    {
        PlayerPrefs.SetInt("id", id);

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("id", 0);
        PlayerPrefs.SetInt("DestroyLetter", 0);
    }
    public void spawnar()
    {
        spawnID = PlayerPrefs.GetInt("id");
        switch (spawnID)
        {
            case 1:
                _Player.position = new Vector3(-0.14f, -4.68f, 0);
                break;
            case 2:
                _Player.position = new Vector3(8.9f, -15.85f, 0);
                break;
            case 3:
                _Player.position = new Vector3(-0.61f, -7.46f, 0);
                break;
            case 4:
                _Player.position = new Vector3(2.21f, -2.54f, 0);
                break;
            case 5:
                _Player.position = new Vector3(1f, -7.56f, 0);
                break;
            case 6:
                _Player.position = new Vector3(-4.25f, -4.78f, 0);
                break;
            case 7:
                _Player.position = new Vector3(-3.36f, -2.34f, 0);
                break;
            case 8:
               
                break;
            case 9:
                _Player.position = new Vector3(-5.51f, -7.95f, 0);
                break;
            case 10:
                _Player.position = new Vector3(10.15f, -4.79f, 0);
                break;
            case 11:
                _Player.position = new Vector3(10.56f, -3.4f, 0);
                break;
            default:
                _Player.position = new Vector3(1.996f, -1.5f, 0);
                break;
        }
    }
    
    
    public void SetCanMove(bool value)
    {
        _InDialog = value;
    }


    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);    
        Time.timeScale = 1;
    }

    public void quitToMenu() 
    {
        SceneManager.LoadScene("Menu");
    
    }
    
    public void StopMovement() //puts the player's speed to zero
    {
        _playerSpeed = 0;
        _InDialog = false;
    }

    public void ResumeMovement() //sets the playe's speed to five again
    {
        _playerSpeed = 5;
        _InDialog = true;
    }


}



