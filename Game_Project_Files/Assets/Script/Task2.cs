using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static Contacts_DialogChoiceNode;

public class Task2 : MonoBehaviour, IDataPersistence
{
    public static int _Choice1;
    public static int _Choice2;
    public static int _Choice3;
    public static string Result;
    public static bool _I;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void LoadData(GameData data)
    {
        // Carrega os objetos existentes do save
        _I = data._Task2Result;
    }

    public void SaveData(GameData data)
    {
        // Salva todos os IDs registrados
        data._Task2Result = _I;
    }
    // Update is called once per frame
    void Update()
    {
        Choices2();
        if (Result != null)
        {
            if (Result == "Y")
            {
                DataPersistenceManager.instance.CurrentOrder = 20;
                DataPersistenceManager.instance.Task2Result = true;
                _I = true; 
            }
            else
            {
                DataPersistenceManager.instance.CurrentOrder = 30;
            }

        }
    }

    public void Choices2()
    {
        switch (_Choice1)
        {
            case 1:
                switch (_Choice2)
                {
                    case 1:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            default:
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;
                        }
                        break;
                    default:
                        break;
                    case 2:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                }

                break;
            case 2:
                switch (_Choice2)
                {
                    case 1:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;

                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;

                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;

                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch (_Choice2)
                {
                    case 1:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "Y";
                                break;
                            case 3:
                                Result = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (_Choice3)
                        {
                            case 1:
                                Result = "N";
                                break;
                            case 2:
                                Result = "N";
                                break;
                            case 3:
                                Result = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                break;










            default:
                break;
        }
    }

    public void Mchoice1(int i)
    {
        _Choice1 = i;
    }

    public void Mchoice2(int i)
    {
        _Choice2 = i;
    }

    public void Mchoice3(int i)
    {
        _Choice3 = i;
    }
}
