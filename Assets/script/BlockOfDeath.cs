using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockOfDeath : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");

        }
    }
}
