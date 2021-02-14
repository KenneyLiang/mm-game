using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float increaseSpeedBy = 5f;
    public float maxSpeed = 5f;

    public float maxRotation = 0.05f;
    public float rotateBy = 0.25f;
    public BaseHealth health;

    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private Animator animator;
    private PlayerSubmarineController controller;
    // private Transform transform;

    private bool _isInvincible = false;
    private IEnumerator _inv;
    [SerializeField] SpriteRenderer _shield;

    private int[] _gunCharges = { 0, 0, 0 };
    private Explode explode;

    [SerializeField] private GameObject _death;
    public GameOver gameOverScreen;
    public GameOverMusic gameOverMusic;
    public GameManager gameManager;


    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerSubmarineController>();
        health = GetComponent<BaseHealth>();
        explode = GetComponent<Explode>();
    }

    void Update()
    {
        if (health.currentHealth <= 0)
        {
            Instantiate(_death, transform.position, Quaternion.identity);       
            explode.OnExplode();

            gameOverScreen.SetUp(gameManager.getScore(), gameManager.getHighScore());
            gameOverMusic.SetUp();
        }
        // current vertical velocity
        var velY = body2D.velocity.y;
        var rotation = transform.rotation.z;

        // If the move button is pressed, apply force upwards
        if(controller.moving.y > 0){
            if (velY < maxSpeed){
                body2D.AddForce(new Vector2(0, increaseSpeedBy));
            }

            if (rotation <= maxRotation){
                transform.Rotate(Vector3.forward * rotateBy);
            }
            else{
                transform.Rotate(Vector3.back * rotateBy);
            }
        }
        else{
            if (rotation >= -maxRotation){
                transform.Rotate(Vector3.back * rotateBy);
            }
            else{
                transform.Rotate(Vector3.forward * rotateBy);
            }
        }

        if (_isInvincible) {
            _shield.enabled = true;
        } else {
            _shield.enabled = false;
        }
    }

    public int GetGunTimer(int gunIndex) {
        if (gunIndex >= _gunCharges.Length) return 0;

        return _gunCharges[gunIndex];
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "EnemyProjectile" && !_isInvincible){
            health.takeDamage(20);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!_isInvincible) {
            if(other.gameObject.tag == "Enemy"){
                health.takeDamage(25);
                // destroy enemy too
                GameObject enemy = other.gameObject;
                Explode boom = enemy.GetComponent<Explode>();
                boom.OnExplode();            
            }
            
            if(other.gameObject.tag == "EnemyProjectile"){
                health.takeDamage(15);
            }
        }
    }

    public void MakeInvincible()
    {
        if (!_isInvincible) {
            _inv = Invincibility();
            StartCoroutine(_inv);
        } else {
            StopCoroutine(_inv);

            _inv = Invincibility();
            StartCoroutine(_inv);
        }
    }

    IEnumerator Invincibility() 
    {
        _isInvincible = true;

        yield return new WaitForSeconds(15);

        _isInvincible = false;
    }

    public void PickupGun(int gunIndex) {
        if (gunIndex >= _gunCharges.Length) return;

        StartCoroutine(Gun(gunIndex));
    }

    IEnumerator Gun(int i) {
        _gunCharges[i]++;

        yield return new WaitForSeconds(15);

        _gunCharges[i] = (_gunCharges[i] - 1 < 0) ? 0 : _gunCharges[i] -1;
    }
}
