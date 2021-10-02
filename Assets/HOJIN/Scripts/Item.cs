using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemTypeList //������ ���� ����Ʈ
{
    None,
    Circle,
    Heart,
}

[System.Serializable]
public class Item
{
    public ItemTypeList ItemType;
    public Sprite ItemImage;
}
