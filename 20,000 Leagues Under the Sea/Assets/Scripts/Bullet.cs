using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    bool hasHit;
    float startTime;
    float duration = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if (Time.time - startTime > duration)
        {
            Destroy(this.gameObject);
        }

        
    }


    private void onTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(this.gameObject);

    }

}
