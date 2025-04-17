using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cellphone_NotesApp : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController _Player; //This object will serve to stop player movement when writing in the notes
    
    public TMP_InputField _NotesTMPro; //Text field where the player types the notes

    public TMP_Text _PageIndicatorTMPro; //Simple text that shows what page the player is currently at

    private string[] notes = new string [10]; //array of strings where each element of the array is a page of the notes

    private int currentPage = 0; //keeps track of which page the player is at the moment. It always starts at the first page
    void Start()
    {
        
        for(int i=0; i<10; i++){
            
            notes[i] = PlayerPrefs.GetString("_NotesAppPage" + i.ToString()); //Initializes the vector with the saved notes.
            if(notes[i].Equals("")){ //If it's blank, it was never initialized or was erased, so a sample text is shown instead of nothing.
                notes[i] = "Digite uma anotação..."; //TODO Traduzir pro ingles
            }
        }
        
        _NotesTMPro.text = notes[0]; //Sets the text to the first page
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveNotes()
    {
        notes[currentPage] = _NotesTMPro.text;
        for(int i=0; i<10; i++){
            PlayerPrefs.SetString("_NotesAppPage" + i.ToString(), notes[i]); //Stores all the notes. The PlayerPref name is "_NotesAppPageXX", where the XX is the number of the page.
        }
        //string notes = _NotesTMPro.text;
        
        PlayerPrefs.Save();
    }

    public void NextPage()
    {
        _NotesTMPro.DeactivateInputField();
        _NotesTMPro.ActivateInputField();
        if(currentPage == 9){
            Debug.Log("Already at the end.");
            return;
        }
        notes[currentPage] = _NotesTMPro.text; //stores the current page before moving to the next
        currentPage++;
        _PageIndicatorTMPro.text = (currentPage+1).ToString() + "/10";
        _NotesTMPro.SetTextWithoutNotify(notes[currentPage]);
    }
    public void PreviousPage()
    {
        _NotesTMPro.DeactivateInputField();
        _NotesTMPro.ActivateInputField();
        if(currentPage == 0){
            Debug.Log("Already at the start.");
            return;
        }
        notes[currentPage] = _NotesTMPro.text;
        currentPage--;
        _PageIndicatorTMPro.text = (currentPage+1).ToString() + "/10";
        _NotesTMPro.SetTextWithoutNotify(notes[currentPage]);
    }

    public void StopPlayerMovement()
    {
        _Player._InDialog = false;
    }

    public void FreePlayerMovement()
    {
        _Player._InDialog = true;
    }
}
