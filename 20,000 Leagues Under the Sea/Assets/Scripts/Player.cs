using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerSubmarineController>();
        health = GetComponent<BaseHealth>();
        // transform = GetComponent<Transform>();
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
    }
}
