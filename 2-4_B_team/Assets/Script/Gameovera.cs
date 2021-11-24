
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Gameovera : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GameOver")
        {
            //Destroy(this.gameObject);
            //gameOverText.text = "GameOver";
            this.transform.position = new Vector3(0, 1.3f, 0);
        }
    }
}