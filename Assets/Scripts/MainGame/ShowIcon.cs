using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ShowIcon : MonoBehaviour
{
    //未完成



    //MatchmakingViewのPlayerNumを利用してアイコンを表示する
    [SerializeField] GameObject MainGamePanel;
    MatchmakingView _matchmakingView;

    //出題者・解答者でそれぞれ違うのでこうなっている
    [SerializeField] Image EmojiImage1 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image EmojiImage2 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image EmojiImage3 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image EmojiImage4 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image EmojiImage5 = null;//Emoji画像を表示させるImageオブジェクト
    public Image[] IconImages1 = new Image[5];

    [SerializeField] Image IconImage1 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image IconImage2 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image IconImage3 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image IconImage4 = null;//Emoji画像を表示させるImageオブジェクト
    [SerializeField] Image IconImage5 = null;//Emoji画像を表示させるImageオブジェクト
    public Image[] IconImages2 = new Image[5];

    private int i = 0;
    private int j = 0;


    // Start is called before the first frame update
    void Awake()
    {
        IconImages1[0] = EmojiImage1;
        IconImages1[1] = EmojiImage2;
        IconImages1[2] = EmojiImage3;
        IconImages1[3] = EmojiImage4;
        IconImages1[4] = EmojiImage5;

        IconImages2[0] = IconImage1;
        IconImages2[1] = IconImage2;
        IconImages2[2] = IconImage3;
        IconImages2[3] = IconImage4;
        IconImages2[4] = IconImage5;
    }

    void showIcon()
    {
        Debug.Log("アイコンをメインゲームに表示します");
        var players = PhotonNetwork.PlayerList;
        i = 0;
        foreach (var player in players)
        {
            IconImages1[i].sprite = Resources.Load<Sprite>("Image/" + player.GetScore());
            i++;
        }
        j = 0;
        foreach (var player in players)
        {
            IconImages2[j].sprite = Resources.Load<Sprite>("Image/" + player.GetScore());
            j++;
        }
    }
}
