using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private GameObject gametitlebgm;
    private GameObject gamestartbgm;
    private GameObject gameoverbgm;
    [SerializeField] AudioClip gameObject;
    private AudioSource audioSource = null;

    // [SerializeField] �Ƃ���ƃC���X�y�N�^�[��ʂɎQ�Ƃ��擾���邽�߂̘g���\������܂�
    private AudioSource _audioSource; 
    [SerializeField] private AudioClip[] _audioClips; // �����f�[�^�̔z��
    // [SerializeField, Tooltip("�ŏ��ɗ�������������index")] private int _initializeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        gametitlebgm = GameObject.Find("GameTitle BGM");
        gamestartbgm = GameObject.Find("GameStart BGM");
        gameoverbgm = GameObject.Find("GameOver BGM");
        audioSource = GetComponent<AudioSource>();

        _audioSource = GetComponent<AudioSource>(); // AudioSource�̎Q�Ƃ��擾����
        //_audioSource.clip = _audioClips[_initializeIndex]; // ���B�z��̈�ԍŏ��̉����f�[�^���Z�b�g����
        //_audioSource.Play(); // BGM���Đ�����
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
    /// BGM��ύX����
    /// </summary>
    /// <param name="index">�N���b�v�̔z��̃C���f�b�N�X</param>
    public void ChangeBGM(int index)
    {
        _audioSource.clip = _audioClips[index]; // ����������؂�ւ���
        _audioSource.Play(); // �Đ�����
    }
}
