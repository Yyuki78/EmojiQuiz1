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

    // ���݂̏��
    private GameMode currentGameState;

    //MovieMode���ǂ���
    public bool IsMovie => GameMode.Movie == currentGameState;

    public Text label;
    public Button button;

    void Awake()
    {
        Instance = this;
        SetCurrentState(GameMode.Start);
    }


    // �O���炱�̃��\�b�h���g���ď�Ԃ�ύX
    public void SetCurrentState(GameMode state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // ��Ԃ��ς�����牽�����邩
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

    // Movie�ɂȂ����Ƃ��̏���
    void MovieAction()
    {
        Debug.Log("MovieMode");
    }

    // IconSelect�ɂȂ����Ƃ��̏���
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
    // RoomSelect�ɂȂ����Ƃ��̏���
    void RoomSelectAction()
    {
        Debug.Log("RoomSelectMode");
    }
    // End�ɂȂ����Ƃ��̏���
    void EndAction()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
