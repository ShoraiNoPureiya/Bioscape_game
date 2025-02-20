using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour

{
    public static Missions missions;
    public bool _IsFinished = false; // verify if he do all tasks
    public bool _Missions = false; // ???
    public bool _Check = false; // verify if he catch the missions
    public int i; // counter. how many tasks are already done
    public Image _Corredor; 
    public Image _Quarto2;
    public Image _Kitchen;
    public Image _Banheiro;
    public int _CorredorInt;
    public int _Quarto2Int;
    public int _KitchenInt;
    public int _BanheiroInt;
    private void Update()
    {
       

        if (i >= 5 && _Check) { _IsFinished = true; }// if all tasks are already done and he catch the mission. The mission IsFinished
        else { _IsFinished = false; }


        if (_IsFinished) // if is finished
        {
            Hud.hud.IncreaseXP(50); // increase 50xp
            i = 0; // reset the counter
            CatchMissions.catchmissions.MissionComplete(); // need to catch the mission again
        }
    }

    private void Start()
    {
        missions = this;
        TurnOnGreen();
    }

    public void MissionsTask() // helps count missions completed
    {
        i++;
    }
    public void IsMissionCatch() //  verify if the mission is catch
    {
        _Check = true;
    }
    public void IsMissionNotCatch() // verify if the mission is catch
    {
        _Check = false;
    }
    public void Tutorial1(string Local, int i)
    {       
        PlayerPrefs.SetInt(Local,i); 
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("kitchen", 0);
        PlayerPrefs.SetInt("corredor",0);
        PlayerPrefs.SetInt("quarto2", 0);
        PlayerPrefs.SetInt("banheiro", 0);
    }
    public void TurnOnGreen()
    {
        _KitchenInt = PlayerPrefs.GetInt("kitchen");
        _CorredorInt = PlayerPrefs.GetInt("corredor");
        _Quarto2Int = PlayerPrefs.GetInt("quarto2");
        _BanheiroInt = PlayerPrefs.GetInt("banheiro");
        if (_BanheiroInt == 1)
        {
            if (_Banheiro != null)
            {
                _Banheiro.color = new Color(0f, 1f, 0f);
            }
        }
        if (_Quarto2Int == 1)
        {
            if (_Quarto2 != null)
            {
                _Quarto2.color = new Color(0f, 1f, 0f);
            }
        }
        if (_CorredorInt == 1)
        {
            if (_Corredor != null)
            {
                _Corredor.color = new Color(0f, 1f, 0f);
            }
        }
        if (_KitchenInt == 1)
        {
            if (_Kitchen != null)
            {
                _Kitchen.color = new Color(0f, 1f, 0f);
            }
        }
    }
}