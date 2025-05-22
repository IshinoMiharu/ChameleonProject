using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float speed;
    [SerializeField] float highspeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rigdbody���g�����ړ�
        if (Input.GetKey(KeyCode.Space)) //�X�y�[�X�L�[��������
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //�������ړ�
            {
                _rb.velocity = -transform.right * highspeed;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //�����E�ړ�
            {
                _rb.velocity = transform.right * highspeed;
            }
            else  //���E�̖�󂪉�����Ă��Ȃ��Ȃ�~�܂�
            {
                _rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //�ʏ퍶�ړ�
            {
                _rb.velocity = -transform.right * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //�ʏ�E�ړ�
            {
                _rb.velocity = transform.right * speed;
            }
            else  //���E�̖�󂪉�����Ă��Ȃ��Ȃ�~�܂�
            {
                _rb.velocity = Vector2.zero;
            }
        }

        //transform.position���g�����ړ�
        //if (Input.GetKey(KeyCode.RightArrow)) //�E�ړ�
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.LeftArrow))  //���ړ�
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
    }
}
