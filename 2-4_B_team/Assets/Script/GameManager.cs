using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //カウントダウン変数
    private float countdown;
    private int count;

    //ゲームBGM管理変数
    private bool bgm_flg;

    //時間管理変数
    private int minute;
    private float second;

    private int re = 0;

    //クリア時紙吹雪エフェクト
    public ParticleSystem confech;

    //ポーズ画面
    private int pause;
    private int MenuSelect = 0;

    //テキスト管理
    public Text ResultCoin;                     //クリアコイン
    public Text ResultTime;                     //クリアタイム
    public Text CountText;                      //コインカウント
    public Text CountDownText;                  //カウントダウンテキスト
    [SerializeField] GameObject StartText;      //スタートテキスト
    [SerializeField] GameObject ClearText;      //クリアテキスト
    [SerializeField] GameObject ResultPanel;    //リザルト画面
    [SerializeField] GameObject ReTryPanel;     //リトライメニュー画面
    [SerializeField] GameObject PausePanel;     //ポーズ画面

    //SE管理
    public AudioSource GameBGM;
    public AudioSource Game_Clear;
    public AudioSource CursorCheck;

    public bool flg = false;

    private void Start()
    {
        InitGame();
    }

    void Update()
    {
        CountDown();
        Pause();
        GameClear();

    }

    //ゲーム初期化
    void InitGame()
    {
        bgm_flg = false;
        PlayerController.score = 0;
        second = 0f;
        minute = 0;
        countdown = 4.0f;
        pause = 0;

        confech.enableEmission = false;
        PausePanel.SetActive(false);
        ClearText.SetActive(false);
        ResultPanel.SetActive(false);
        ReTryPanel.SetActive(false);
    }

    //ゲームクリア
    void GameClear()
    {
        CountText.text = PlayerController.score.ToString() + " / 12";
        //すべてのコインを獲得した場合
        if (PlayerController.score == 12)
        {
            GameBGM.Stop();
            Time.timeScale = 0f;
            confech.enableEmission = true;
            ClearText.SetActive(true);
            Application.targetFrameRate = 60;
            Debug.Log("クリアテキストのFPS：" + Application.targetFrameRate);
            if (re == 0)
            {
                Game_Clear.Play();
                re += 1;
                StartCoroutine(ResultSet());
            }
            if (Input.GetKeyDown("joystick button 1") && flg == true)
            {
                //音(CursorCheck)を鳴らす
                CursorCheck.Play();
                ResultPanel.SetActive(false);
                //StopCoroutine(ResultSet());
                ReTryPanel.SetActive(true);
            }
        }
    }

    //カウントダウン
    void CountDown()
    {
        //1秒以上なら
        if (countdown >= 1.0f)
        {
            Application.targetFrameRate = 60;   //60Fpsにする
            Debug.Log("カウントダウンのFPS：" + Application.targetFrameRate);

            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountDownText.text = count.ToString();
            StartText.SetActive(false);      //スタートテキストを非表示にする
        }
        //1秒より少ないなら
        if (countdown < 1.0f && countdown > 0f)
        {
            Application.targetFrameRate = 30;   //30Fpsにする
            Debug.Log("スタートのFPS：" + Application.targetFrameRate);
            countdown -= Time.deltaTime;    //1秒ごとに1減らす
            CountDownText.enabled = false;  //カウントダウンテキストを非表示にする
            bgm_flg = true;
            StartText.SetActive(true);      //スタートテキストを表示する
        }
        //0秒よりすくないなら
        if (countdown < 0f)
        {
            StartText.SetActive(false);     //スタートテキストを非表示にする
            second += Time.deltaTime;
            if (second >= 60f)
            {
                minute++;
                second = second - 60;
            }
        }

        if(bgm_flg == true)
        {
            GameBGM.Play();
            bgm_flg = false;
        }
    }

    //ポーズ画面
    void Pause() 
    {
        if(countdown < 0) {
            if (PlayerController.score < 12)
            {
                if (Input.GetKeyDown("joystick button 7"))
                {
                    if (pause == 0)
                    {
                        PausePanel.SetActive(true);
                        GameBGM.Pause();
                        pause = 1;

                        Time.timeScale = 0f;
                    }
                    else
                    {
                        PausePanel.SetActive(false);
                        GameBGM.UnPause();
                        pause = 0;
                        Time.timeScale = 1f;
                    }
                }
                else
                {
                    ;
                }
            }
        }
    }

    //リザルト画面
    private IEnumerator ResultSet()
    {

        ResultCoin.text = "取得したコイン　" + PlayerController.score.ToString() + "枚";
        ResultTime.text = "かかった時間　" + minute.ToString() + ":" + second.ToString("00");
        //2秒間待つ
        yield return new WaitForSecondsRealtime(2);

        ResultPanel.SetActive(true);
        flg = true;
    }
}

