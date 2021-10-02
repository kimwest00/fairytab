using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public int SlotNum; //�κ��丮 ĭ ��
    public List<GameObject> ItemSlots; //�����۽��� ����Ʈ
    public List<Item> Items; //������ ����Ʈ

    private int ItemAmount = 0; //���� ������ ��
    private int SelectedIndex = -1; //���õ� �������� ���� ��ȣ

    void Start()
    {
        for(int i = 0; i < SlotNum; i++) //�����۸���Ʈ �߰�
            ItemSlots.Add(GameObject.Find("ItemSlot" + i));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition); //��ũ������ ���콺 Ŭ���� ���� ��ġ�� ��ǥ�� ����
            RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero, LayerMask.NameToLayer("Item")); //Item ���̾ �ִ� ��ü�� �ν�
            //���� �������� �κ��丮�� �ְ���� �ʴٸ�(Ŭ���� �ȵǰ� �ϰ�ʹٸ�) �������� �ݶ��̴��� ��Ȱ��ȭ��Ű�� �� (ItemObject Ŭ���� ����)

            if (hit.collider != null) //���� Ŭ�� �� ���� �ִٸ�
            {
                GameObject rayObj = hit.collider.gameObject;
                if (rayObj.layer == LayerMask.NameToLayer("Item") && SelectedIndex == -1) //���� ��ġ�� �������� ���õƴٸ� + �κ��丮�� �������� ���õǾ� ���� ���� ������ ��
                {
                    Items.Add(rayObj.GetComponent<ItemObject>().GetItem());
                    ChangeSlotImage(ItemAmount++, rayObj.GetComponent<ItemObject>().GetItem().ItemImage);

                    //rayObj.SetActive(false); //Ŭ���� ��ü�� ��Ȱ��ȭ���Ѽ� ������� �����
                    Destroy(rayObj); //������ ������ ��ü�� ����
                    Debug.Log("Into the inventory");
                }
                else if (rayObj.layer == LayerMask.NameToLayer("Target") && SelectedIndex != -1) //��ǥ ��ü�� Ŭ���� ��� + �κ��丮�� �������� ���õǾ� �ִ� ������ ��
                {
                    if (rayObj.GetComponent<TargetObject>().TargetType == Items[SelectedIndex].ItemType) //���õ� �����۰� ��ǥ ��ü�� Ÿ���� ���� ���
                    {
                        ItemRemove(); //�κ��丮 ������ ����
                        rayObj.GetComponent<TargetObject>().CorrectEvent(); //Ÿ�ٿ��� �̺�Ʈ�� �Ͼ���� �ñ׳� ����
                    }
                }
            }
        }
    }

    private void ItemRemove()
    {
        Items.RemoveAt(SelectedIndex); //���õ� ������ ����Ʈ���� ����
        for (int i = SelectedIndex; i < ItemAmount; i++)
        {
            if (i + 1 == SlotNum) //�迭 ���� ���
                break;
            ChangeSlotImage(i, ItemSlots[i + 1].transform.GetChild(0).GetComponent<Image>().sprite);
        }

        ChangeSlotColor(SelectedIndex, new Color(1, 1, 1, 1));
        SelectedIndex = -1;
        ChangeSlotImage(--ItemAmount, null); //������ ������Ʈ�� �̹��� ����
        Debug.Log("Remove Success");
    }

    private void ChangeSlotImage(int slotIndex, Sprite image) //������ �̹��� ����
    {
        Image img = ItemSlots[slotIndex].transform.GetChild(0).GetComponent<Image>();
        img.sprite = image; //�κ��丮�� �̹����� �������� �̹����� ����
        if (image != null)
            img.color = new Color(1, 1, 1, 1); //���İ��� 1�� ����� ������ 100%�� ����
        else
            img.color = new Color(1, 1, 1, 0); //�����ϰ� ����
    }

    private void ChangeSlotColor(int slotIndex, Color color) //���� ���� ����
    {
        ItemSlots[slotIndex].GetComponent<Image>().color = color;
    }

    public void ItemSelect() //��ư���� ���
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        int objIndex = -1; //���Կ��� ������ ������ ��ȣ
        for (int i = 0; i < ItemSlots.Count; i++)
            if (ItemSlots[i] == obj)
            {
                objIndex = i;
                break;
            }
        if (objIndex == -1)
        {
            Debug.Log("ItemSelect Error");
            return;
        }

        if (objIndex == SelectedIndex) //���� ���õ� �����۰� ���� �������� ������ ���
        {
            ChangeSlotColor(SelectedIndex, new Color(1, 1, 1, 1));
            SelectedIndex = -1; //���� ���
            Debug.Log("Cancel selection");
        }
        else
        {
            if (SelectedIndex != -1) //�̹� ���õ� �������� �ִ� ���
                ChangeSlotColor(SelectedIndex, new Color(1, 1, 1, 1));

            if (objIndex < ItemAmount)
            //if (obj.transform.GetChild(0).GetComponent<Image>().sprite != null) //������ĭ�� �������� �ִ� ���
            {
                SelectedIndex = objIndex; //Ŭ���� �������� ������ ���������� ����
                ChangeSlotColor(SelectedIndex, new Color(1, 0, 0, 1)); //������
                Debug.Log(ItemSlots[SelectedIndex].name + " selected");
            }
            else
            {
                SelectedIndex = -1; //������ ���õ� ���� ����
                Debug.Log("None slot");
            }
        }
    }
}