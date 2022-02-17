using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField] GameObject MoviePanel;
    [SerializeField] GameObject ResultPanel;
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        GameManager.Instance.SetCurrentState(GameManager.GameMode.Result);
        MoviePanel.SetActive(false);
        ResultPanel.SetActive(true);
        Debug.Log("Resultへ遷移！");  // ログを出力
    }
}
