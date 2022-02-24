using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;

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
    private async void Update()
    {
        if (GameManager.Instance.GetCurrentState() == GameManager.GameMode.MainGame)
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                if (once == true)
                {
                    Debug.Log("ñ‚ëËÇçÏê¨ÇµÇ‹Ç∑");
                    _themaGenerator.ThemaGenerate();
                    _themaGenerator.ChoicesGenerate();
                    await Task.Delay(5000);
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
        Debug.Log(thema + "," + choices[0] + "," + choices[1] + "," + choices[2] + "," + choices[3] + "," + choices[4]);
        yield return new WaitForSeconds(1.0f);
        _themaGenerator.Showchoices(thema, choices);
        yield break;
    }

    public void Init()
    {
        once = true;
    }
}
