using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class StudentThumbDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private Image image;
    private Camera camera;

    private Transform initialParent;


    private void Start()
    {
        canvas = GetComponentInParent<Canvas>().transform;
        image = GetComponent<Image>();
        camera = canvas.GetComponent<Canvas>().worldCamera;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialParent = transform.parent;
        transform.SetParent(canvas);

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var screenPoint = Mouse.current.position.ReadValue();
        var localPoint = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas as RectTransform, screenPoint, camera, out localPoint);

        transform.localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        var go = eventData.pointerCurrentRaycast.gameObject;

        if (go == null)
        {
            transform.SetParent(initialParent);
        }
        else if (go.GetComponent<UIHolder>())
        {
            transform.SetParent(go.transform.parent);
        }
        else if (go.GetComponent<StudentThumb>())
        {
            transform.SetParent(go.transform.parent);

            go.transform.SetParent(initialParent);
            go.GetComponent<StudentThumbDragHandler>().FitToParent();
        }
        else
        {
            transform.SetParent(initialParent);
        }

        FitToParent();
    }

    public void FitToParent()
    {
        var trans = transform as RectTransform;

        trans.localPosition = Vector3.zero;
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.sizeDelta = Vector2.zero;
        trans.offsetMax = new Vector2(0f, 0f);
        trans.offsetMin = new Vector2(0f, 0f);
    }
}
