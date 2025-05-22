using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float countDown = 4.0f;
    Text text;//テキストのオブジェクトにアタッチすること
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0.0f)
        {
            text.text = "";
        }
        else if (countDown < 1.0f)
        {
            text.text = "Start!";
        }
        else if (countDown < 2.0f)
        {
            text.text = "1";
        }
        else if (countDown < 3.0f)
        {
            text.text = "2";
        }
    }
}
