using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameStage
    {
        Start,
        ShowStudent,
        Match,
        Bus
    }

    public List<StudentMatch> Matches;


    public void ShowMatch(int index)
    {
        var canvas = GameObject.Find("名字界面");

        var leftName = canvas.transform.GetChild(0);
        leftName.GetChild(0).GetComponentInChildren<Text>().text = Matches[index].Student1.Prefix;
        leftName.GetChild(1).GetComponentInChildren<Text>().text = Matches[index].Student1.Name;


        var rightName = canvas.transform.GetChild(1);
        rightName.GetChild(0).GetComponentInChildren<Text>().text = Matches[index].Student2.Prefix;
        rightName.GetChild(1).GetComponentInChildren<Text>().text = Matches[index].Student2.Name;


        var ending = canvas.transform.GetChild(2);
        ending.GetComponentInChildren<Text>().text = Matches[index].GetEnding();
    }

    public void LoadStudentScene()
    {
        SceneManager.LoadSceneAsync("Art_Mockup");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}