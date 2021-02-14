using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseBoost
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private GameObject _sound;
    [SerializeField] private GameObject _particles;

    private float _rotation;

    void Start()
    {
        _rb.velocity = new Vector2(-6, 0);
        _rotation = Random.Range(4f, 8f);
    }

    void FixedUpdate()
    {
        transform.Rotate(0, _rotation, 0);

        if (transform.position.x < -15) Destroy(gameObject);
    }

    public override void PickUp() {
        Instantiate(_sound, transform.position, Quaternion.identity);
        Instantiate(_particles, transform.position, Quaternion.identity);

        GameObject manager = GameObject.FindGameObjectWithTag("Manager");

        if (manager == null) return;

        GameManager gm = manager.GetComponent<GameManager>();
        gm.AddToScore(10);
    }
}
