using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject gametitlebgm;
    private GameObject gamestartbgm;
    private GameObject gameoverbgm;
    [SerializeField] AudioClip gameObject;
    private AudioSource audioSource = null;

    // [SerializeField] とつけるとインスペクター画面に参照を取得するための枠が表示されます
    private AudioSource _audioSource; 
    [SerializeField] private AudioClip[] _audioClips; // 音源データの配列
    // [SerializeField, Tooltip("最初に流したい音源のindex")] private int _initializeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        gametitlebgm = GameObject.Find("GameTitle BGM");
        gamestartbgm = GameObject.Find("GameStart BGM");
        gameoverbgm = GameObject.Find("GameOver BGM");
        audioSource = GetComponent<AudioSource>();

        _audioSource = GetComponent<AudioSource>(); // AudioSourceの参照を取得する
        //_audioSource.clip = _audioClips[_initializeIndex]; // 仮。配列の一番最初の音源データをセットする
        //_audioSource.Play(); // BGMを再生する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        audioSource = gametitlebgm.GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource = gamestartbgm.GetComponent<AudioSource>();
        audioSource.Play();
    }
    public void GameOver()
    {
        audioSource = gamestartbgm.GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource = gameoverbgm.GetComponent<AudioSource>();
        audioSource.Play();
    }

    /// <summary>
    /// BGMを変更する
    /// </summary>
    /// <param name="index">クリップの配列のインデックス</param>
    public void ChangeBGM(int index)
    {
        _audioSource.clip = _audioClips[index]; // 流す音源を切り替える
        _audioSource.Play(); // 再生する
    }
}
