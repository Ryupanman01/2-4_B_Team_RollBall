using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    private Vector3 lastvelocity;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.lastvelocity = this.rb.velocity;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastvelocity, other.contacts[0].normal);
            this.rb.velocity = refrectVec;
        }
    }
}