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
    public Text jumpUi;
    public float maxPower = 100; // 파워 최대치
    public float countJump;
    Rigidbody rb;

    public static int count;    //해당 스테이지에서 점프횟수 카운트


    public void OnPointerDown(PointerEventData eventData)   //터치를 누르고 있을때 
    {
        cheaktouch = true;
        //if(rb.velocity == new Vector3(0,0,0))     //연속 점프 방지용 눌렀을때 속도가 0이어야 점프카운트  0
        //{
        //    countJump = 0;
        //}
    }


    public void OnPointerUp(PointerEventData eventData)     //터치를 땔때
    {
        Debug.Log("aa");
        cheaktouch = false;
        if(countJump == 0 && rb.velocity == new Vector3(0,0,0))
        {
            sphere.GetComponent<Rigidbody>().AddForce(new Vector3(gage * jumpPower, gage * jumpPower, 0));    //점프시킴
            Debug.Log("1단 점프!");
            countJump = 1;
            count++;
        }
        else if(countJump == 1 )
        {
            sphere.GetComponent<Rigidbody>().AddForce(new Vector3(0, gage * jumpPower * 2, 0));    //2단점프시킴
            Debug.Log("2단 점프!");
            countJump = 2;
            count++;
        }
        gage = 0;   //게이트 초기화
    }

    void Start()
    {
        cheakgage = true;
        cheaktouch = false;
        gage = 0;
        countJump = 0;
        rb = sphere.GetComponent<Rigidbody>();
    }

    void Update()
    {
        jumpUi.text = count + " 번";
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
                Debug.Log("gage는 0");
                cheakgage = true;
            }
        }
        //Debug.Log("chaek:" + cheakgage + ", gage:" + gage);
    }

    
}
