using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    //Rigidbody型を変数rigidで宣言します。
    private Rigidbody rigid;
    //Vector3型を変数posで宣言します。
    private Vector3 pos = new Vector3(1450+512, 374, 0);
    //float型を変数speedで宣言
    private float speed = 20f;

    void Start()
    {

        //GetComponentでRigidbodyを取得して変数rigidで参照します。
        rigid = GetComponent<Rigidbody>();

        rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));
        //1.5秒後に終わり
        //Invoke(nameof(VanishMethod), 1.5f);
        StartCoroutine("Change");
    }

    public IEnumerator Change()
    {
        pos = new Vector3(1450 + 512, 374, 0);
        rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));

        // 指定秒間待つ
        //yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 150; i++)
        {

            //Y座標はspeedの値を足された位置に。
            pos.x = pos.x - speed;
            //変数rigidの動く座標位置の取得。
            rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));

            yield return new WaitForSeconds(0.01f);
        }
        this.gameObject.SetActive(false);
    }
}
