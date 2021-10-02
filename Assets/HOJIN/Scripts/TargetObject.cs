using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public ItemTypeList TargetType;

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
        Debug.Log("Use item");
        //isComplete = true;
        //이벤트 진행
        Destroy(this.gameObject);
    }
}
