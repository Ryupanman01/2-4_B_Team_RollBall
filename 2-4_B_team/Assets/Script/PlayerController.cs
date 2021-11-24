using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public static int score;   //スコア
    private Vector3 lastvelocity;
    private Rigidbody rb;

    public GameObject Item; //アイテム

    //エフェクト
    public ParticleSystem explode;
    public ParticleSystem explode1;

    //SE
    public AudioSource Roll_Ball;

    //カウントダウン
    float countdown = 4.0f;

    //アイテムを大きくする時間制限
    public bool hasBigBall;

    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //カウントダウン
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        else
        {
            lastvelocity = rb.velocity;
            rb.isKinematic = false;
        }

        //ボールの大きさを変える
        if (hasBigBall == true)
        {
            //大きさを二倍にする
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f) * 1.5f;
        }
        else if (hasBigBall == false)
        {
            //ボールの大きさを元に戻す
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //衝突した相手にWallタグが付いているとき
        if (collision.gameObject.tag == "Wall")
        {
            //反射する
            Vector3 refrectVec = Vector3.Reflect(lastvelocity, collision.contacts[0].normal);
            rb.velocity = refrectVec;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item1"))
        {
            hasBigBall = true;
            other.gameObject.SetActive(false);
            StartCoroutine(SpeedupCountdown());
            //エフェクト追加
            explode1.transform.position = transform.position;
            //エフェクト再生
            explode1.Play();
            //ログ表示
            Debug.Log("加速アイテムに当たった");
        }

        //衝突した相手にPlayerタグがついているとき
        if (other.gameObject.CompareTag("Item"))
        {
            //エフェクト追加
            explode.transform.position = transform.position;
            //その収集アイテムを非表示にする
            other.gameObject.SetActive(false);
            //スコアを加算する
            score = score + 1;
            //ログ表示
            Debug.Log("コインに当たった");
            //エフェクト再生
            explode.Play();
        }
    }

    private IEnumerator SpeedupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasBigBall = false;
    }
}