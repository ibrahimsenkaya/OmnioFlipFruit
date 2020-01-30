using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ScoreControl : MonoBehaviour
{
    public event Action Done;
    GameObject Fruit;
    [SerializeField] GameObject WinPanel;
    private void Start()
    {
        Fruit = GameObject.Find("MainFruit");
    }
    void Update()
    {
       
        if (PlayerPrefs.GetInt("ChocoCount")==4)
        {
            //All Finish Anims
            Fruit.transform.DOMoveY(1.5f, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                //particle here
                Fruit.GetComponent<ParticleSystem>().Play();
                //anim here
                Fruit.GetComponent<Animator>().enabled = true;
                Fruit.GetComponent<Animator>().SetTrigger("Turn");
                //Setting Active Winpanel
                WinPanel.SetActive(true);
                //Waiting For finish the turn anim
                StartCoroutine(WaitForDone());
             
            });
            PlayerPrefs.SetInt("ChocoCount", 0);


        }
    }
   IEnumerator WaitForDone()
    {
        yield return new WaitForSeconds(2);

        WinPanel.SetActive(false);
        //Throw action to Player Move and Camera Controller
        Done();
    }

    
}
