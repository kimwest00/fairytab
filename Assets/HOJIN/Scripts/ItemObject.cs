using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item myItem;

    private PolygonCollider2D coll; //�������� �ݶ��̴�

    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        //coll.enabled = false; //������ Ŭ�� ��Ȱ��ȭ
        if (myItem.ItemImage == null)
            myItem.ItemImage = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {

    }

    public Item GetItem()
    {
        return myItem;
    }
}
