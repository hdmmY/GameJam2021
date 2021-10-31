using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseOverStudent : MonoBehaviour
{
    private Camera camera;
    private bool isMouseHover;

    private Vector3 originScale;



    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        isMouseHover = false;
    
        originScale = transform.localScale;
    }


    private void Update()
    {
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
        transform.localScale = originScale * 1.2f;

        while (true)
        {
            RaycastHit hit;
            var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                

                yield return null;
            }
            else
            {
                isMouseHover = false;
                transform.localScale = originScale;
                yield break;
            }
        }
    }

}
