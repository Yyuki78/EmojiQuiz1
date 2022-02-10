using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] GameObject IconSelectPanel;
    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        IconSelectPanel.SetActive(true);
        GameManager.Instance.SetCurrentState(GameManager.GameMode.IconSelect);
        Debug.Log("IconSelect��");  // ���O���o��
    }
}
