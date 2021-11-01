using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BusTimeline : MonoBehaviour
{
    public List<GameObject> Cams;
    public GameObject StartTimeline_Success;
    public GameObject StartTimeline_Fail;
    public GameObject EndTimeline;
    public int CurrentMatch = 0;

    public GameObject NextB, EndB;

    public SpriteRenderer TagPic;

    private GameObject startTimeline;

    public void GameEnd()
    {
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);
    }

    public void ButtonAction()
    {
        StartCoroutine(ExampleCoroutine());

    }

    void Start()
    {
        ButtonAction();
    }

    IEnumerator ExampleCoroutine()
    {
        if (CurrentMatch < 4)
        {
            //endSelf
            if (CurrentMatch != 0)
            {
                startTimeline.SetActive(false);
                EndTimeline.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                EndTimeline.SetActive(false);
            }

            if(GameManager.Instance.Matches[CurrentMatch].GetScore() == 0)
            {
                startTimeline = StartTimeline_Fail;
            }
            else
            {
                startTimeline = StartTimeline_Success;
            }

            //freshContent
            TagPic.sprite = GameManager.Instance.Matches[CurrentMatch].GetTag();
            GameManager.Instance.ShowMatch(CurrentMatch);
            //start
            Cams[CurrentMatch].SetActive(false);
            startTimeline.SetActive(true);
            yield return new WaitForSeconds(0.5f);


            CurrentMatch++;
            if (CurrentMatch == 4)
            {
                NextB.SetActive(false);
                EndB.SetActive(true);
            }
        }



    }
}
