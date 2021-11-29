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
    private bool roll_flg;

    //カウントダウン
    float countdown = 4.0f;

    //アイテムを大きくする時間制限
    public bool hasBigBall;


    //空中でエフェクトを出さない
    private ParticleSystem ps;
    public bool moduleEnabled;

    void Start()
    {
        InitBall();

        //空中でエフェクトを出さない
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule emission = ps.emission;
        moduleEnabled = false;
        emission.enabled = moduleEnabled;

        Invoke("Call", 4.5f);
    }

    void Update()
    {
        CountDown();
        BigBall();
        if (score == 12)
        {
            Roll_Ball.Stop();
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

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ParticleSystem.EmissionModule emission = ps.emission;
            moduleEnabled = true;
            emission.enabled = moduleEnabled;
            if (rb.velocity.magnitude < 0.3f)
            {
                roll_flg = true;
                if (roll_flg == true)
                {
                    Roll_Ball.Play(); 

                }
            }
            else
            {
                roll_flg = false;
            }
        }
        else
        {
            roll_flg = false;

            ParticleSystem.EmissionModule emission = ps.emission;
            moduleEnabled = false;
            emission.enabled = moduleEnabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item1"))
        {
            hasBigBall = true;
            other.gameObject.SetActive(false);
            StartCoroutine(BigCountdown());
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

    void InitBall()
    {
        score = 0;
        roll_flg = false;
        hasBigBall = false;
        rb = GetComponent<Rigidbody>();
    }

    void CountDown()
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
    }

    void BigBall()
    {
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

    private IEnumerator BigCountdown()
    {
        yield return new WaitForSeconds(7);
        hasBigBall = false;
    }
}