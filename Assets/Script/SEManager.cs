using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource audioSource = null;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBGM(int index)
    {
        _audioSource.clip = _audioClips[index]; // ó¨Ç∑âπåπÇêÿÇËë÷Ç¶ÇÈ
        _audioSource.Play(); // çƒê∂Ç∑ÇÈ
    }
}
