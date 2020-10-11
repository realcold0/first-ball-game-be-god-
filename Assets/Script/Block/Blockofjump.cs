using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockofjump : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("chak");
            player.GetComponent<Rigidbody>().AddForce(new Vector3(50,300, 0));
        }
    }
}
