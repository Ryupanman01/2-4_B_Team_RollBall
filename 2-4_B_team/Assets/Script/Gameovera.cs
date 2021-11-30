using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Gameovera : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GameOver")
        {
            //Destroy(this.gameObject);
            //gameOverText.text = "GameOver";
            this.transform.position = new Vector3(0, 1.3f, 0);

            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            //StartCoroutine(stop());
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            rb.velocity = Vector3.zero;
        }
    }
    private IEnumerator stop()
    {
        //2秒間待つ
        yield return new WaitForSecondsRealtime(2);

        rb.isKinematic = false;
    }
}