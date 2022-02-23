using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ShareAnswer : MonoBehaviourPunCallbacks
{
    //���𔭕\�̃X�N���v�g�v
    [SerializeField] GameObject MainGamePanel;
    private ThemaGenerator _themaGenerator;
    private bool once = true;
    
    [SerializeField] Image QustionerImage;
    [SerializeField] Image CorrectImage;

    [SerializeField] Image IconImage1 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    [SerializeField] Image IconImage2 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    [SerializeField] Image IconImage3 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    [SerializeField] Image IconImage4 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    public Image[] IconImage = new Image[4];

    [SerializeField] Image AnswerImage1 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    [SerializeField] Image AnswerImage2 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    [SerializeField] Image AnswerImage3 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    [SerializeField] Image AnswerImage4 = null;//Emoji�摜��\��������Image�I�u�W�F�N�g
    public Image[] AnswerImage = new Image[4];

    private int i = 0;
    private int k = 0;


    // Start is called before the first frame update
    void Awake()
    {
        _themaGenerator = MainGamePanel.GetComponent<ThemaGenerator>();
        
        IconImage[0] = IconImage1;
        IconImage[1] = IconImage2;
        IconImage[2] = IconImage3;
        IconImage[3] = IconImage4;

        AnswerImage[0] = AnswerImage1;
        AnswerImage[1] = AnswerImage2;
        AnswerImage[2] = AnswerImage3;
        AnswerImage[3] = AnswerImage4;

        QustionerImage.gameObject.SetActive(false);
        CorrectImage.gameObject.SetActive(false);
        IconImage1.gameObject.SetActive(false);
        IconImage2.gameObject.SetActive(false);
        IconImage3.gameObject.SetActive(false);
        IconImage4.gameObject.SetActive(false);
        AnswerImage1.gameObject.SetActive(false);
        AnswerImage2.gameObject.SetActive(false);
        AnswerImage3.gameObject.SetActive(false);
        AnswerImage4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentState() == GameManager.GameMode.MainGame)
        {
            if (MainGameManager2.mainmode == MainGameManager2.MainGameMode.ShareAnswer)
            {
                if (PhotonNetwork.LocalPlayer.IsMasterClient)
                {
                    if (once == true)
                    {
                        photonView.RPC(nameof(RpcShareAnswer), RpcTarget.All, PhotonNetwork.LocalPlayer.GetScore());
                        once = false;
                    }
                }
            }
        }
    }

    [PunRPC]
    private void RpcShareAnswer(int thema)
    {
        StartCoroutine(shareAnswer(thema));
    }

    private IEnumerator shareAnswer(int thema)
    {
        Debug.Log("���𔭕\���n�߂܂�");
        var players = PhotonNetwork.PlayerList;
        var players2 = PhotonNetwork.PlayerList;

        //�A�C�R���̐���
        QustionerImage.sprite = Resources.Load<Sprite>("Image/" + thema);
        i = 0;
        foreach (var player in players)
        {
            yield return new WaitForSeconds(0.1f);
            if (player.IsMasterClient) continue;
            IconImage[i].sprite = Resources.Load<Sprite>("Image/" + player.GetScore());
            i++;
        }
        QustionerImage.gameObject.SetActive(true);
        for(int j = 0; j < 4; j++)
        {
            IconImage[j].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(2.0f);

        //��������I�񂾑I�����̕\��
        k = 0;
        foreach (var player in players2)
        {
            if (player.IsMasterClient) continue;
            AnswerImage[k].sprite = Resources.Load<Sprite>("Image/" + player.GetChoiceNum());
            Debug.Log(player.GetChoiceNum());
            k++;
        }
        for (int j = 0; j < 4; j++)
        {
            yield return new WaitForSeconds(1.0f);
            AnswerImage[j].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(3.0f);

        //�������琳���̕\���Ɛ���s�����̕\��
        CorrectImage.sprite = Resources.Load<Sprite>("Image/" + _themaGenerator._themaNum);
        CorrectImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(5.0f);
        Debug.Log("���𔭕\���I�����܂�");
        yield break;
    }
}
