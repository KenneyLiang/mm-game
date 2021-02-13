using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : BaseBoost
{
    [SerializeField] private Rigidbody2D _rb;

    private float _originalY;
    private float _verticality;

    void Start()
    {
        _rb.velocity = new Vector2(Random.Range(-7.5f, -2.5f), 0);

        _originalY = transform.position.y;
        _verticality = Random.Range(1f, 3f);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            _originalY + _verticality * Mathf.Sin(Time.time * 2.5f),
            transform.position.z
        );

        if (transform.position.x < -15) Destroy(gameObject);
    }

    public override void PickUp() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        Player p = player.GetComponent<Player>();
        // Make player invincible
        Debug.Log("invincible!");
    }
}
