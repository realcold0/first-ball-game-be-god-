using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool cheakgage; //게이지 0 or 100 확인
    bool cheaktouch; //터시 상태
    private float gage; //모인 게이지
    public float jumpPower; //점프 세기
    public GameObject sphere; //플레이어
    public Slider powerBar; // 파워 바
    public float maxPower = 100; // 파워 최대치
    
    


    public void OnPointerDown(PointerEventData eventData)   //터치를 누르고 있을때 
    {
        cheaktouch = true;
    }


    public void OnPointerUp(PointerEventData eventData)     //터치를 땔때
    {
        Debug.Log("aa");
        cheaktouch = false;
        sphere.GetComponent<Rigidbody>().AddForce(new Vector3(gage*jumpPower,gage*jumpPower,0));    //점프시킴
        gage = 0;   //게이트 초기화
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
