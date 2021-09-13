using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lock_controller : MonoBehaviour
{

    private Text Txt1; //�ڹ��� ���� �ؽ�Ʈ
    private Text Txt2;
    private Text Txt3;
    private Text Txt4;

    private int Num1 = 0; //�ڹ��� ���� ������ ����
    private int Num2 = 0;
    private int Num3 = 0;
    private int Num4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        Txt1 = GameObject.Find("Num1").GetComponent<Text>(); //�ؽ�Ʈ �̸����� ��������
        Txt2 = GameObject.Find("Num2").GetComponent<Text>();
        Txt3 = GameObject.Find("Num3").GetComponent<Text>();
        Txt4 = GameObject.Find("Num4").GetComponent<Text>();

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
            RaycastHit2D hitButton = Physics2D.Raycast(ray.origin, ray.direction, distance, 1 << LayerMask.NameToLayer("Button")); // Button ���̾ ���� 
            if (hit) { // ���� ���ȭ�� ���� ������ �� ������ �߻��ϴ� ���� �����ϱ� ���� �κ� 
                if (hitButton) { // Button ������ �� 
                    if(ray.origin.x < -3) //��ǥ�� ��ư �����ؼ� ���� ����
                    {
                        if (ray.origin.y > 0)
                        {
                            Num1 += 1;
                            if(Num1 == 10)
                            {
                                Num1 = 0;
                            }
                            Txt1.text = Num1.ToString();
                        }
                        else
                        {
                            Num1 -= 1;
                            if (Num1 == -1)
                            {
                                Num1 = 9;
                            }
                            Txt1.text = Num1.ToString();
                        }
                    }

                    if (ray.origin.x < 0 && ray.origin.x > -3)
                    {
                        if (ray.origin.y > 0)
                        {
                            Num2 += 1;
                            if (Num2 == 10)
                            {
                                Num2 = 0;
                            }
                            Txt2.text = Num2.ToString();
                        }
                        else
                        {
                            Num2 -= 1;
                            if (Num2 == -1)
                            {
                                Num2 = 9;
                            }
                            Txt2.text = Num2.ToString();
                        }
                    }

                    if (ray.origin.x > 0 && ray.origin.x < 3)
                    {
                        if (ray.origin.y > 0)
                        {
                            Num3 += 1;
                            if (Num3 == 10)
                            {
                                Num3 = 0;
                            }
                            Txt3.text = Num3.ToString();
                        }
                        else
                        {
                            Num3 -= 1;
                            if (Num3 == -1)
                            {
                                Num3 = 9;
                            }
                            Txt3.text = Num3.ToString();
                        }
                    }

                    if (ray.origin.x > 3)
                    {
                        if (ray.origin.y > 0)
                        {
                            Num4 += 1;
                            if (Num4 == 10)
                            {
                                Num4 = 0;
                            }
                            Txt4.text = Num4.ToString();
                        }
                        else
                        {
                            Num4 -= 1;
                            if (Num4 == -1)
                            {
                                Num4 = 9;
                            }
                            Txt4.text = Num4.ToString();
                        }
                    }

                } 
            } 
        } 
    }

}
