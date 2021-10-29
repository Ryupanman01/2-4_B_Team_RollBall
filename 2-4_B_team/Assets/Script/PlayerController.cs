using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int score;   //スコア
    private Vector3 lastvelocity;
    private Rigidbody rb;

    public Text ScoreText;  //スコアテキスト
    public Text ClearText;  //クリアテキスト
    public GameObject Item; //アイテム

    void Start()
    {
        score = 0;
        ClearText.text = "";
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetCountText();
    }

    void FixedUpdate()
    {
        lastvelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        //衝突した相手にPlayerタグがついているとき
        if (collision.gameObject.CompareTag("Item"))
        {
            //その収集アイテムを非表示にする
            collision.gameObject.SetActive(false);
            //スコアを加算する
            score = score + 1;
            //ログ表示
            Debug.Log("当たった");
        }
        //衝突した相手にWallタグが付いているとき
        if (collision.gameObject.tag == "Wall")
        {
            //反射する
            Vector3 refrectVec = Vector3.Reflect(lastvelocity, collision.contacts[0].normal);
            rb.velocity = refrectVec;
        }
    }

    void SetCountText()
    {
        ScoreText.text = score.ToString() + " / 12";

        //すべての収集アイテムを獲得した場合
        if(score >= 12)
        {
            Time.timeScale = 0f;
            ClearText.text = "GAME CLEAR";
        }
    }
}
