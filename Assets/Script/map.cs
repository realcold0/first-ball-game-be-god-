using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    int mapcount;   //맵
    const int maplength = 15; //맵길이

    public Transform player; //플레이어 위치계산
    public GameObject[] stage;
    public int keepmap; //유지할 맵 수
    public List<GameObject> stagelist = new List<GameObject>();
    private int nextStageTip;

    // Start is called before the first frame update
    void Start()
    {
        mapcount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        int charpositon = (int)(player.position.x / maplength); //캐릭터 스테이지 확인
        nextStageTip = Random.Range(0, stage.Length);
        if (charpositon + keepmap > mapcount)
        {
            UpdateStage(charpositon + keepmap);
        }
    }

    GameObject CreateStage(int tipIndex)
    {
        //int nextStageTip = Random.Range(0, stage.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stage[nextStageTip],
            new Vector3(tipIndex * maplength, 0,0 ),
            Quaternion.identity
        );
        return stageObject;
    }


    void UpdateStage(int stage)
    {
        if (stage <= mapcount + 1) return;
        // 지정한 스테이지 팁까지를 작성 
        for (int i = mapcount + 1; i <= stage; i++)
        {
            GameObject stageObject = CreateStage(i);

            // 생성한 스테이지를 관리 리스트에 추가
            stagelist.Add(stageObject);
        }
        // 스테이지 보관 상한이 될 때까지 예전 스테이지를 삭제
        while (stagelist.Count > keepmap +1) Destroystage();
        mapcount = stage;

    }

    void Destroystage()
    {
        GameObject oldstage = stagelist[0];
        stagelist.RemoveAt(0);
        Destroy(oldstage);
    }
}
