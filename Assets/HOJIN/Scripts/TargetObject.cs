using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public ItemTypeList TargetType;
    public bool Chest_3_open = false;
    private PolygonCollider2D coll; //타겟의 콜라이더
    //private bool isComplete = false; //완료되었는지 여부

    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {

    }

    public void CorrectEvent()
    {
        if (this.gameObject.name == "Keyhole_1")
        {
            Debug.Log("Use item");
            Chest_3_open = true;
        }
    } 
}