
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Carta : MonoBehaviour
{
    public Image CartaAberta;
    public GameObject Panel;
    public Image Papel;
    public AudioSource _openLetter;

    public static Carta letter;
    private static HashSet<string> existingLetter = new HashSet<string>();

    // Unique identifier for each object (can be the name or something customized)
    public string LetterID;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // If the player collider with the letter on the floor the coroutine starts
        {

            PlayerController player = collision.GetComponent<PlayerController>(); //Acess the player script

            if (player != null) 
            {
                
                player.StopMovement(); // Puts the player speed to 0
                StartCoroutine(AbrirCarta(player)); // Pass the player to the coroutine
                _openLetter.Play();
            }

        }
    }

    IEnumerator AbrirCarta(PlayerController player) // Coroutine that controls the letter elements
    {

        Panel.SetActive(true);
        PlayerPrefs.SetInt("DestroyLetter", 1); 
        CartaAberta.gameObject.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
            yield return new WaitForSeconds(4); // acrescenta um delay de 4 segundos
            break;
        }

        yield return new
        WaitForEndOfFrame();

        CartaAberta.gameObject.SetActive(false);
        Papel.gameObject.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
           
           
            yield return null;

        }
        Papel.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);

        player.ResumeMovement(); // Player speed goes back to 5

        gameObject.SetActive(false);





        //mission 1 starts

        PlayerPrefs.SetInt("int", 0);
        DataPersistenceManager.instance.MissionCompleted = 0;
        PlayerPrefs.SetString("text", "Verifique se a chave est� na estante do laborat�rio");
        PlayerPrefs.SetInt("_CanRun", 1);
            DataPersistenceManager.instance.CurrentOrder = 1;



    gameObject.SetActive(false);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("_CanRun", 0);
        PlayerPrefs.SetInt("DestroyLetter", 0);
    }
    private void Start()
    {
        letter = this;
        if (string.IsNullOrEmpty(LetterID))
        {
            LetterID = gameObject.name;
        }
        // Checks if the identifier is already in the list of existing objects
        if (PlayerPrefs.GetInt("DestroyLetter") == 1)
        {
            if (existingLetter.Contains(LetterID))
            {
                Destroy(gameObject); // Destroys the object if it already exists
            }
        }
        else
        {
            // Marks the object as existing and keeps it when switching scenes
            existingLetter.Add(LetterID);
        }


    }

}
