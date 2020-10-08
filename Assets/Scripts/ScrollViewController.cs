using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewController : MonoBehaviour, IEndDragHandler
{
    [SerializeField]
    private ScrollRect scrollRect;
    [SerializeField]
    private RectTransform contentPanel;
    public Image imageContainer;
    [SerializeField]
    private GameObject scrollviewContent;
    
    [SerializeField]
    private Sprite[] sprites;

    private float n;
    //private float x, y, z;
    private float val1, val2, val3;
   // private RectTransform n;
    private RectTransform x, y, z;
   // private RectTransform val1, val2, val3;
   

    private void Start()
    {
        imageContainer.sprite = sprites[0];

        //x = Math.Abs(scrollviewContent.transform.GetChild(0).transform.localPosition.y);
        //y = Math.Abs(scrollviewContent.transform.GetChild(1).transform.localPosition.y);
        //z = Math.Abs(scrollviewContent.transform.GetChild(2).transform.localPosition.y);
        x = scrollviewContent.transform.GetChild(0).GetComponent<RectTransform>();
        y = scrollviewContent.transform.GetChild(1).GetComponent<RectTransform>();
        z = scrollviewContent.transform.GetChild(2).GetComponent<RectTransform>();

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"ScrollRectVerticalNormalize value {scrollviewContent.GetComponent<RectTransform>().anchoredPosition.y}");
        Debug.Log($"Child 0 RectVerticalNormalize value{x.anchoredPosition.y}");
        Debug.Log($"Child 1 RectVerticalNormalize value{y.anchoredPosition.y}");
        Debug.Log($"Child 2 RectVerticalNormalize value{z.anchoredPosition.y}");
      
        n = scrollviewContent.GetComponent<RectTransform>().anchoredPosition.y;
        Debug.Log($"content{n}");

        val1 = Math.Abs(n - Math.Abs(x.anchoredPosition.y));
        val2 = Math.Abs(n - Math.Abs(y.anchoredPosition.y));
        val3 = Math.Abs(n - Math.Abs(z.anchoredPosition.y));

        Debug.Log($"{n} = {val1},{val2}, {val3}");
      
        if (val1 <= val2 && val1 <= val3)
        {
            imageContainer.sprite = sprites[0];
            Debug.Log("child 0");
            //SnapTo(scrollviewContent.transform.GetChild(0).GetComponent<RectTransform>());
        }

        else if (val2 <= val1 && val2 <= val3)
        {
            Debug.Log("child 1");
            imageContainer.sprite = sprites[1];
            //SnapTo(scrollviewContent.transform.GetChild(1).GetComponent<RectTransform>());
        }

        else
        {
            imageContainer.sprite = sprites[2];
            Debug.Log("child 3");
            //SnapTo(scrollviewContent.transform.GetChild(2).GetComponent<RectTransform>());
        }
    }

    

    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
    }

}
