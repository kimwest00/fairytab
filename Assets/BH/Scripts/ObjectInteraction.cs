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
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition); //��ũ������ ���콺 Ŭ���� ���� ��ġ�� ��ǥ�� ����
            RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero, LayerMask.NameToLayer("Item")); //Item ���̾ �ִ� ��ü�� �ν�
            //���� �������� �κ��丮�� �ְ���� �ʴٸ�(Ŭ���� �ȵǰ� �ϰ�ʹٸ�) �������� �ݶ��̴��� ��Ȱ��ȭ��Ű�� �� (ItemObject Ŭ���� ����)

            if (hit.collider != null) //���� Ŭ�� �� ���� �ִٸ�
            {
                GameObject rayObj = hit.collider.gameObject;
                if (rayObj.layer == LayerMask.NameToLayer("Object")) //���� ��ġ�� �������� ���õƴٸ�
                {
                    if (rayObj.name == "Carpet_1")
                    {
                        rayObj.SetActive(false); //Ŭ���� ��ü�� ��Ȱ��ȭ���Ѽ� ������� �����
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
