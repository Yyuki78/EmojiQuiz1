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

    [SerializeField] GameObject MoviePanel;
    [SerializeField] GameObject IconSelectPanel;
    [SerializeField] GameObject RoomSelectPanel;

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

    public GameMode GetCurrentState()
    {
        return Instance.currentGameState;
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
                IconSelectAction();
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
        MoviePanel.SetActive(true);
        IconSelectPanel.SetActive(false);
    }

    // IconSelect�ɂȂ����Ƃ��̏���
    void IconSelectAction()
    {
        Debug.Log("IconSelectMode");
        MoviePanel.SetActive(false);
        IconSelectPanel.SetActive(true);
    }
    // RoomSelect�ɂȂ����Ƃ��̏���
    void RoomSelectAction()
    {
        Debug.Log("RoomSelectMode");
        MoviePanel.SetActive(false);
        IconSelectPanel.SetActive(true);
        RoomSelectPanel.SetActive(true);
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
