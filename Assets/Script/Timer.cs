using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text TimerText;
    [SerializeField]
    float _minutes = 1;
    [SerializeField]
    float _limitTime = 00;//制限時間
    [SerializeField]
    bool _isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{_minutes}:{_limitTime}");//$マーク+""の中で埋め込みになる
        if (!_isStop) { _limitTime -= Time.deltaTime; }//isStopがelseの時実行し、trueの時やめる
        if (_limitTime < 0 && _minutes != 0)//一分以上残っている場合、分を減らして秒数を59秒にする
        {
            _minutes--;//分から1を引く
            _limitTime = 59.99f;
        }
        else if (_limitTime < 0 && _minutes == 0)//一分も残っていない場合は秒数を0にする
        {
            Debug.Log("Finish!");
            _isStop = true;
            _limitTime = 0;
        }

        TimerText.text = _minutes.ToString("00") + ":"+ ((int)_limitTime).ToString("00");//残り時間を整数で表示
    }
}
