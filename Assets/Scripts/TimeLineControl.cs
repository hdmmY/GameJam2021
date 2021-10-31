using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineControl : MonoBehaviour
{

public Image Image;
public int CurrentId = 0;
public List<GameObject> Cameras;
public List<GameObject> Timelines;
public List<GameObject> TimelinesBack;
public float GuessTime= 20f;
public float WaitTime= 3f;
public float StartTime= 3f;

public float Timer =0f;

public GameObject TimeBar;

   void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        while(CurrentId<8){

        TimelinesBack[CurrentId].SetActive(true);
        yield return new WaitForSeconds(StartTime);

        Debug.Log("Started GuessTime : " + Time.time);

Timer = GuessTime;
        yield return new WaitForSeconds(GuessTime);
        Timelines[CurrentId].SetActive(true);

        Debug.Log("Started WaitTime : " + Time.time);

        yield return new WaitForSeconds(WaitTime);

        Cameras[CurrentId].SetActive(false);
        CurrentId++;

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }
        TimelinesBack[CurrentId].SetActive(true);
        
    }

    void Update()
    {
        if(Timer>0){
            TimeBar.SetActive(true);
            Image.fillAmount = Timer / GuessTime;
            Timer-=Time.deltaTime;
        }else{
            TimeBar.SetActive(false);
        }
    }
}
