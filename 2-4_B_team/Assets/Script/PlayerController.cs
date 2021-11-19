using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public static int score;   //スコア
    private Vector3 lastvelocity;
    private Rigidbody rb;

    private int re = 0;
    private int minute;
    private float second;

    public Text ResultCoin;
    public Text ResultTime;

    public Text CountText;  //スコアテキスト
    public Text ClearText;  //クリアテキスト
    public GameObject Item; //アイテム

    //エフェクト
    public ParticleSystem explode;
    public ParticleSystem explode1;

    [SerializeField] GameObject ResultPanel;
    [SerializeField] GameObject ReTryPanel;

    public ParticleSystem confech;

    //SE
    public AudioSource Roll_Ball;
    public AudioSource CursorCheck;

    //カウントダウン
    float countdown = 4.0f;
    int count;

    //アイテムを大きくする時間制限
    public bool hasBigBall;

    void Start()
    {
        score = 0;
        ClearText.text = "";
        rb = GetComponent<Rigidbody>();

        minute = 0;
        second = 0f;

        confech.enableEmission = false;
        ResultPanel.SetActive(false);
        ReTryPanel.SetActive(false);
    }

    void Update()
    {
        //カウントダウン
        SetCountText();
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        else
        {
            second += Time.deltaTime;
            if (second >= 60f)
            {
                minute++;
                second = second - 60;
            }
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

    void SetCountText()
    {
        CountText.text = score.ToString() + " / 12";

        //すべての収集アイテムを獲得した場合
        if (score == 12)
        {
            Time.timeScale = 0f;
            Application.targetFrameRate = 60;
            Debug.Log("クリアテキストのFPS：" + Application.targetFrameRate);
            confech.enableEmission = true;
            ClearText.text = "GAME CLEAR";
            if (re == 0)
            {
                re += 1;
                StartCoroutine(ResultSet());
            }
            if (Input.GetKeyDown("joystick button 1"))
            {
                //音(CursorCheck)を鳴らす
                CursorCheck.Play();

                ResultPanel.SetActive(false);
                StopCoroutine(ResultSet());
                ReTryPanel.SetActive(true);
            }
        }
    }

    private IEnumerator ResultSet()
    {

        ResultCoin.text = "取得したコイン　" + score.ToString() + "枚";
        ResultTime.text = "かかった時間　" + minute.ToString() + ":" + second.ToString("00");
        //2秒間待つ
        yield return new WaitForSecondsRealtime(2);

        ResultPanel.SetActive(true);
    }

    private IEnumerator SpeedupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasBigBall = false;
    }
}