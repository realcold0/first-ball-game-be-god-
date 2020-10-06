using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool cheakgage;
    bool cheaktouch;
    private double gage;

    public void OnPointerDown(PointerEventData eventData)
    {
        cheaktouch = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("aa");
        cheaktouch = false;
    }

    void Start()
    {
        cheakgage = true;
    }

    void Update()
    {
        if (cheaktouch == true)
        {
            if (cheakgage == true)
            {
                gage += 1;
                if (gage >= 100) cheakgage = false;
            }
            else if (cheakgage == false)
            {
                gage -= 1;
                if (gage <= 0)
                {
                    cheakgage = true;
                }
            }
        }
        Debug.Log("chaek:" + cheakgage + ", gage:" + gage);
    }
}
