using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentInBus : MonoBehaviour
{
    private void Start()
    {
        int childIndex = 0;

        for(int i = 0; i < GameManager.Instance.Matches.Count; i++)
        {
            var left = Instantiate(GameManager.Instance.Matches[i].Student2.StudentGO);
            left.transform.SetParent(transform.GetChild(childIndex++));
            left.transform.localPosition = Vector3.zero;

            var right = Instantiate(GameManager.Instance.Matches[i].Student1.StudentGO);
            right.transform.SetParent(transform.GetChild(childIndex++));
            right.transform.localPosition = Vector3.zero;
        }
    }
}