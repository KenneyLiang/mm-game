using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomingEnemy : BaseEnemy {
    
    private GameObject playerTarget; 
    private bool stopping = false;

    private bool canLock = false;
    private bool initLock = false; 
    private bool hasLocked = false;
    private float curSpeed = 0f;
    // private BaseHealth health;
    // private Explode explode;

    public float acc; 

    public GameObject lockOn; 

    public override void Start() {
        base.Start();

        playerTarget = GameObject.FindGameObjectWithTag("Player");
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

        if (stopping){
            canLock = true; 
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

        if (rb2.velocity == new Vector2(0,0) && canLock &&!initLock){
            //Lock on to player and chase
            initLock = true; 
            StartCoroutine("LockOn");
            if (hasLocked){
                Debug.Log("Target Locked");
            }
            canLock = false; 
        }

        if (hasLocked){
            curSpeed += acc; 

            Vector2 flyDir = (playerTarget.transform.position - this.transform.position).normalized; 
            rb2.velocity = new Vector2(curSpeed * flyDir.x, curSpeed * flyDir.y); 
            
        }


    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "PlayerBullet")
        {
            health.takeDamage(40);
            Destroy(target.gameObject);
        }
    }


    IEnumerator LockOn(){
        float xOffset = Random.Range(-0.2f, 0.2f);
        float yOffset = Random.Range(-0.2f, 0.2f);
        GameObject lockOnClone = Instantiate(lockOn, 
                    new Vector2(playerTarget.transform.position.x + xOffset, playerTarget.transform.position.y + yOffset ), 
                    Quaternion.identity);        

        LockOn lockon = lockOnClone.GetComponent<LockOn>();
        lockon.setOffset(xOffset,yOffset);


        yield return new WaitForSeconds(0.4f);
        hasLocked = true; 
    }

    IEnumerator SlowDown(){
        yield return new WaitForSeconds(1f);
        stopping = true; 
    }   

}