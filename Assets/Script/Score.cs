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
    public Text scoreend;
    public GameObject end;
    map map;

    public GameObject good;
    public GameObject notbad;
    public GameObject excellent;
    void Start()
    {
        cheakclear = 0;
        map = GameObject.Find("MapSystem").GetComponent<map>();
        end.SetActive(false);
        excellent.SetActive(false);
        good.SetActive(false);
        notbad.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        int charpositon = (int)(Player.position.x / (map.Sharemaplength));
        if(charpositon>cheakclear)
        {
            if (stagescore > jump.count * 3)
            {
                scoresum += stagescore*charpositon - jump.count * 3* charpositon;
            }
            else if(stagescore >= jump.count * 3)
            {
                scoresum += 1;
            }
            if (jump.count >= 0 && jump.count <= 2) { excellent.SetActive(true); Invoke("scoreevente", 2); }
            else if (jump.count >=3 && jump.count <=4) { good.SetActive(true); Invoke("scoreeventg", 2); }
            else if (jump.count >=5) { notbad.SetActive(true); Invoke("scoreeventn", 2); }
            scoresum += 100 * charpositon;
            score.text = "Socre: " + scoresum;
            jump.count = 0;
            cheakclear = charpositon;
        }
        
        if(Player.position.y<-10)
        {
            Endevent();
        }
    }
    public void Endevent()
    {
        excellent.SetActive(false);
        good.SetActive(false);
        notbad.SetActive(false);
        scoreend.text = scoresum + "점";
        Time.timeScale = 0;
        end.SetActive(true);
    }

    void scoreevente()
    {
        excellent.SetActive(false);
    }
    void scoreeventg()
    {
        good.SetActive(false);
    }
    void scoreeventn()
    {
        notbad.SetActive(false);
    }
}
