using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public ItemTypeList TargetType;

    private PolygonCollider2D coll; //Ÿ���� �ݶ��̴�
    //private bool isComplete = false; //�Ϸ�Ǿ����� ����

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
        //�̺�Ʈ ����
        Destroy(this.gameObject);
    }
}
