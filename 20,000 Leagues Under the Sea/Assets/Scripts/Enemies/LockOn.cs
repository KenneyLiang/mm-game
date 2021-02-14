using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    private float TTL = 1f;
    private GameObject player; 

    private float[] offsets = {0,0};

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.localScale = new Vector2(5f,5f);
    }

    // TODO play lockon sound 


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position,
                     new Vector2(player.transform.position.x + offsets[0], player.transform.position.y + offsets[1]),
                    0.75f);

        transform.localScale *= 0.99f;
        if(TTL > 0){
            TTL -= Time.deltaTime;

        }else{
            

            Destroy(gameObject);
        }
    }

    public void setOffset(float x, float y){
        offsets[0] = x;
        offsets[1] = y; 
    }
}
