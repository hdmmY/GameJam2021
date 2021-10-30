using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStage
    {
        Start,
        ShowStudent,
        End
    }

    public Student[] Students;


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

        if (curStudentIndex >= Students.Length)
        {
            curGameStage = GameStage.End;
            return;
        }

        if (curStudent && curStudent.StudentGO)
        {
            Destroy(curStudent.StudentGO);
            curStudent.StudentGO = null;
        }

        ShowStudent(Students[curStudentIndex++]);
    }




}