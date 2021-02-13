using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Public vars
    public float maxSpeed; 
    public float speedMultiplier; 
    public float attackDamage;
    public Rigidbody2D rb2; 



    // Private vars
    private float curHealth;
    private enum MovementType {Straight, Wave};
    private MovementType movementType; 
    private int vertical; 
    private float curSpeed; 
    

    // Start is called before the first frame update
    void Start()
    {
        init();     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalVel = Mathf.Sin(Time.fixedTime) * vertical * 2;
        rb2.velocity = new Vector2(-curSpeed * speedMultiplier, verticalVel);

    }

    // Use to instantiate the class vars and other properties
    private void init(){
        // Set movement type 
        bool wave = (Random.value > 0.5f);
        movementType = wave ? MovementType.Wave : MovementType.Straight; 
    
        vertical = movementType == MovementType.Wave ? 1 : 0;

        curSpeed = maxSpeed; 
        rb2 = GetComponent<Rigidbody2D>();
        rb2.gravityScale = 0; 
    }
}
