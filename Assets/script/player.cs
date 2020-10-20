using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    jump jumpscript;
    public GameObject JumpSound, LandingSound, GetCoin;
    
    void Awake()
    {
        jumpscript = GameObject.Find("Panel").GetComponent<jump>();  //jump 스크립트 가져오기 변수 사용위해
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Plane")
        {
            jumpscript.countJump = 0;
            Debug.Log("점프 초기화");
            LandingSound.GetComponent<AudioSource>().Play();
        }
        else if (other.transform.tag == "Coin")
        {
            Debug.Log("coin");
            Destroy(other.gameObject);
            GetCoin.GetComponent<AudioSource>().Play();
        }
        else if(other.transform.tag=="JumpPlus")
        {
            jumpscript.jumpplustchaek = true;
            jumpscript.jumpplus.SetActive(true);
            Destroy(other.gameObject);
        }
        else if(other.transform.tag == "JumpPlane")
        {
            Debug.Log("chak");
            GetComponent<Rigidbody>().AddForce(new Vector3(90, 350, 0));
            JumpSound.GetComponent<AudioSource>().Play();
        }
    }

}
