using UnityEngine;
using System.Collections;


public class ShootingEnemy : BaseEnemy {
    
    private enum EnemyState {Moving, Attacking, Retreating}; 
    private EnemyState enemyState; 

    public Transform projectileSpawner; 
    private bool stopping = false;

    public GameObject bulletGameObject; 

    public override void Start() {
        base.Start();
        Debug.Log("Start Shooting" + gameObject.name);
        StartCoroutine("SlowDown");

    }

    public override void FixedUpdate()
    {
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
        if (rb2.velocity == new Vector2(0,0) && canShoot){
            //Start Shooting Coroutine
            
            shootProjectiles();
        }

    }

    IEnumerator SlowDown(){
        yield return new WaitForSeconds(1f);
        stopping = true; 
    }   


    private void shootProjectiles(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Transform playerLoc = player.transform;

        Vector2 shotDir = (playerLoc.position - this.transform.position).normalized; 
        GameObject bullet = Instantiate(bulletGameObject, projectileSpawner.transform.position, Quaternion.identity);
        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        enemyBullet.setBulletDir(shotDir);
    }
    
}