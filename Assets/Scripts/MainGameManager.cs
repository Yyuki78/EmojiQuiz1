using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MainGameManager : MonoBehaviourPunCallbacks
{
    public enum MainGameMode
    {
        LoadGame = 0,
        PlayerSelect,
        ReportQuestion,
        QuestionTime,
        ShareAnswer,
        ReportAnswer,
    }
    public static MainGameMode mainmode;
    private static MainGameMode premainmode;
    public static int playcount = 0;
    private bool preSetting;
    public static float modetime;//���private�ɕς���
    private int SST;

    private PhotonView M_photonView;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetCurrentState(GameManager.GameMode.MainGame);
        mainmode = MainGameMode.LoadGame;
        M_photonView = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentState() == GameManager.GameMode.MainGame)
        {
            Debug.Log(modetime);
            modetime -= (float)Time.deltaTime;
            switch (mainmode)
            {
                case MainGameMode.LoadGame:
                    if (preSetting)
                    {
                        preLG();
                    }
                    if (PhotonNetwork.ServerTimestamp - SST <= 3000)
                    {
                        premainmode = MainGameMode.PlayerSelect;
                    }
                    break;
                case MainGameMode.PlayerSelect:
                    if (preSetting)
                    {
                        prePS();
                    }
                    if (modetime <= 0)
                    {
                        premainmode = MainGameMode.ReportQuestion;
                    }
                    break;
                case MainGameMode.ReportQuestion:
                    if (preSetting)
                    {
                        preRQ();
                    }
                    if (modetime <= 0)
                    {
                        premainmode = MainGameMode.QuestionTime;
                    }
                    break;
                case MainGameMode.QuestionTime:
                    if (preSetting)
                    {
                        preQT();
                    }
                    if (modetime <= 0)
                    {
                        premainmode = MainGameMode.ShareAnswer;
                    }
                    break;
                case MainGameMode.ShareAnswer:
                    if (preSetting)
                    {
                        preSA();
                    }
                    if (modetime <= 0)
                    {
                        premainmode = MainGameMode.ReportAnswer;
                    }
                    break;
                case MainGameMode.ReportAnswer:
                    if (preSetting)
                    {
                        preRA();
                    }
                    if (modetime <= 0)
                    {
                        premainmode = MainGameMode.PlayerSelect;
                    }
                    break;
            }
            if (mainmode != premainmode)
            {
                switch (premainmode)
                {
                    case MainGameMode.PlayerSelect:
                        mainmode = MainGameMode.PlayerSelect;
                        break;
                    case MainGameMode.ReportQuestion:
                        mainmode = MainGameMode.ReportQuestion;
                        break;
                    case MainGameMode.QuestionTime:
                        mainmode = MainGameMode.QuestionTime;
                        break;
                    case MainGameMode.ShareAnswer:
                        mainmode = MainGameMode.ShareAnswer;
                        break;
                    case MainGameMode.ReportAnswer:
                        mainmode = MainGameMode.ReportAnswer;
                        break;
                }
                preSetting = true;
            }
        }
    }
    private void preLG()
    {
        SST = PhotonNetwork.ServerTimestamp;
        M_photonView.RPC(nameof(NetworkOperate.Operate.SendServerTime), RpcTarget.MasterClient, SST);
        //M_photonView.RPC(nameof(NetworkOperate.Operate.SelectPlayer), RpcTarget.MasterClient, �L�����N�^��);
        //M_photonView.RPC(nameof(NetworkOperate.Operate.OperateQuestion), RpcTarget.MasterClient, �G�����̑I�����ԍ���byte�z��, �����̔ԍ�);
    }
    private void prePS()
    {
        modetime = 3.0f;
        playcount++;
        preSetting = false; 
    }
    private void preRQ()
    {
        modetime = 3.0f;
        preSetting = false;
    }
    private void preQT()
    {
        modetime = 30.0f;
        preSetting = false;
    }
    private void preSA()
    {
        modetime = 4.0f;
        preSetting = false;
    }
    private void preRA()
    {
        modetime = 8.0f;

        preSetting = false;
    }

    private void Shuffle(byte players)
    {

    }

}
