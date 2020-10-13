using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    jump jumpscript;
    
    void Start()
    {
        jumpscript = GameObject.Find("Panel").GetComponent<jump>();  //jump 스크립트 가져오기 변수 사용위해서
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Plane")
        {
            jumpscript.countJump = 0;
            Debug.Log("점프 초기화");
        }
        if (other.transform.tag == "Coin")
        {
            Debug.Log("coin");
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="JumpPlus")
        {
            jumpscript.jumpplustchaek = true;
            jumpscript.jumpplus.SetActive(true);
            Destroy(other.gameObject);
        }
    }

}
