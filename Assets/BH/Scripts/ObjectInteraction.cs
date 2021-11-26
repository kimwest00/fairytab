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
                if (rayObj.layer == LayerMask.NameToLayer("Object")) //���� ��ġ�� �������� ���õƴٸ� + �κ��丮�� �������� ���õǾ� ���� ���� ������ ��
                {
                    if (rayObj == "Carpet")
                    rayObj.SetActive(false); //Ŭ���� ��ü�� ��Ȱ��ȭ���Ѽ� ������� �����
                    Debug.Log(rayObj);
                }
            }
        }
    }
}
