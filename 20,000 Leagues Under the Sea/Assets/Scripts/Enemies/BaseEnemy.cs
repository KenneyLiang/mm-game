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
    private float curHealth;
    private int vertical = 0 ; 
    private float curSpeed; 
    


    private enum MovementType {Straight, Wave};
    private MovementType movementType; 

    // Start is called before the first frame update
    void Start()
    {
        init();     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalVel = Mathf.Sin(Time.fixedTime) * vertical * verticalMult;
        rb2.velocity = new Vector2(-curSpeed * speedMultiplier, verticalVel);
        

        //Destoy enemies if they are offscreen
        Vector2 screenpos = Camera.main.WorldToScreenPoint(rb2.position);
        if (screenpos.x < -15f ){
            Destroy(gameObject);
        }
    }

    // Use to instantiate the class vars and other properties
    private void init(){
        // Set vel based on movement type 
        curSpeed = maxSpeed; 
        rb2 = GetComponent<Rigidbody2D>();
        rb2.gravityScale = 0; 
    }

    
    public void setMovementType(bool wave){
        movementType = wave ? MovementType.Wave : MovementType.Straight; 
        vertical = movementType == MovementType.Wave ? 1 : 0;
    }
}
