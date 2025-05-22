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
        //Rigdbodyを使った移動
        if (Input.GetKey(KeyCode.Space)) //スペースキー押したら
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //早い左移動
            {
                transform.eulerAngles = new Vector3(0, 180, 0);//左向く
                _rb.velocity = transform.right * highspeed;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //早い右移動
            {
                transform.eulerAngles = new Vector3(0, 0, 0);//右向く
                _rb.velocity = transform.right * highspeed;
            }
            else  //左右の矢印が押されていないなら止まる
            {
                _rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //通常左移動
            {
                transform.eulerAngles = new Vector3(0, 180, 0);//左向く
                _rb.velocity = transform.right * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //通常右移動
            {
                transform.eulerAngles = new Vector3(0, 0, 0);//右向く
                _rb.velocity = transform.right * speed;
            }
            else  //左右の矢印が押されていないなら止まる
            {
                _rb.velocity = Vector2.zero;
            }
        }

        //transform.positionを使った移動
        //if (Input.GetKey(KeyCode.RightArrow)) //右移動
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.LeftArrow))  //左移動
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
    }
}
