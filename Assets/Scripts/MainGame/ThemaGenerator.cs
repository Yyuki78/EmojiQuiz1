using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ThemaGenerator : MonoBehaviour
{
    [SerializeField] Image EmojiImage = null;

    private EmojiInformation emojiInfo;//CSVを読み込むEmojiInformationクラスを扱うために宣言

    public int _themaNum;//お題の番号
    public byte[] _themaBytes;//お題の番号のbyte型

    public int[] _choicesNum;//選択肢の番号

    // Start is called before the first frame update
    private void Start()
    {
        emojiInfo = new EmojiInformation();//EmojiInformationクラスの実体としてemojiInfo生成
        emojiInfo.Init();//CSVデータの読み込みと変数への格納処理
        ThemaGenerate();
    }

    //ここでお題の数字を生成する
    public void ThemaGenerate()
    {
        _themaNum = UnityEngine.Random.Range(1, 129);
        Debug.Log("お題は" + _themaNum);
        _themaBytes = BitConverter.GetBytes(_themaNum);
        EmojiImage.sprite= Resources.Load<Sprite>(emojiInfo.imageAddress[_themaNum]);
    }

    //ここで選択肢の数字を生成する
    public void ChoicesGenerate()
    {
        _choicesNum = new int[5];
        _choicesNum[0] = _themaNum;
        do
        {
            int _attribute2 = emojiInfo.emojiAttribute2[_themaNum];
            int[] match = new int[5];
            int n = 0;
            
            for(int i = 0; i < emojiInfo.emojiID.Length; i++)
            {
                if (_attribute2 == emojiInfo.emojiAttribute2[i])
                {
                    match[n] = i;
                    n++;
                }
            }
            
        } while (_choicesNum[0] == _choicesNum[1]);
    }
}
