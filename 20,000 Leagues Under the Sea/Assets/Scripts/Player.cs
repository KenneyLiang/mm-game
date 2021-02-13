using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float increaseSpeedBy = 200f;
    public float maxSpeed = 100;
    public BaseHealth health;

    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private Animator animator;
    private PlayerSubmarineController controller;



    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerSubmarineController>();
        health = GetComponent<BaseHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        // current vertical velocity
        var velY = body2D.velocity.y;

        // If the move button is pressed, apply force upwards
        if(controller.moving.y > 0){
            if (velY < maxSpeed){
                body2D.AddForce(new Vector2(0, increaseSpeedBy));
            }
        }
        else{

        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.tag == "something"){
    //         health.takeDamage(other.gameObject.someVariable);
    //         healthBar.setHealth(health.currentHealth);
    //     }
    // }

}
