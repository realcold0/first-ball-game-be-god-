using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool cheakgage; //??
    bool cheaktouch; //터시 상태
    private float gage; //모인 게이지
    public float jumpPower; //점프 세기
    public GameObject sphere; //플레이어
    public Slider powerBar; // 파워 바
    public float maxPower = 100; // 파워 최대치
    
    


    public void OnPointerDown(PointerEventData eventData)
    {
        cheaktouch = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("aa");
        cheaktouch = false;
        sphere.GetComponent<Rigidbody>().AddForce(new Vector3(gage*jumpPower,gage*jumpPower,0));
    }

    void Start()
    {
        cheakgage = true;
        cheaktouch = false;
        gage = 0;
    }

    void Update()
    {
        powerBar.value = gage / maxPower;
        if (cheaktouch == true)
        {
            if (cheakgage == true)
            {
                gage += 1;
                if (gage >= 100) cheakgage = false;
            }
        }
        if (cheakgage == false)
        {
            gage -= 1;
            if (gage <= 0)
            {
                cheakgage = true;
            }
        }
        Debug.Log("chaek:" + cheakgage + ", gage:" + gage);
    }

    
}
