using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float bulletVel; 
    public Rigidbody2D rb2; 
    
    private Vector2 bulletDir;
    private float bulletTTL; 

    // Start is called before the first frame update
    void Start()
    {
        bulletTTL = 1000f;
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb2.velocity = bulletDir * bulletVel;

        //Destory bullet after some time
        if (bulletTTL < 0){
            Destroy(gameObject);
        }
        
        bulletTTL -= Time.deltaTime; 
    }


    public void setBulletDir(Vector2 dir){
        bulletDir = dir;
    }
}
