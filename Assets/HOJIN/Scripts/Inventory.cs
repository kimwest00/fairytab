using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public int SlotNum; //인벤토리 칸 수
    public List<GameObject> ItemSlots; //아이템슬롯 리스트
    public List<Item> Items; //아이템 리스트

    private int ItemAmount = 0; //소지 아이템 수
    private int SelectedIndex = -1; //선택된 아이템의 슬롯 번호

    void Start()
    {
        for(int i = 0; i < SlotNum; i++) //아이템리스트 추가
            ItemSlots.Add(GameObject.Find("ItemSlot" + i));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition); //스크린에서 마우스 클릭한 곳의 위치를 좌표로 얻어옴
            RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero, LayerMask.NameToLayer("Item")); //Item 레이어에 있는 객체만 인식
            //만약 아이템을 인벤토리에 넣고싶지 않다면(클릭이 안되게 하고싶다면) 아이템의 콜라이더를 비활성화시키면 됨 (ItemObject 클래스 참조)

            if (hit.collider != null) //무언가 클릭 된 것이 있다면
            {
                GameObject rayObj = hit.collider.gameObject;
                if (rayObj.layer == LayerMask.NameToLayer("Item") && SelectedIndex == -1) //씬에 배치된 아이템이 선택됐다면 + 인벤토리의 아이템이 선택되어 있지 않은 상태일 때
                {
                    Items.Add(rayObj.GetComponent<ItemObject>().GetItem());
                    ChangeSlotImage(ItemAmount++, rayObj.GetComponent<ItemObject>().GetItem().ItemImage);

                    //rayObj.SetActive(false); //클릭된 객체는 비활성화시켜서 사라지게 만들기
                    Destroy(rayObj); //실제로 씬에서 객체를 제거
                    Debug.Log("Into the inventory");
                }
                else if (rayObj.layer == LayerMask.NameToLayer("Target") && SelectedIndex != -1) //목표 객체를 클릭한 경우 + 인벤토리의 아이템이 선택되어 있는 상태일 때
                {
                    if (rayObj.GetComponent<TargetObject>().TargetType == Items[SelectedIndex].ItemType) //선택된 아이템과 목표 객체의 타입이 같은 경우
                    {
                        ItemRemove(); //인벤토리 아이템 삭제
                        rayObj.GetComponent<TargetObject>().CorrectEvent(); //타겟에서 이벤트가 일어나도록 시그널 전송
                    }
                }
            }
        }
    }

    private void ItemRemove()
    {
        Items.RemoveAt(SelectedIndex); //선택된 아이템 리스트에서 제거
        for (int i = SelectedIndex; i < ItemAmount; i++)
        {
            if (i + 1 == SlotNum) //배열 범위 벗어남
                break;
            ChangeSlotImage(i, ItemSlots[i + 1].transform.GetChild(0).GetComponent<Image>().sprite);
        }

        ChangeSlotColor(SelectedIndex, new Color(1, 1, 1, 1));
        SelectedIndex = -1;
        ChangeSlotImage(--ItemAmount, null); //마지막 오브젝트는 이미지 없음
        Debug.Log("Remove Success");
    }

    private void ChangeSlotImage(int slotIndex, Sprite image) //아이템 이미지 변경
    {
        Image img = ItemSlots[slotIndex].transform.GetChild(0).GetComponent<Image>();
        img.sprite = image; //인벤토리의 이미지를 아이템의 이미지로 복사
        if (image != null)
            img.color = new Color(1, 1, 1, 1); //알파값을 1로 만들어 불투명도 100%로 설정
        else
            img.color = new Color(1, 1, 1, 0); //투명하게 설정
    }

    private void ChangeSlotColor(int slotIndex, Color color) //슬롯 색깔 변경
    {
        ItemSlots[slotIndex].GetComponent<Image>().color = color;
    }

    public void ItemSelect() //버튼에서 사용
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        int objIndex = -1; //슬롯에서 선택한 아이템 번호
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

        if (objIndex == SelectedIndex) //현재 선택된 아이템과 같은 아이템을 선택한 경우
        {
            ChangeSlotColor(SelectedIndex, new Color(1, 1, 1, 1));
            SelectedIndex = -1; //선택 취소
            Debug.Log("Cancel selection");
        }
        else
        {
            if (SelectedIndex != -1) //이미 선택된 아이템이 있는 경우
                ChangeSlotColor(SelectedIndex, new Color(1, 1, 1, 1));

            if (objIndex < ItemAmount)
            //if (obj.transform.GetChild(0).GetComponent<Image>().sprite != null) //아이템칸에 아이템이 있는 경우
            {
                SelectedIndex = objIndex; //클릭한 아이템을 선택한 아이템으로 변경
                ChangeSlotColor(SelectedIndex, new Color(1, 0, 0, 1)); //빨간색
                Debug.Log(ItemSlots[SelectedIndex].name + " selected");
            }
            else
            {
                SelectedIndex = -1; //아이템 선택된 것이 없음
                Debug.Log("None slot");
            }
        }
    }
}