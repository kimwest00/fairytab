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

    public string Password;
    public int Back_x, Back_y;
    private string Txt_sum;

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
                    if(hitButton.transform.gameObject == GameObject.Find("Arrow_u1")) //��ǥ�� ��ư �����ؼ� ���� ����
                    {
                        Num1 += 1;
                        if(Num1 == 10)
                        {
                            Num1 = 0;
                        }
                        Txt1.text = Num1.ToString();
                        }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_d1"))
                    {
                        Num1 -= 1;
                        if (Num1 == -1)
                        {
                            Num1 = 9;
                        }
                        Txt1.text = Num1.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_u2"))
                    {
                        Num2 += 1;
                        if (Num2 == 10)
                        {
                            Num2 = 0;
                        }
                        Txt2.text = Num2.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_d2"))
                    {
                        Num2 -= 1;
                        if (Num2 == -1)
                        {
                            Num2 = 9;
                        }
                        Txt2.text = Num2.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_u3"))
                    {
                        Num3 += 1;
                        if (Num3 == 10)
                        {
                            Num3 = 0;
                        }
                        Txt3.text = Num3.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_d3"))
                    {
                        Num3 -= 1;
                        if (Num3 == -1)
                        {
                            Num3 = 9;
                        }
                        Txt3.text = Num3.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_u4"))
                    {
                        Num4 += 1;
                        if (Num4 == 10)
                        {
                            Num4 = 0;
                        }
                        Txt4.text = Num4.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Arrow_d4"))
                    {
                        Num4 -= 1;
                        if (Num4 == -1)
                        {
                            Num4 = 9;
                        }
                        Txt4.text = Num4.ToString();
                    }
                    else if (hitButton.transform.gameObject == GameObject.Find("Back"))
                    {
                        Move_Camera(Back_x, Back_y);
                    }

                    Txt_sum = Txt1.text + Txt2.text + Txt3.text + Txt4.text;
                    
                    Check_Password(Password, Txt_sum);

                } 
            } 
        }
    }

    private void Check_Password(string password, string answer)
    { 
        if (answer == password)
        {
            Debug.Log("Open");
        }

    }

    private void Move_Camera(int x, int y)
    {
        Vector3 pos = new Vector3(x, y, -10); // ���ϴ� ��ġ�� ī�޶��� x, y ��ǥ �̵���Ű��
        Camera.main.gameObject.transform.position = pos;
    }

}