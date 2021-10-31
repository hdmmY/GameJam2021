using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StampController : MonoBehaviour
{
    public GameObject Signature;

    private Camera camera;
    private Animation anim;
    private bool isMouseHover;
    private bool inTransition;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        anim = GetComponent<Animation>();
        isMouseHover = false;
    }

    private void Update()
    {
        if (inTransition) return;

        var screenPoint = Mouse.current.position.ReadValue();

        RaycastHit hit;
        var ray = camera.ScreenPointToRay(screenPoint);

        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            if (!isMouseHover)
            {
                isMouseHover = true;
                StartCoroutine(MouseHover());
            }
        }
    }

    private IEnumerator MouseHover()
    {
        anim.Play("Enter", PlayMode.StopAll);

        while (true)
        {
            RaycastHit hit;
            var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                if (Mouse.current.leftButton.wasPressedThisFrame && CanComfirm())
                {
                    anim.Play("Sign");
                    yield break;
                }

                yield return null;
            }
            else
            {
                anim.Play("Exit", PlayMode.StopAll);
                isMouseHover = false;
                yield break;
            }
        }
    }

    private bool CanComfirm()
    {
        var slots = transform.parent.GetChild(1);

        for (int i = 0; i < slots.childCount; i++)
        {
            if (slots.GetChild(i).GetComponentInChildren<StudentThumb>() == null)
            {
                return false;
            }
        }

        return true;
    }

    public void ShowSignature()
    {
        Signature.SetActive(true);
    }

    public void TransitToNextScene()
    {
        inTransition = true;

        PopulateMatches();

        SceneManager.LoadSceneAsync("BUS", LoadSceneMode.Single);
    }

    private void PopulateMatches()
    {
        var slots = transform.parent.GetChild(1);
        for (int i = 0; i < slots.childCount;)
        {
            var match = new StudentMatch();

            match.Student1 = slots.GetChild(i).GetComponentInChildren<StudentThumb>().Student;
            i++;

            match.Student2 = slots.GetChild(i).GetComponentInChildren<StudentThumb>().Student;
            i++;

            GameManager.Instance.Matches.Add(match);
        }
    }
}
