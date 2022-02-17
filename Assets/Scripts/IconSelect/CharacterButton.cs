using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] GameObject IconSelectPanel;
    [SerializeField] GameObject RoomSelectPanel;
    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        RoomSelectPanel.SetActive(false);
        IconSelectPanel.SetActive(true);
        GameManager.Instance.SetCurrentState(GameManager.GameMode.IconSelect);
        Debug.Log("IconSelect��");  // ���O���o��
    }
}
