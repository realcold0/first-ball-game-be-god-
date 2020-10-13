using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int cheakclear;
    int scoresum;
    int calculation;
    int stagescore = 100;
    public Transform Player;
    public Text score;
    public Text scoreend;
    public Text highscore;
    public GameObject end;
    private int highScoreSave;
    private string keystring = "high score";
    map map;

    public GameObject good;
    public GameObject notbad;
    public GameObject excellent;


    void Start()
    {
        highScoreSave = PlayerPrefs.GetInt(keystring, 0);
        highscore.text = "최고 점수" + highScoreSave;
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
        if (scoresum > highScoreSave)
        {
            highscore.text = keystring + scoresum;
        }
        if( scoresum > highScoreSave)
        {

            PlayerPrefs.SetInt(keystring, scoresum);
        }

        if(charpositon>cheakclear)
        {
            if (stagescore > jump.count * 3)
            {
                scoresum += stagescore*charpositon - jump.count * 10* charpositon;
            }
            else if(stagescore >= jump.count * 3)
            {
                scoresum += 1;
            }
            //점수 ui
            if (jump.count >= 1 && jump.count <= 3) { excellent.SetActive(true); Invoke("scoreevente", 2); Debug.Log("ex"); }
            else if (jump.count >=4 && jump.count <=7) { good.SetActive(true); Invoke("scoreeventg", 2); }
            else if (jump.count >= 8) { notbad.SetActive(true); Invoke("scoreeventn", 2); }
            //점수 시스템
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
