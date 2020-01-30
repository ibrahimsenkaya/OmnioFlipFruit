using DG.Tweening;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
   
    private void Start()
    {
     
        //FinishEvent
        PlayerPrefs.SetInt("ChocoCount", 0);
        GameObject.Find("ScoreController").GetComponent<ScoreControl>().Done += Finish;
       

        //Starting Events
        transform.DOMove(new Vector3(1.2f, 4.7f, -5f), 1f).OnComplete(()=> {
            GameObject.Find("MainFruit").GetComponent<SwipeControl>().enabled = true;
        });
        transform.DORotate(new Vector3(24f, -25f, 0), 1f);
    }

    public void Finish()
    {
        transform.DOMove(new Vector3(1.3f, 2.7f, -4.8f), 1f).OnComplete(() => {
            GameObject.Find("MainFruit").GetComponent<SwipeControl>().enabled = false;
        });
        transform.DORotate(new Vector3(25f, -90f, 0), 1f);
    }

}
