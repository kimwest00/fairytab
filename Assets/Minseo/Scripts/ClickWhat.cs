using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    public talkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public int talkIndex;
    public bool isAction;
    // Start is called before the first frame update
    public void Click()
    {
       //아이템을 연속해서 눌러야 다음대화내용 출력가능..!
       //end_cursor를 눌렀을때 다음대화내용 출력하게 하려했으나 실패,,
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        //print(clickObject.name+", "+clickObject.GetComponentInChildren<Text>().text);
        objData objdata = clickObject.GetComponent<objData>();
        
        Talk(objdata.id);
        talkPanel.SetActive(isAction);
        //talkText.text = clickObject.GetComponentInChildren<Text>().text;
        
    }
    void Talk(int id)
    {
        
        string talkData = talkManager.GetTalk(id,talkIndex);
        
        if(talkData==null){
            isAction = false;
            talkIndex = 0;
            return;
        }
        talkText.text = talkData;
        
        isAction = true;
        talkIndex++;
    }
    public void Close()
    {
        talkIndex = 0;
        talkPanel.SetActive(false);
    }

    
}
