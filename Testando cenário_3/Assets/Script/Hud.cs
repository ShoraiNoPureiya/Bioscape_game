using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hud : MonoBehaviour



{
    
    public static Hud hud;
    public Image _LifeBar; // 
    public Image _XpBar;
    public Text _Text; // shows the XP lvl
    public float _Life;// keeps the amount of life
    public float _LifeMax;// keeps the max amount of life
    public float _LifeRest;// keeps the rest amount of life
    public float _Xp; // keeps the amount of xp
    public float _XpNecessary; // keeps the amount of xp necessary to lvlup
    public int _Level; // counter of the lvl
    public float DamageArmorTaken; // damage in armor
    public float a;
    public float b;
    public float c;


    public bool _Recovery;
    public bool _Armor; // he has an armor?


    

    public bool _Check = false; // verify if he catch the missions
    //This function fills the bar according to the amount
    void FillAmounth() // fill the bar
    {
        _LifeBar.fillAmount = _Life /_LifeMax ; // fill or empty the life bar
        _XpBar.fillAmount =  _Xp/ _XpNecessary; // fill or empty the xp bar
    }

    // Start is called before the first frame update
    private void OnApplicationQuit()
    {
            PlayerPrefs.SetInt("_LevelSave", 0);
            PlayerPrefs.SetFloat("_XpSave", 100); PlayerPrefs.SetFloat("_LifeSave", 100);

    }
    void Start()
    {
        hud = this;
        _Level = PlayerPrefs.GetInt("_LevelSave");
        _Xp = PlayerPrefs.GetFloat("_XpSave");
        _Life = PlayerPrefs.GetFloat("_LifeSave");
     

    }
    // Update is called once per frame
    void Update()
    {
        _LifeMax = (_Level * 2 + 100);
        _XpNecessary = (_Level * 10 + 100);
        _LifeRest = _LifeMax - _Life;   
        FillAmounth(); // fill the bar
        if (_Xp >= _XpNecessary) // shows the XP lvl and upgrades the life
        { _Level++;
          _Text.text = "lvl " + _Level;
          _Xp = _XpNecessary - _Xp; 
           if (_Xp < 0) { _Xp = _Xp * -1; }       
            PlayerPrefs.SetInt("_LevelSave",_Level);
            PlayerPrefs.SetFloat("_XpSave", _Xp);
            
        } 
    }
    public void HitPlayer() // players get a hit
    {
       
        if (_Recovery == false) // checks if the player is on recovery
        {
           
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        
        SongPlayer.songplayer.playsongs(SongPlayer.songplayer._Clip); // plays the audio of "hit"
        if (_Check)
        { // verify if the task is catch
            Missions.missions.MissionsTask(); // 1 task completed
        }
        _Recovery = true;
        yield return new WaitForSeconds(1); // 1 sec cooldown
        _Recovery = false;
        if (_Armor)
        {
            DamageArmorTaken = DamageArmorTaken + Damage(10);
            if (DamageArmorTaken >= 50) { _Armor = false; }
        } else { Damage(10); }
    }

    public void IncreaseXP(float _Amounth) // this increases a value to xp
    {
        _Xp = _Xp + _Amounth;
        PlayerPrefs.SetFloat("_XpSave", _Xp);
    }
    public void IsMissionCatch() //  verify if the mission is catch
    {
        _Check = true;
    }
    public void IsMissionNotCatch() //  verify if the mission is catch
    {
        _Check = false;
    }
    public void HealingLife(float _HealingItem) // that heals the life
    {
        
        if (_LifeMax <= _Life + _LifeRest) // checks that the heal will not exceed the maximum value
        {
            if (_LifeRest < _HealingItem) // checks that the heal will not exceed the maximum value
            {
                _Life = _LifeMax;
                a = PlayerPrefs.GetFloat("_LifeSave");
            }
            else // if dont exceed , heal only the value + the value life actual
            {
                _Life = _Life + _HealingItem;
                PlayerPrefs.SetFloat("_LifeSave", _Life);
                a = PlayerPrefs.GetFloat("_LifeSave");
            }
        }
    }
    public void Armor()
    {
        _Armor = true;

        

    }
    public float Damage(float _Damage=0)
    {
      
        if (_Armor)
        {
            _Life = _Life - (_Damage * 50 / 100); // takes a life from the player
            PlayerPrefs.SetFloat("_LifeSave", _Life);
            a = PlayerPrefs.GetFloat("_LifeSave");
        }
        else {
         _Life = _Life - _Damage; // takes a life from the player
            PlayerPrefs.SetFloat("_LifeSave", _Life);
            a = PlayerPrefs.GetFloat("_LifeSave");
        }
        return _Damage * 50 / 100;
    }


}
