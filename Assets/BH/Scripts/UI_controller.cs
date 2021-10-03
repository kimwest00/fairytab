using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    public int Current_screen;

    // Start is called before the first frame update
    void Start()
    {
        Current_screen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ��ġ�� ��ǥ ������
            Ray2D ray = new Ray2D(wp, Vector2.zero); // �������� ��ġ�� ��ǥ �������� Ray�� ��
            float distance = Mathf.Infinity; // Ray ������ ������ �ִ� �Ÿ� 
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance); // �� ���� 
            RaycastHit2D hitArrow = Physics2D.Raycast(ray.origin, ray.direction, distance, 1 << LayerMask.NameToLayer("Move Arrow")); // Button ���̾ ���� 
            if (hit)
            { // ���� ���ȭ�� ���� ������ �� ������ �߻��ϴ� ���� �����ϱ� ���� �κ� 
                if (hitArrow)
                { // Button ������ �� 
                    if (hitArrow.transform.gameObject == GameObject.Find("RightArrow"))
                    {
                        if (Current_screen == 2)
                        {
                            Current_screen = 0;
                        }
                        else
                        {
                            Current_screen += 1;
                        }

                        Move_Camera(Current_screen * 30, 0);
                    }
                    else
                    {
                        if (Current_screen == 0)
                        {
                            Current_screen = 2;
                        }
                        else
                        {
                            Current_screen -= 1;
                        }

                        Move_Camera(Current_screen * 30, 0);
                    }

                }
            }
        }
    }

    private void Move_Camera(int x, int y)
    {
        Vector3 pos = new Vector3(x, y, -10); // ���ϴ� ��ġ�� ī�޶��� x, y ��ǥ �̵���Ű��
        Camera.main.gameObject.transform.position = pos;
    }
}
