using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : Singleton<GameManager>
{
    public enum GameStage
    {
        Start,
        ShowStudent,
        Match,
        Bus
    }


    public List<Student> Students;
    public List<StudentMatch> Matches;
    public List<Sprite> TagSprites;



    [BoxGroup("Scenes")]
    public Transform StudentScene;
    [BoxGroup("Scenes")]
    public Transform MatchCanvas;
    [BoxGroup("Scenes")]
    public Transform BusScene;



    private GameStage curGameStage;

    private Student curStudent;
    private int curStudentIndex = 0;


    private void Start()
    {
        curGameStage = GameStage.ShowStudent;
    }



    private void Update()
    {
        // if (curGameStage == GameStage.ShowStudent && SwipeInput.Instance.swipedUp)
        // {
        //     if (curStudentIndex < Students.Length)
        //     {
        //         TransitionToNextStudent();
        //     }
        //     else
        //     {
        //         curGameStage = GameStage.End;
        //     }
        // }
    }






    private void ShowStudent(Student student)
    {
        curStudent = ScriptableObject.CreateInstance<Student>();
        curStudent.StudentGO = Instantiate(student.StudentGO);
        curStudent.Tag = student.Tag;
    }

    public void TransitionToNextStudent()
    {
        if (curGameStage != GameStage.ShowStudent)
        {
            return;
        }

        if (curStudentIndex >= Students.Count)
        {
            Destroy(curStudent.StudentGO);
            TransitionToMatchStage();
            return;
        }

        if (curStudent && curStudent.StudentGO)
        {
            Destroy(curStudent.StudentGO);
            curStudent.StudentGO = null;
        }

        ShowStudent(Students[curStudentIndex++]);
    }

    private void TransitionToMatchStage()
    {
        curGameStage = GameStage.Match;

        StudentScene.gameObject.SetActive(false);
        MatchCanvas.parent.gameObject.SetActive(true);
    }

    public void TransitionToBusStage()
    {
        bool canTransition = true;

        for (int i = 0; i < MatchCanvas.childCount; i++)
        {
            if (MatchCanvas.GetChild(i).GetComponentInChildren<StudentThumb>() == null)
            {
                canTransition = false;
                break;
            }
        }

        if (canTransition)
        {
            curGameStage = GameStage.Bus;

            GetMatchData();

            MatchCanvas.parent.gameObject.SetActive(false);
            BusScene.gameObject.SetActive(true);

            StartCoroutine(BusSceneUpdate());
        }
    }

    IEnumerator BusSceneUpdate()
    {
        BusScene.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sprite = StudentMatch.GetTagSprite(StudentTag.Pet);

        yield return null;
    }

    private void GetMatchData()
    {
        Matches = new List<StudentMatch>();

        for (int i = 0; i < MatchCanvas.childCount;)
        {
            var match = new StudentMatch();

            match.Student1 = MatchCanvas.GetChild(i).GetComponentInChildren<StudentThumb>().Student;
            i++;

            match.Student2 = MatchCanvas.GetChild(i).GetComponentInChildren<StudentThumb>().Student;
            i++;            

            Matches.Add(match);
        }
    }
}