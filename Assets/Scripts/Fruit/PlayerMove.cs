using System;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    SwipeControl swp;
    int Currentpos = 0;
    GameObject temp;

    bool canMove=true;
    bool Moving = false;

    float MovingSpeed=.3f;


    void Start()
    {
        //Done Event
        GameObject.Find("ScoreController").GetComponent<ScoreControl>().Done += GetOut;
        //SwipeController
        swp = GetComponent<SwipeControl>();
     
      
    }

   
    void Update()
    {
        if (!Moving)
        {
            if (swp.SwipeUp)
            {
                temp = GameObject.Find((Currentpos + 10).ToString());
                //Passed
                //Checking Grid Elements
                if (temp != null && temp.tag != "Blocked")
                {
              
                    UpDownAnim(transform);
                    Moving = true;

                    transform.DOMoveZ(temp.transform.position.z, MovingSpeed).SetEase(Ease.Linear).OnComplete(() => {

                        Currentpos += 10;
                        Moving = false;
                    });

                }
            }
            else if (swp.SwipeDown)
            {
            
                temp = GameObject.Find((Currentpos - 10).ToString());
                //Passed
                //Checking Grid Elements
                if (temp != null && temp.tag != "Blocked")
                {
                    UpDownAnim(transform);
                    Moving = true;
                    transform.DOMoveZ(temp.transform.position.z, MovingSpeed).SetEase(Ease.Linear).OnComplete(() => {

                        Currentpos -= 10;
                        Moving = false;
                    }); ;

                }
            }
            else if (swp.SwipeRight)
            {
             
                temp = GameObject.Find((Currentpos - 1).ToString());
                if (temp!= null && temp.tag != "Blocked")
                {
                   
            
                    canMove = true;

                    for (int i = Currentpos / 10; i >= 0; i--)
                    {   //BlockedArea
                        //Checking Grid Elements
                        if (GameObject.Find((Currentpos - (i * 10)-1).ToString()) != null && GameObject.Find((Currentpos - (i * 10)-1).ToString()).tag == "Blocked" )
                        {   //Blocked Anim
                            Moving = true;
                            UpDownAnim(transform);
                            transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z - 45f), MovingSpeed/2).OnComplete(()=> {
                                transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z + 45f), MovingSpeed / 2);
                            });
                            transform.DOMoveX(transform.position.x + .35f, MovingSpeed / 2).SetEase(Ease.Linear).OnComplete(() =>
                              {

                                  transform.DOMoveX(transform.position.x - .35f, MovingSpeed / 2);
                                  Moving = false;

                              });

                            canMove = false;
                            break;
                        }
                    }
                    //PassedArea
                    if (canMove)
                    {
                        Moving = true;
                        UpDownAnim(transform);
                  
                        transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z - 90f), MovingSpeed);
                        transform.DOMoveX(temp.transform.position.x, MovingSpeed).SetEase(Ease.Linear).OnComplete(() => {

                            Currentpos -= 1;
                            Moving = false;
                        }); ;
                        canMove = false;
                    }

                }

            }
            else if (swp.SwipeLeft)
            {
           
                temp = GameObject.Find((Currentpos + 1).ToString());
                if (temp != null && temp.tag != "Blocked")
                {
             
                    canMove = true;
                    for (int i = Currentpos / 10; i >= 0; i--)
                    {
                        //BlockedArea
                        //Checking Grid Elements
                        if (GameObject.Find((Currentpos - (i * 10)+1).ToString()) != null && GameObject.Find((Currentpos - (i * 10)+1).ToString()).tag == "Blocked" )
                        {
                            //BlockedAnim

                            Moving = true;
                            UpDownAnim(transform);
                            transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z + 45f), MovingSpeed / 2).OnComplete(() => {
                               transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z - 45f), MovingSpeed / 2);
                            });
                            transform.DOMoveX(transform.position.x - .35f, MovingSpeed / 2).SetEase(Ease.Linear).OnComplete(() =>
                            {

                                transform.DOMoveX(transform.position.x + .35f, MovingSpeed / 2);
                                Moving = false;

                            });
                            canMove = false;
                            break;
                        }
                    }
                     //PassedArea
                    if (canMove)
                    {
                        Moving = true;
                        UpDownAnim(transform);
                
                        transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z + 90f), MovingSpeed);
                        transform.DOMoveX(temp.transform.position.x, MovingSpeed).SetEase(Ease.Linear).SetEase(Ease.Linear).OnComplete(() => {

                            Currentpos += 1;
                            Moving = false;
                        }); ;
                        canMove = false;
                    }
                }
            }
        }
       
    }


   void UpDownAnim(Transform tr)
    {
        tr.DOMoveY(.6f, MovingSpeed / 2).SetEase(Ease.Linear).OnComplete(() =>
        {

            tr.DOMoveY(.45f, MovingSpeed / 2).SetEase(Ease.Linear);

        });
    }

    public void GetOut()
    {
        transform.DOMove(new Vector3(10, 5, -7), 2f);
   
    }
}
