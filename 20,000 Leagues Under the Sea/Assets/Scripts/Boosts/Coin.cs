using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseBoost
{
    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        _rb.velocity = new Vector2(-6, 0);
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 4, 0);

        if (transform.position.x < -15) {
            Destroy(gameObject);
        }
    }

    public override void PickUp() {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");

        if (manager == null) return;

        GameManager gm = manager.GetComponent<GameManager>();
        gm.AddToScore(10);
    }
}
