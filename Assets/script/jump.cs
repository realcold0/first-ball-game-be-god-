using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool cheakgage;
    bool cheaktouch;
    private float gage;
    public GameObject sphere;

    public void OnPointerDown(PointerEventData eventData)
    {
        cheaktouch = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("aa");
        cheaktouch = false;
        sphere.GetComponent<Rigidbody>().AddForce(new Vector3(gage*10,gage*10));
    }

    void Start()
    {
        cheakgage = true;
        cheaktouch = false;
        gage = 0;
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
