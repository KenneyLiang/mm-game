using UnityEngine;

public class HomingEnemy : BaseEnemy {
    
    private GameObject playerTarget; 

    public override void Start() {
        base.Start();
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}