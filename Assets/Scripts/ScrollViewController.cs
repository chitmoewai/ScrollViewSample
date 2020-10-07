using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewController : MonoBehaviour, IEndDragHandler
{
    [SerializeField]
    private ScrollRect scrollRect;

    public Image imageContainer;
    [SerializeField]
    private GameObject scrollviewContent;
    [SerializeField]
    private Sprite[] sprites;

    private float n;
    private float x, y, z;
    private float val1, val2, val3;

    private void Start()
    {
        imageContainer.sprite = sprites[0];

        x = Math.Abs(scrollviewContent.transform.GetChild(0).transform.localPosition.y);
        y = Math.Abs(scrollviewContent.transform.GetChild(1).transform.localPosition.y);
        z = Math.Abs(scrollviewContent.transform.GetChild(2).transform.localPosition.y);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
           
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        n = Math.Abs(scrollviewContent.transform.localPosition.y);

        Debug.Log($"content{n}");
        val1 = Math.Abs(n - x);
        val2 = Math.Abs(n - y);
        val3 = Math.Abs(n - z);

        Debug.Log($"scrollview content  = {n},{val1}, {val2},{val3}");
        if (val1 <= val2 && val1 <= val3)
        {
            imageContainer.sprite = sprites[0];
            Debug.Log("child 0");
        }

        else if (val2 <= val1 && val2 <= val3)
        {
            Debug.Log("child 1");
            imageContainer.sprite = sprites[1];
        }

        else
        {
            imageContainer.sprite = sprites[2];
            Debug.Log("child 3");
        }
    }
}
