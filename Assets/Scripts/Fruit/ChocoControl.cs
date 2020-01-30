using System;
using UnityEngine;


public class ChocoControl : MonoBehaviour
{
  
 
    private void OnTriggerEnter(Collider col)
    {

        if (transform.tag!="ChocoSide"&&col.tag == "Chocolate")
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            col.transform.GetChild(0).transform.GetComponent<ParticleSystem>().Play();
            transform.tag = "ChocoSide";

            //col play particle


            //ScoreControl Eventi için playerprefs artır

            PlayerPrefs.SetInt("ChocoCount", PlayerPrefs.GetInt("ChocoCount") + 1);
      
           
        }
        if (transform.tag == "ChocoSide" && col.tag == "Base")
        {
            //Splash İmage
        }
    }
}
