using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMissions : MonoBehaviour
{
    public static CatchMissions catchmissions;
    public GameObject _TextCatchMission; // quest text
    public GameObject _TextAlertMission; // quest alert
    public bool _Catch = false; // checks if the mission was picked up or not
    public bool _CanCatch = false; // helps not to bug the code
    public bool _IsHeInDialog = false; // verify if he started the dialog

    // Start is called before the first frame update
    void Start()
    {
        catchmissions = this;
        _TextCatchMission.SetActive(false);
    }
    void Update()
    {

        if (_IsHeInDialog)// verify if he started the dialog
        {  
            _TextCatchMission.SetActive(true); // shows the quest text
        } 


      
        Check(); // in another code , helps verify if the mission was picked up or not
        if (_CanCatch) { // verify if he is close
            if (Input.GetKey(KeyCode.E)) // Press E to catch the mission
            {
                if (_IsHeInDialog)
                {
                    _Catch = true; 
                }
                                            
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) // verify if he started the dialog
        {
            _IsHeInDialog = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision) // when the player is closer
    {
        _TextAlertMission.SetActive(true);// shows the quest alert
    
        _CanCatch = true; // helps not to bug the code
    }
    private void OnTriggerExit2D(Collider2D collision) // when the player go away
    {
        if (_IsHeInDialog)
        {
            PlayerPrefs.SetInt("_CanPlay", 1); // CanPlay comes true for when the player come back nearly play again the dialog
        }
        _TextAlertMission.SetActive(false);// disappear the quest alert
        _TextCatchMission.SetActive(false); // disappear the quest text
        _IsHeInDialog = false ; // when he leaves he can't start the dialog
        _CanCatch = false;  // helps not to bug the code
    }
    public void Check() // in another code , helps verify if the mission was picked up or not
    {
        if (_Catch) { Missions.missions.IsMissionCatch(); Hud.hud.IsMissionCatch(); } //  was picked up 
        else { Missions.missions.IsMissionNotCatch(); Hud.hud.IsMissionNotCatch(); } // wasn't picked up 
    }
    public void MissionComplete() // when the mission is complete , he needs to Catch again
    {
        _Catch = false;
    }
}
