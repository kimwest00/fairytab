using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    
    public GameObject talkPanel;
    public Text talkText;
    // Start is called before the first frame update
    public void Click()
    {
        
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        //print(clickObject.name+", "+clickObject.GetComponentInChildren<Text>().text);
        talkText.text = clickObject.GetComponentInChildren<Text>().text;
        talkPanel.SetActive(true);
    }
    public void Close()
    {
        talkPanel.SetActive(false);
    }

    
}
