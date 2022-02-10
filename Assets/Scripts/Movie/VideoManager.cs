using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField, Tooltip("PlayButton を持つオブジェクト")]
    private GameObject _gameObject2;

    [SerializeField, Tooltip("SkipButton を持つオブジェクト")]
    private GameObject _gameObject3;

    [SerializeField, Tooltip("Video Player を持つオブジェクト")]
    private GameObject _gameObject;

    [SerializeField] GameObject IconSelectPanel;

    VideoPlayer _videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = _gameObject.GetComponent<VideoPlayer>();
        _gameObject3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GameModeがMovieなら動画を再生する
        if (GameManager.Instance.IsMovie)
        {
            PlayMovie();
        }/*
        else
        {
            ResetMovie();
        }*/
    }

    void PlayMovie()
    {
        //動画の再生
        _gameObject2.SetActive(false);
        _gameObject3.SetActive(true);
        _gameObject.SetActive(true);
        _videoPlayer.Play();
        _videoPlayer.loopPointReached += FinishPlayingVideo;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        _videoPlayer.Stop();
        //ここは後で押されたボタンに応じて返還地点を変えるようにする
        Debug.Log("aaaaaa");
        GameManager.Instance.SetCurrentState(GameManager.GameMode.IconSelect);
    }

    void ResetMovie()
    {
        _videoPlayer.Pause();
        _gameObject.SetActive(false);
        _gameObject3.gameObject.SetActive(false);
    }
}
