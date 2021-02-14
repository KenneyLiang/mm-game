using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public float Speed; 
    public float startX; 
    public float endX;

    private void Start() {
        
    }
   
    private void FixedUpdate() {
       transform.Translate(Vector2.left * Speed * Time.deltaTime );

       if (transform.position.x <= endX){
           Vector2 pos =new Vector2(startX, transform.position.y);
           transform.position = pos;
       }
    }
}
