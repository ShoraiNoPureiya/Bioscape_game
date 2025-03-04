using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] private string _level;
    [SerializeField] private GameObject _optionMenu;
    [SerializeField] private GameObject _soundMenu;
    [SerializeField] private GameObject _ambientSoundMenu;
    [SerializeField] private GameObject _musicSoundMenu;
    [SerializeField] private GameObject _musicMenu;

    
    public void play()
    {
        
        _level = Doors.GetLevel();
        Debug.Log("Nome da cena salva "+ _level);
        SceneManager.LoadScene(_level);
        Time.timeScale = 1;
        
        
        //ler cena
    }

    public void quitGame()
    {
        _level = Doors.GetLevel();
        Debug.Log("Nome da cena salva "+ _level);
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
        _ambientSoundMenu.SetActive(false);
        _musicMenu.SetActive(false);
    
    }

    public void openSoundMenu()
    {
        _soundMenu.SetActive(true);

        Debug.Log("a");
    }
    public void openMusicMenu()
    {
        _musicMenu.SetActive(true);
        _musicSoundMenu.SetActive(true);


    }
    public void openAmbientSoundMenu()
    {
        _musicMenu.SetActive(true);
        _ambientSoundMenu.SetActive(true);


    }

    public void backToSoundMenu()
    {
        _musicMenu.SetActive(false);
        _ambientSoundMenu.SetActive(false);

    }
    public void backToMenu()
    {
        _musicMenu.SetActive(false);
        _ambientSoundMenu.SetActive(false);
        _soundMenu.SetActive(false);

    }
    




}
