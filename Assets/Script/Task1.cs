using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public int Choice1;
    public int Choice2;
    public int Choice3;
    public string Result;
    GameObject[] Yellow;
    GameObject[] Red;
    GameObject[] Green;

    // Start is called before the first frame update
    void Start()
    {
        Choices();
        if (Result.Equals("Green"))     {  }
        if (Result.Equals("Yellow"))
        {
            Red = GameObject.FindGameObjectsWithTag("Red");
            foreach (GameObject go in Red)
            {
                go.SetActive(false);
            }
       
        }
        if (Result.Equals("Red"))
        {
                Yellow = GameObject.FindGameObjectsWithTag("Yellow");
                foreach (GameObject go in Yellow) { go.SetActive(false); }

                Red = GameObject.FindGameObjectsWithTag("Red");
                foreach (GameObject go in Red) { go.SetActive(false); }
        }





    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Choices()
    {
        switch (Choice1)
        {
            case 1:
                switch (Choice2)
                {
                    case 1:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Red";
                                break;
                            case 2:
                                Result = "Red";
                                break;
                            case 3:
                                Result = "Red";
                                break;
                            case 4:
                                Result = "Red";
                                break;
                            default:
                                break;


                        }
                        break;
                    case 2:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Yellow";
                                break;
                            case 4:
                                Result = "Red";
                                break;
                            default:
                                break;


                        }
                        break;
                    case 3:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Yellow";
                                break;
                            case 4:
                                Result = "Red";
                                break;
                            default:
                                break;


                        }
                        break;
                    case 4:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Red";
                                break;
                            case 2:
                                Result = "Red";
                                break;
                            case 3:
                                Result = "Red";
                                break;
                            default:
                                break;


                        }
                        break;
                    default:
                        break;


                }
                break;
            case 2:
                switch (Choice2)
                {
                    case 1:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Yellow";
                                break;
                            case 4:
                                Result = "Red";
                                break;
                            default:
                                break;


                        }
                        break;

                    case 2:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Yellow";
                                break;
                            case 4:
                                Result = "Yellow";
                                break;
                            default:
                                break;


                        }
                        break;

                    case 3:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Yellow";
                                break;
                            case 4:
                                Result = "Yellow";
                                break;
                            default:
                                break;


                        }
                        break;

                    case 4:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Red";
                                break;
                            case 2:
                                Result = "Red";
                                break;
                            case 3:
                                Result = "Red";
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
                switch (Choice2)
                {
                    case 1:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Green";
                                break;
                            case 4:
                                Result = "Yellow";
                                break;
                            default:
                                break;


                        }
                        break;

                    case 2:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Green";
                                break;
                            case 2:
                                Result = "Green";
                                break;
                            case 3:
                                Result = "Green";
                                break;
                            case 4:
                                Result = "Green";
                                break;
                            default:
                                break;


                        }
                        break;

                    case 3:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Green";
                                break;
                            case 2:
                                Result = "Green";
                                break;
                            case 3:
                                Result = "Green";
                                break;
                            case 4:
                                Result = "Green";
                                break;
                            default:
                                break;


                        }
                        break;

                    case 4:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Yellow";
                                break;

                            default:
                                break;


                        }
                        break;

                    default:
                        break;


                }
                break;
            case 4:
                switch (Choice2)
                {
                    case 1:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Red";
                                break;
                            default:
                                break;


                        }
                        break;
                    case 2:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Yellow";
                                break;
                            case 2:
                                Result = "Yellow";
                                break;
                            case 3:
                                Result = "Red";
                                break;

                            default:
                                break;


                        }
                        break;
                    case 3:
                        switch (Choice3)
                        {
                            case 1:
                                Result = "Red";
                                break;
                            case 2:
                                Result = "Red";
                                break;
                            case 3:
                                Result = "Red";
                                break;
                            case 4:
                                Result = "Red";
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

    public void choice1(int i)
    {      
        Choice1 = i;
    }

        public void choice2(int i)
        {
        Choice2 = i;
    }

    public void choice3(int i)
    {
        Choice3 = i;    
    }
}
