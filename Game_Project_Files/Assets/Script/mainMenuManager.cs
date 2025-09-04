using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] private string _level;
    [SerializeField] private GameObject _optionMenu;
    [SerializeField] private GameObject _soundMenu;
    [SerializeField] private GameObject _musicMenu;

    
    public void play()
    {
         PlayerPrefs.DeleteAll();
         _level = "SampleScene";

        SceneManager.LoadScene(_level);
        DataPersistenceManager.instance.MissionCompleted = 1;
        PlayerPrefs.SetString("heisin", "SampleScene");
        

        Time.timeScale = 1;
        
        
        //ler cena
    }
    public void continueGame()
    {
        _level = Doors.GetLevel();
        if(string.IsNullOrEmpty(_level))
        {
            _level = "SampleScene";
            SceneManager.LoadScene(_level);
        }else{
            Debug.Log("Nome da cena salva "+ _level);
            SceneManager.LoadScene(_level);

        }
        DataPersistenceManager.instance.MissionCompleted = 1;
        PlayerPrefs.SetString("heisin", _level);


    }

    public void quitGame()
    {
        _level = Doors.GetLevel();
        
        Application.Quit();
    }
    
    public void openMenu()
    {
        _optionMenu.SetActive(true);
    }

    public void closeMenu() 
    {
        _optionMenu.SetActive(false); 
        _soundMenu.SetActive(false);
    
    }

    public void openSoundMenu()
    {
        _soundMenu.SetActive(true);

        Debug.Log("a");
    }
    public void openMusicMenu()
    {
        _musicMenu.SetActive(true);
    }
    public void openAmbientSoundMenu()
    {
        _musicMenu.SetActive(true);

    }

    public void backToSoundMenu()
    {
        _musicMenu.SetActive(false);
    }
    public void backToMenu()
    {
        _musicMenu.SetActive(false);
        _soundMenu.SetActive(false);

    }    

}
