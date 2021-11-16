using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    //GameObject型の変数sphereを宣言します。
    public GameObject sphere;

    //Exploder型の変数exploderを宣言します。
    Exploder exploder;


    void Start()
    {
        //GetComponentでExploderコンポーネントにアクセスして変数exproderで参照します。
        exploder = sphere.GetComponent<Exploder>();

    }
    //SphereがPlaneと衝突したときの処理。
    private void OnCollisionEnter(Collision collision)
    {
        //もし衝突したのがPlaneだった場合、Exproderにチェックを入れて爆発させます。
        if (collision.gameObject.name == "Ball")
        {
            exploder.enabled = true;
        }
    }


}