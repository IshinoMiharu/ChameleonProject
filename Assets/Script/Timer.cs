using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text TimerText;
    [SerializeField]
    float _minutes = 1;
    [SerializeField]
    float _limitTime = 00;//��������
    [SerializeField]
    bool _isStop = false;
    
    [SerializeField] private UnityEvent onTimerFinished;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{_minutes}:{_limitTime}");//$�}�[�N+""�̒��Ŗ��ߍ��݂ɂȂ�
        if (!_isStop) { _limitTime -= Time.deltaTime; }//isStop��else�̎����s���Atrue�̎���߂�
        if (_limitTime < 0 && _minutes != 0)//�ꕪ�ȏ�c���Ă���ꍇ�A�������炵�ĕb����59�b�ɂ���
        {
            _minutes--;//������1������
            _limitTime = 59.99f;
        }
        else if (_limitTime < 0 && _minutes == 0)//�ꕪ���c���Ă��Ȃ��ꍇ�͕b����0�ɂ���
        {
            Debug.Log("Finish!");
            _isStop = true;
            _limitTime = 0;
            onTimerFinished?.Invoke();
        }

        TimerText.text = _minutes.ToString("00") + ":"+ ((int)_limitTime).ToString("00");//�c�莞�Ԃ𐮐��ŕ\��
    }
}
