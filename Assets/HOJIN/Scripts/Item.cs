using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemTypeList //아이템 종류 리스트
{
    None,
    Circle,
    Heart,
    Note,
    Key_1,
    Pencil
}

[System.Serializable]
public class Item
{
    public ItemTypeList ItemType;
    public Sprite ItemImage;
}
