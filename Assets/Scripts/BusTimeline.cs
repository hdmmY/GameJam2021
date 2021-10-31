using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BusTimeline : MonoBehaviour
{
    public List<GameObject> Cams;
    public GameObject StartTimeline;
    public GameObject EndTimeline;
public int CurrentMatch = 0;

public GameObject NextB,EndB;

public SpriteRenderer TagPic;

public void GameEnd(){
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);
}

public void ButtonAction(){
    StartCoroutine(ExampleCoroutine());

}

    void Start()
    {
        ButtonAction();
    }

    IEnumerator ExampleCoroutine()
    {
        if(CurrentMatch<4){


              //endSelf
    if(CurrentMatch!=0){
    StartTimeline.SetActive(false);
    EndTimeline.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    EndTimeline.SetActive(false);

    }

    //freshContent
    TagPic.sprite = GameManager.Instance.Matches[CurrentMatch].GetTag();
    GameManager.Instance.ShowMatch(CurrentMatch);
    //start
    Cams[CurrentMatch].SetActive(false);
    StartTimeline.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    //StartTimeline.SetActive(false);


      CurrentMatch++;
      if(CurrentMatch==4){
        NextB.SetActive(false);
        EndB.SetActive(true);
      }
        }
       
  
        
    }
}
