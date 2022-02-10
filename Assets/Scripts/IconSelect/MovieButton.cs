using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieButton : MonoBehaviour
{
    [SerializeField] GameObject MoviePanel;
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        MoviePanel.SetActive(true);
        GameManager.Instance.SetCurrentState(GameManager.GameMode.Movie);
        Debug.Log("Movieへ");  // ログを出力
    }
}
