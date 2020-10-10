using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int cheakclear;
    int scoresum;
    int calculation;
    int stagescore = 15;
    public Transform Player;
    public Text score;
    map map;

    void Start()
    {
        cheakclear = 0;
        map = GameObject.Find("MapSystem").GetComponent<map>();
    }

    // Update is called once per frame
    void Update()
    {
        int charpositon = (int)(Player.position.x / (map.Sharemaplength));
        if(charpositon>cheakclear)
        {
            if (15 > jump.count * 3)
            {
                scoresum += stagescore - jump.count * 3;
            }
            else if(15 >= jump.count * 3)
            {
                scoresum += 1;
            }
            score.text = "Socre: " + scoresum;
            jump.count = 0;
            cheakclear = charpositon;
        }
    }
}
