using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkManager : MonoBehaviour
{
    Dictionary<int,string[]> talkData;
    
    void Awake()
    {
        talkData = new Dictionary<int,string[]>();
        GenerateData();
        
    }

    // Update is called once per frame
    void GenerateData()
    {   
        //아이템 id, 각 아이템에서 출력하고싶은 대화내용 순서대로
        talkData.Add(1000,new string[]{"비어있는 상자이다",
        "아무런 정보를 얻을 수 없을 것 같다",
        });
        talkData.Add(2000,new string[]{"창문이 깨져있다",
        "깨져있는 틈 사이에 어떠한 표식이 남겨져있다",
        });
        talkData.Add(10, new string[]{"열리지않는다"});


    }
    public string GetTalk(int id, int talkIndex)
    {
        print("dd2");
        if(!talkData.ContainsKey(id)){
            if(!talkData.ContainsKey(id-id%10))
                return GetTalk(id-id%100,talkIndex);//Get First Talk
            else
                return GetTalk(id-id%10,talkIndex);//Get First Quest Talk 
            }
    
        
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }
}
