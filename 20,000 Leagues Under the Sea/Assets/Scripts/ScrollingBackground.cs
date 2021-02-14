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
           Vector3 pos = new Vector3(startX, transform.position.y, transform.position.z);
           transform.position = pos;
       }
    }
}
