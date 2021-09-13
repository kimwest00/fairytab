using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lock_controller : MonoBehaviour
{

    private Text Txt1; //자물쇠 숫자 텍스트
    private Text Txt2;
    private Text Txt3;
    private Text Txt4;

    private int Num1 = 0; //자물쇠 숫자 조절용 변수
    private int Num2 = 0;
    private int Num3 = 0;
    private int Num4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        Txt1 = GameObject.Find("Num1").GetComponent<Text>(); //텍스트 이름으로 가져오기
        Txt2 = GameObject.Find("Num2").GetComponent<Text>();
        Txt3 = GameObject.Find("Num3").GetComponent<Text>();
        Txt4 = GameObject.Find("Num4").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 터치한 좌표 가져옴
            Ray2D ray = new Ray2D(wp, Vector2.zero); // 원점에서 터치한 좌표 방향으로 Ray를 쏨
            float distance = Mathf.Infinity; // Ray 내에서 감지할 최대 거리 
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance); // 다 잡음 
            RaycastHit2D hitButton = Physics2D.Raycast(ray.origin, ray.direction, distance, 1 << LayerMask.NameToLayer("Button")); // Button 레이어만 잡음 
            if (hit) { // 게임 배경화면 등이 눌렸을 때 에러가 발생하는 것을 방지하기 위한 부분 
                if (hitButton) { // Button 눌렀을 때 
                    if(ray.origin.x < -3) //좌표로 버튼 구분해서 숫자 조절
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
