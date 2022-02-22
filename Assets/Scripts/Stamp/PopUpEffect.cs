using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpEffect : MonoBehaviour
{
    //Rigidbody�^��ϐ�rigid�Ő錾���܂��B
    private Rigidbody rigid;
    //Vector3�^��ϐ�pos�Ő錾���܂��B
    private Vector3 pos;
    //float�^��ϐ�speed�Ő錾���čŏ��̒l��5�Ƃ��܂��B
    private float speed = 1f;

    public bool IsActive => gameObject.activeSelf;

    Image mesh;

    private void Start()
    {
        pos = transform.position;
        mesh = GetComponent<Image>();
        mesh.color = mesh.color - new Color32(0, 0, 0, 20);
        //GetComponent��Rigidbody���擾���ĕϐ�rigid�ŎQ�Ƃ��܂��B
        rigid = GetComponent<Rigidbody>();

        StartCoroutine("PopUp");
    }

    public void Init(Vector3 origin)
    {
        pos = origin;
        mesh = GetComponent<Image>();
        mesh.color = new Color32(255, 255, 255, 235);

        //GetComponent��Rigidbody���擾���ĕϐ�rigid�ŎQ�Ƃ��܂��B
        rigid = GetComponent<Rigidbody>();
        //1.5�b��ɏI���
        //Invoke(nameof(VanishMethod), 1.5f);

        gameObject.SetActive(true);

        StartCoroutine("PopUp");
    }
    /*
    private void FixedUpdate()
    {
        //Y���W��speed�̒l�𑫂��ꂽ�ʒu�ɁB
        pos.y = pos.y + speed;
        //�ϐ�rigid�̓������W�ʒu�̎擾�B
        rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));
        
        //���X�ɓ�����
        mesh.color = mesh.color - new Color32(0, 0, 0, 10);
    }

    private void VanishMethod()
    {
        this.gameObject.SetActive(false);
    }*/

    private IEnumerator PopUp()
    {
        //rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));

        // �w��b�ԑ҂�
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 100; i++)
        {
            //���X�ɓ�����
            mesh.color = mesh.color - new Color32(0, 0, 0, 2);

            //Y���W��speed�̒l�𑫂��ꂽ�ʒu�ɁB
            pos.y = pos.y + speed;
            //�ϐ�rigid�̓������W�ʒu�̎擾�B
            rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));

            yield return new WaitForSeconds(0.01f);
        }
        this.gameObject.SetActive(false);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
