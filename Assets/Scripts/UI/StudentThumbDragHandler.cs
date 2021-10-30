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



    private Transform initialParent;


    private void Start()
    {
        canvas = GetComponentInParent<Canvas>().transform;
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialParent = transform.parent;
        transform.SetParent(canvas);

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Mouse.current.position.ReadValue();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        var go = eventData.pointerCurrentRaycast.gameObject;

        if(go.GetComponent<UIHolder>())
        {
            transform.SetParent(go.transform.parent);
        }
        else if(go.GetComponent<StudentThumb>())
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
        trans.anchorMax = new Vector2(1, 1);
        trans.anchorMin = new Vector2(0, 0);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1, 1, 1);
        trans.sizeDelta = Vector2.zero;
    }
}
