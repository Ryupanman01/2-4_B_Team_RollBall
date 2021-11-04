using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColParticle : MonoBehaviour
{
    // Start is called before the first frame update

    //変数の定義
    private ParticleSystem particle;

    void Start()
    {
        //Particleシステムの取得（子オブジェクトから）
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //衝突が発生した場合に実行される
    void OnCollisionEnter(Collision other)
    {
        //衝突対象がPlayer(Ethan)の場合にparticleをPlayする
        if (other.gameObject.tag == "Player")
        {
            particle.transform.position = other.transform.position;
            particle.Play();
            //衝突位置
        }
    }
}
