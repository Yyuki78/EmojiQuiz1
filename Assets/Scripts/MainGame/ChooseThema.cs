using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChooseThema : MonoBehaviourPunCallbacks
{
    private ThemaGenerator _themaGenerator;
    private bool once = true;

    // Start is called before the first frame update
    void Start()
    {
        _themaGenerator = GetComponent<ThemaGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentState() == GameManager.GameMode.MainGame)
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                if (once == true)
                {
                    _themaGenerator.ThemaGenerate();
                    _themaGenerator.ChoicesGenerate();
                    photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, _themaGenerator._themaNum, _themaGenerator._choicesNum);
                    once = false;
                }
                else
                {
                    
                }
            }
            else
            {

            }
        }
    }

    [PunRPC]
    private void RpcSendMessage(int thema, int[] choices)
    {
        StartCoroutine(Showchoice(thema, choices));
    }

    private IEnumerator Showchoice(int thema, int[] choices)
    {
        Debug.Log("Ç®ëËÇ∆ëIëéàÇéÛÇØéÊÇ¡ÇƒÇªÇÍÇºÇÍï\é¶ÅI");
        yield return new WaitForSeconds(1.0f);
        _themaGenerator.Showchoices(thema, choices);
        yield break;
    }
}
