using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item myItem;

    private PolygonCollider2D coll; //아이템의 콜라이더

    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        //coll.enabled = false; //아이템 클릭 비활성화
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
