using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieButton : MonoBehaviour
{
    [SerializeField] GameObject MoviePanel;
    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        MoviePanel.SetActive(true);
        GameManager.Instance.SetCurrentState(GameManager.GameMode.Movie);
        Debug.Log("Movie��");  // ���O���o��
    }
}
