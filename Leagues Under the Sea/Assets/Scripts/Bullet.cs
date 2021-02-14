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

    [SerializeField] private GameObject _particles;

    private void OnDestroy() {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        rb.velocity = transform.right * speed;
    }

    void FixedUpdate()
    {
        if (Time.time - startTime > duration){
            Destroy(this.gameObject);
        }
    }

    // private void onTriggerEnter2D(Collider2D hitInfo)
    // {
    //     Debug.Log(hitInfo.name);
    //     Destroy(this.gameObject);
    // }

}
