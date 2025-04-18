using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class Cellphone_NotesApp : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController _Player; //This object will serve to stop player movement when writing in the notes
    
    public TMP_InputField _NotesTMPro; //Text field where the player types the notes

    public TMP_Text _PageIndicatorTMPro; //Simple text that shows what page the player is currently at

    public  LocalizedString localizedString; //String to display sample text in different languages

    private string[] notes = new string [10]; //array of strings where each element of the array is a page of the notes
    
    private string _currentPlaceholder = ""; //string that stores the old placeholder for when the laguage is changed

    private int currentPage = 0; //keeps track of which page the player is at the moment. It always starts at the first page
    void Start()
    {
        for(int i=0; i<10; i++){
            
            notes[i] = PlayerPrefs.GetString("_NotesAppPage" + i.ToString()); //Initializes the vector with the saved notes.
            // if(notes[i].Equals("")){ //If it's blank, it was never initialized or was erased, so a sample text is shown instead of nothing.
            //     notes[i] = "";
                
            // }
            Debug.Log(notes[i]);
        }
        _NotesTMPro.text = notes[0]; //Sets the text to the first page
        
    }

     private void OnEnable()
    {
        localizedString.StringChanged += UpdateMessage;
    }

    private void OnDisable()
    {
        localizedString.StringChanged -= UpdateMessage;
    }

    private void UpdateMessage(string value)
    {
        if(string.IsNullOrEmpty(_NotesTMPro.text) || _NotesTMPro.text == _currentPlaceholder){ //if the displayed text is "" or a placeholder for a different language, it sets the text as the placeholder for the newly selected language
            _NotesTMPro.text = value;
            _currentPlaceholder = value;
            notes[currentPage] = "";
        }

    }

    public void SaveNotes()
    {
        StorePageInArray();
        for(int i=0; i<10; i++){
            PlayerPrefs.SetString("_NotesAppPage" + i.ToString(), notes[i]); //Stores all the notes. The PlayerPref name is "_NotesAppPageXX", where the XX is the number of the page.
            
        }
        
        PlayerPrefs.Save();
    }

    public void NextPage()
    {
        _NotesTMPro.DeactivateInputField(true); //Deactivates text field so it deselects the text automatically for the player
        _NotesTMPro.ActivateInputField();
        if(currentPage == 9){ //Can't go past the tenth page
            Debug.Log("Already at the end.");
            return;
        }
        StorePageInArray(); //stores the current page before moving to the next
        
        currentPage++; //increases current page
        _PageIndicatorTMPro.text = (currentPage+1).ToString() + "/10"; //Updates page indicator
        
        ReloadStoredPageToTextField();
    }
    public void PreviousPage()
    {
        _NotesTMPro.DeactivateInputField(true);
        _NotesTMPro.ActivateInputField();
        if(currentPage == 0){
            Debug.Log("Already at the start.");
            return;
        }
        StorePageInArray();

        currentPage--;
        _PageIndicatorTMPro.text = (currentPage+1).ToString() + "/10";
        ReloadStoredPageToTextField();
    }

    private void StorePageInArray(){
        if(!_NotesTMPro.text.Equals("") && !_NotesTMPro.text.Equals(localizedString.GetLocalizedString())){
            notes[currentPage] = _NotesTMPro.text;
        }
        else{
            notes[currentPage] = "";
        }
    }

    private void ReloadStoredPageToTextField(){
        if(notes[currentPage].Equals("")){
            _NotesTMPro.text = localizedString.GetLocalizedString();   
        }
        else{
            _NotesTMPro.text = notes[currentPage]; //Updates content for current page
        }
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
