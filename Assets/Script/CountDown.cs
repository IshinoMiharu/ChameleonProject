using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float countDown = 4.0f;
    Text text;//�e�L�X�g�̃I�u�W�F�N�g�ɃA�^�b�`���邱��
    public GameObject[] objectToActivate; //ここに入っているオブジェクトを表示させる。
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0.5f)
        {
            text.text = "";
            foreach (GameObject obj in objectToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true); // リストないのオブジェクトをforeachで一斉に表示！
                }
            }
            this.gameObject.SetActive(false);
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
