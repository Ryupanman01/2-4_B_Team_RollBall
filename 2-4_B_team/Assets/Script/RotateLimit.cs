using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLimit : MonoBehaviour
{
    [SerializeField]
    [Tooltip("最小角度(-180～180")]
    private float MinAngle;

    [SerializeField]
    [Tooltip("最大角度(-180～180")]
    private float MaxAngle;

    [SerializeField]
    [Tooltip("回転するスピード")]       //test2
    private float step;

    [SerializeField]
    [Tooltip("スピード")]       //test2
    private float speed;

    [SerializeField]
    [Tooltip("回転するスピード")]
    private float MinSpeed;

    [SerializeField]
    [Tooltip("加速")]
    float kasoku; //test1

    void FixedUpdate()
    {
        // 左右キーの入力を取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 現在のGameObjectのY軸方向の角度を取得
        float floorZAngle = transform.eulerAngles.z;
        float floorXAngle = transform.eulerAngles.x;


        // 現在の角度が180より大きい場合
        if (floorZAngle > 180)
        {
            // デフォルトでは角度は0～360なので-180～180となるように補正
            floorZAngle = floorZAngle - 360;
        }
        if (floorXAngle > 180)
        {
            // デフォルトでは角度は0～360なので-180～180となるように補正
            floorXAngle = floorXAngle - 360;
        }

        /*****************************************/
        //test2 slerp
        float speed = 0.6f;               //傾きのスピード
        //float step;
        Vector3 dir = Vector3.zero;


        dir.x = -Input.acceleration.x;
        dir.z = Input.acceleration.z;

        dir *= Time.deltaTime;

        step = speed * Time.deltaTime;

        if (Input.GetAxis("Vertical") > 0)  //上入力
        {
            speed += 1.0f;                  //スピード＋１
            if (floorXAngle < 30f)          //30度まで傾く
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(40f * vertical, 0, 0), step);//加速し減速
            }
        }
        else if (Input.GetAxis("Vertical") < 0) //下入力
        {
            if (floorXAngle > -30f)             //30度まで傾く
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-40f * -vertical, 0, 0), step);//加速し減速
            }
        }
        else
        {
            if (floorXAngle > 0 || floorXAngle < 0)     //入力がないかつ傾いているとき
            {
                speed = 0.6f;                             //スピードを1に戻す
                transform.Rotate(floorXAngle / -30f, 0f, 0f);   //減速しながら傾きを0度にする
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(floorXAngle / 8f, 0, 0), step);
            }
        }

        if (Input.GetAxis("Horizontal") < 0)
        {

            speed += 1.0f;
            if (floorZAngle < 30f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 40f * -horizontal), step);
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (floorZAngle > -30f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -40f * horizontal), step);
            }
        }
        else
        {
            if (floorZAngle > 0 || floorZAngle < 0)
            {
                speed = 0.6f;
                transform.Rotate(0f, 0f, floorZAngle / -30f);
            }
        }

        /**************************************/

        ///*****************************************/
        //if (Input.GetAxisRaw("Vertical") > 0)
        //{
        //    if (floorXAngle < 30f)
        //    {
        //        MinSpeed += 0.001f;
        //        transform.Rotate(MinSpeed, 0f, 0f);
        //    }
        //}
        //else if (Input.GetAxisRaw("Vertical") < 0)
        //{
        //    if (floorXAngle > -30f)
        //    {
        //        transform.Rotate(-1f * MinSpeed, 0f, 0f);
        //    }
        //}
        //else
        //{
        //    if (floorXAngle > 0 || floorXAngle < 0)
        //    {
        //        MinSpeed = 0.01f;
        //        transform.Rotate(floorXAngle / -8f, 0f, 0f);
        //    }
        //}

        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{

        //    if (floorZAngle < 30f)
        //    {
        //        transform.Rotate(0f, 0f, 1f * MinSpeed);
        //    }
        //}
        //else if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    if (floorZAngle > -30f)
        //    {
        //        transform.Rotate(0f, 0f, -1f * MinSpeed);
        //    }
        //}
        //else
        //{
        //    if (floorZAngle > 0 || floorZAngle < 0)
        //    {
        //        transform.Rotate(0f, 0f, floorZAngle / -8f);
        //    }
        //}
        /*****************************************/

        //if (Input.GetAxisRaw("Vertical") > 0)
        //{

        //    if (floorXAngle < 30f)
        //    {
        //        transform.Rotate(1f * MinSpeed, 0f, 0f);
        //    }
        //}
        //else if (Input.GetAxisRaw("Vertical") < 0)
        //{
        //    if (floorXAngle > -30f)
        //    {
        //        transform.Rotate(-1f * MinSpeed, 0f, 0f);
        //    }
        //}
        //else
        //{
        //    if (floorXAngle > 0 || floorXAngle < 0)
        //    {
        //        transform.Rotate(floorXAngle / -8f, 0f, 0f);
        //    }
        //}

        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{

        //    if (floorZAngle < 30f)
        //    {
        //        transform.Rotate(0f, 0f, 1f * MinSpeed);
        //    }
        //}
        //else if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    if (floorZAngle > -30f)
        //    {
        //        transform.Rotate(0f, 0f, -1f * MinSpeed);
        //    }
        //}
        //else
        //{
        //    if (floorZAngle > 0 || floorZAngle < 0)
        //    {
        //        transform.Rotate(0f, 0f, floorZAngle / -8f);
        //    }
        //}



    }
}
