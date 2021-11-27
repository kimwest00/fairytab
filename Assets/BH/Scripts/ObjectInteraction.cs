using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                if (rayObj.layer == LayerMask.NameToLayer("Object")) //씬에 배치된 아이템이 선택됐다면
                {
                    if (rayObj.name == "Carpet_1")
                    {
                        rayObj.SetActive(false); //클릭된 객체는 비활성화시켜서 사라지게 만들기
                        Debug.Log(rayObj);
                    }
                    else if (rayObj.name == "Carpet")
                    {
                        GameObject.Find("Canvas").GetComponent<UI_controller>().Move_Camera(90, 0);
                        Debug.Log(rayObj);
                    }
                    else if (rayObj.name == "Chest_2")
                    {
                        if (rayObj.transform.GetChild(0).gameObject.activeSelf == false)
                        {
                            rayObj.transform.localPosition = new Vector2(0, -0.22f);
                            rayObj.transform.GetChild(0).gameObject.SetActive(true);
                        }
                        else
                        {
                            rayObj.transform.localPosition = new Vector2(0, 0);
                            rayObj.transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                    else if (rayObj.name == "Chest_3")
                    {
                        if (GameObject.Find("Keyhole_1").GetComponent<TargetObject>().Chest_3_open == true)
                        {

                            if (rayObj.transform.GetChild(0).gameObject.activeSelf == false)
                            {
                                rayObj.transform.localPosition = new Vector2(0, -0.52f);
                                rayObj.transform.GetChild(0).gameObject.SetActive(true);
                            }
                            else
                            {
                                rayObj.transform.localPosition = new Vector2(0, -0.3f);
                                rayObj.transform.GetChild(0).gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }
        }
    }
}
