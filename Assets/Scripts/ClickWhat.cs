using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        Debug.Log("버튼클릭");
        print("d");
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        print(clickObject.name);
    }

    
}
