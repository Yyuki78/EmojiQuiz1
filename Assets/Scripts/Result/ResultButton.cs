using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField] GameObject MoviePanel;
    [SerializeField] GameObject ResultPanel;
    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        GameManager.Instance.SetCurrentState(GameManager.GameMode.Result);
        MoviePanel.SetActive(false);
        ResultPanel.SetActive(true);
        Debug.Log("Result�֑J�ځI");  // ���O���o��
    }
}
