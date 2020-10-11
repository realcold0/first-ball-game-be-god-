using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockOfDeath : MonoBehaviour
{
    Score score;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            score.Endevent();
        }
    }
}
