using UnityEngine;
using System.Collections;


public class ShootingEnemy : BaseEnemy {
    
    private enum EnemyState {Moving, Attacking, Retreating}; 
    private EnemyState enemyState; 

    public Transform projectileSpawner; 
    private bool stopping = false;

    public GameObject bulletGameObject; 
    [Range(0,2)]
    public float reloadTime;
    private float timeTilFire = 0; 
    private short shotCounter = 0;

    private float curSpeed; 
    // private BaseHealth health;
    // private Explode explode;
    [SerializeField] private AudioClip _basicShot;
    [SerializeField] private AudioSource _audio;


    public override void Start() {
        base.Start();
        Debug.Log("Start Shooting" + gameObject.name);
        StartCoroutine("SlowDown");
        health = GetComponent<BaseHealth>();
        explode = GetComponent<Explode>();
    }

    public override void FixedUpdate()
    {
        if (health.currentHealth <= 0)
        {
            explode.OnExplode();
        }

        Vector2 screenpos = Camera.main.WorldToScreenPoint(rb2.position);
        bool canShoot = false;

        //Set the create Slowdown here 
        if (stopping){
            canShoot = true;
            if (Mathf.Abs(rb2.velocity.x) < 0.2 ){
                rb2.velocity = new Vector2(0, rb2.velocity.y);
            }
            if (Mathf.Abs(rb2.velocity.y) < 0.1){
                rb2.velocity = new Vector2(rb2.velocity.x, 0);
            }

            rb2.velocity *= 0.95f;
        }else{
            //Regular Motion
            float verticalVel = Mathf.Sin(Time.fixedTime) * vertical * verticalMult;
            rb2.velocity = new Vector2(-maxSpeed * speedMultiplier, verticalVel);
        }

           //Set Shoot Trigger
        if (rb2.velocity == new Vector2(0,0) && canShoot && shotCounter < 3){
            //Start Shooting Coroutine
            if (timeTilFire < 0){
                shootProjectiles();
                timeTilFire = reloadTime;
                shotCounter ++; 
            }
            timeTilFire -= Time.deltaTime;

        }

        if (shotCounter >= 3){
            //Retreat
            curSpeed += maxSpeed * 0.05f;
            if (curSpeed > maxSpeed)
                curSpeed = maxSpeed;
            rb2.velocity = new Vector2(curSpeed * speedMultiplier, 0);
            if (screenpos.x >  Screen.width + 30){
                Destroy(gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "PlayerBullet")
        {
            health.takeDamage(40);
            Destroy(target.gameObject);
        }
    }

    IEnumerator SlowDown(){
        yield return new WaitForSeconds(1f);
        stopping = true; 
    }   


    private void shootProjectiles(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Transform playerLoc = player.transform;

        //Play sound
        _audio.PlayOneShot(_basicShot,0.2f);

        Vector2 shotDir = (playerLoc.position - this.transform.position).normalized; 
        GameObject bullet = Instantiate(bulletGameObject, projectileSpawner.transform.position, Quaternion.identity);
        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        enemyBullet.setBulletDir(shotDir);
    }

    
}