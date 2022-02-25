using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    //���C���Q�[���Ŏg�p�����X�N���v�g�S�Ă̏�����(Start��Init���ɃR�s�y���ČĂ�)
    MainGameManager2 _mainGameManager;
    ChooseThema _chooseThema;
    Timer _timer;
    QuestionsNumber _questionNumber;
    [SerializeField] GameObject CorrectAnswersPanel;
    ShareAnswer _shareAnswer;
    // Start is called before the first frame update
    void Awake()
    {
        _mainGameManager = GetComponent<MainGameManager2>();
        _chooseThema = GetComponent<ChooseThema>();
        _timer = GetComponent<Timer>();
        _questionNumber = GetComponent<QuestionsNumber>();
        _shareAnswer = CorrectAnswersPanel.GetComponent<ShareAnswer>();
    }

    public void ResetAll()
    {
        //�S�Ă��Q�[���J�n��Ԃɂ���
        _mainGameManager.Init();
        _chooseThema.Init();
        _timer.Init();
        _questionNumber.Init();
        _shareAnswer.Init();
    }
}
