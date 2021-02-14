using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoost : BaseBoost
{
    [SerializeField] private int _gunNumber;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _sound;

    private float _rotation;

    void Start()
    {
        _rb.velocity = new Vector2(Random.Range(-10f, -5f), 0);
        _rotation = Random.Range(-3f, 3f);
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotation);

        if (transform.position.x < -15) Destroy(gameObject);
    }

    public override void PickUp() {
        Instantiate(_sound, transform.position, Quaternion.identity);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        Player p = player.GetComponent<Player>();
        p.PickupGun(_gunNumber);
    }
}
