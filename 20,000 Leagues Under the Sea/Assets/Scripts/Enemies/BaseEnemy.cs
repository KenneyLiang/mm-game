using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Public vars
    public float maxSpeed; 
    public float attackDamage;
    public Rigidbody2D rb2; 
    

    //TODO mess around with these values 
    [Range(0.5f, 1.5f)]    
    public float speedMultiplier; 
    [Range(0.5f, 2.0f)]
    public float verticalMult;


    // Private vars
    public int vertical = 0;    

    private enum MovementType {Straight, Wave};
    private MovementType movementType; 
    private BaseHealth health;
    private Explode explode;

    // Use to instantiate the class vars and other properties
    private void init(){
        // Set vel based on movement type 
        rb2 = GetComponent<Rigidbody2D>();
        rb2.gravityScale = 0; 
        health = GetComponent<BaseHealth>();
        explode = GetComponent<Explode>();
    }

    // Start is called before the first frame update
    public virtual void Start(){
        init();     
    }

    // Update is called once per frame
    public virtual void FixedUpdate(){
        if (health.currentHealth <= 0)
        {
            explode.OnExplode();
        }

        float verticalVel = Mathf.Sin(Time.fixedTime) * vertical * verticalMult;
        rb2.velocity = new Vector2(-maxSpeed * speedMultiplier, verticalVel);

        //Destoy enemies if they are offscreen
        Vector2 screenpos = Camera.main.WorldToScreenPoint(rb2.position);
        if (screenpos.x < -15f ){
            Destroy(gameObject);
        }
    }
    
    public void setMovementType(bool wave){
        movementType = wave ? MovementType.Wave : MovementType.Straight; 
        vertical = movementType == MovementType.Wave ? 1 : 0;
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "PlayerBullet")
        {
            health.takeDamage(40);
            Destroy(target.gameObject);
        }
    }



}
