using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrap : MonoBehaviour
{
    public GameObject effectPrefab;
    private UnityStandardAssets.Vehicles.Ball.Ball ball;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ポイント
            // Ballの動きを司るスクリプトをオフにする。
            ball = collision.gameObject.GetComponent<UnityStandardAssets.Vehicles.Ball.Ball>();

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 2.0f);

            // ポイント
            // ２秒後にボールが動けるようにする。
            Invoke("StopOff", 2.0f);
        }
    }

    void StopOff()
    {
        // ポイント
        // Ballの動きを司るスクリプトをオンにする。
    }
}