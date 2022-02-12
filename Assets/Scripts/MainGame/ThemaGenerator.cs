using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ThemaGenerator : MonoBehaviour
{
    [SerializeField] Image EmojiImage = null;

    private EmojiInformation emojiInfo;//CSV��ǂݍ���EmojiInformation�N���X���������߂ɐ錾

    public int _themaNum;//����̔ԍ�
    public byte[] _themaBytes;//����̔ԍ���byte�^

    public int[] _choicesNum;//�I�����̔ԍ�

    // Start is called before the first frame update
    private void Start()
    {
        emojiInfo = new EmojiInformation();//EmojiInformation�N���X�̎��̂Ƃ���emojiInfo����
        emojiInfo.Init();//CSV�f�[�^�̓ǂݍ��݂ƕϐ��ւ̊i�[����
        ThemaGenerate();
    }

    //�����ł���̐����𐶐�����
    public void ThemaGenerate()
    {
        _themaNum = UnityEngine.Random.Range(1, 129);
        Debug.Log("�����" + _themaNum);
        _themaBytes = BitConverter.GetBytes(_themaNum);
        EmojiImage.sprite= Resources.Load<Sprite>(emojiInfo.imageAddress[_themaNum]);
    }

    //�����őI�����̐����𐶐�����
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
