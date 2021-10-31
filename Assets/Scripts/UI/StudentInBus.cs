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
            var left = Instantiate(GameManager.Instance.Matches[i].Student1.StudentGO);
            left.transform.localPosition = Vector3.zero;
            left.transform.SetParent(transform.GetChild(childIndex++));

            var right = Instantiate(GameManager.Instance.Matches[i].Student2.StudentGO);
            right.transform.localPosition = Vector3.zero;
            right.transform.SetParent(transform.GetChild(childIndex++));
        }
    }
}