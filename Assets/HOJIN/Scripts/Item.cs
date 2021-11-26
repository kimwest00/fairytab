using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemTypeList //������ ���� ����Ʈ
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
