using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] GameObject IconSelectPanel;
    [SerializeField] GameObject RoomSelectPanel;
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        IconSelectPanel.SetActive(true);
        RoomSelectPanel.SetActive(false);
        GameManager.Instance.SetCurrentState(GameManager.GameMode.IconSelect);
        Debug.Log("IconSelectへ");  // ログを出力
    }
}
