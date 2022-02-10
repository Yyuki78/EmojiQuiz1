using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameMode
    {
        Start,
        Movie,
        IconSelect,
        RoomSelect,
        InRoom,
        MainGame,
        Result
    }

    public static GameManager Instance;

    // 現在の状態
    private GameMode currentGameState;

    //MovieModeかどうか
    public bool IsMovie => GameMode.Movie == currentGameState;

    public Text label;
    public Button button;

    void Awake()
    {
        Instance = this;
        SetCurrentState(GameMode.Start);
    }


    // 外からこのメソッドを使って状態を変更
    public void SetCurrentState(GameMode state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // 状態が変わったら何をするか
    void OnGameStateChanged(GameMode state)
    {
        switch (state)
        {
            case GameMode.Movie:
                MovieAction();
                break;
            case GameMode.IconSelect:
                StartCoroutine(IconSelectCoroutine());
                break;
            case GameMode.RoomSelect:
                RoomSelectAction();
                break;
            case GameMode.InRoom:
                RoomSelectAction();
                break;
            case GameMode.MainGame:
                RoomSelectAction();
                break;
            case GameMode.Result:
                EndAction();
                break;
            default:
                break;
        }
    }

    // Movieになったときの処理
    void MovieAction()
    {
        Debug.Log("MovieMode");
    }

    // IconSelectになったときの処理
    IEnumerator IconSelectCoroutine()
    {
        Debug.Log("IconSelectMode");
        label.text = "3";
        yield return new WaitForSeconds(1);
        label.text = "2";
        yield return new WaitForSeconds(1);
        label.text = "1";
        yield return new WaitForSeconds(1);
        label.text = "";
        SetCurrentState(GameMode.IconSelect);
    }
    // RoomSelectになったときの処理
    void RoomSelectAction()
    {
        Debug.Log("RoomSelectMode");
    }
    // Endになったときの処理
    void EndAction()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
