using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuestionNumber : MonoBehaviour
{
    //問題数の切り替えをするBefore
    [SerializeField] GameObject Num1;
    [SerializeField] GameObject Num2;
    [SerializeField] GameObject Num3;
    [SerializeField] GameObject Num4;
    [SerializeField] GameObject Num5;
    [SerializeField] GameObject Num6;
    [SerializeField] GameObject Num7;
    [SerializeField] GameObject Num8;
    [SerializeField] GameObject Num9;
    [SerializeField] GameObject Num10;
    private GameObject[] Num = new GameObject[10];

    //問題数の切り替えをするAfter
    [SerializeField] GameObject aNum1;
    [SerializeField] GameObject aNum2;
    [SerializeField] GameObject aNum3;
    [SerializeField] GameObject aNum4;
    [SerializeField] GameObject aNum5;
    [SerializeField] GameObject aNum6;
    [SerializeField] GameObject aNum7;
    [SerializeField] GameObject aNum8;
    [SerializeField] GameObject aNum9;
    [SerializeField] GameObject aNum10;
    private GameObject[] aNum = new GameObject[10];

    private bool once = true;

    // Start is called before the first frame update
    void Awake()
    {
        Num[0] = Num1;
        Num[1] = Num2;
        Num[2] = Num3;
        Num[3] = Num4;
        Num[4] = Num5;
        Num[5] = Num6;
        Num[6] = Num7;
        Num[7] = Num8;
        Num[8] = Num9;
        Num[9] = Num10;
        for (int i = 0; i < 10; i++)
        {
            Num[i].gameObject.SetActive(false);
        }

        aNum[0] = aNum1;
        aNum[1] = aNum2;
        aNum[2] = aNum3;
        aNum[3] = aNum4;
        aNum[4] = aNum5;
        aNum[5] = aNum6;
        aNum[6] = aNum7;
        aNum[7] = aNum8;
        aNum[8] = aNum9;
        aNum[9] = aNum10;
        for (int i = 0; i < 10; i++)
        {
            aNum[i].gameObject.SetActive(false);
        }

        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentState() == GameManager.GameMode.MainGame)
        {
            if (MainGameManager2.mainmode == MainGameManager2.MainGameMode.PlayerSelect)
            {
                if (once == true)
                {
                    for (int i = 0; i < MainGameManager2.playcount-1; i++)
                    {
                        Num[i].gameObject.SetActive(true);
                    }
                    for (int i = 0; i < MainGameManager2.playcount; i++)
                    {
                        aNum[i].gameObject.SetActive(true);
                    }
                    once = false;
                }
            }
        }
    }

    public void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            Num[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 10; i++)
        {
            aNum[i].gameObject.SetActive(false);
        }
        once = true;
    }
}
