using UnityEngine;

public class EnemyManager : MonoBehaviour {
    
    private enum MovementType {Straight, Wave};
    private MovementType movementType; 
    
    public GameObject[] enemies; 

    [Range(1,15)]
    public float spawnDelay; 
    private float timeUntilSpawn = 0;
    //Spawn Patters      
    private  int[][,] spawnPatterns = {
        new int [,] {{1,1,1}, {1,1,1}, {1,1,1}}, //Box
        new int [,] {{0,0,0}, {1,1,1}, {0,0,0}}, //H Line
        new int [,] {{0,1,0}, {0,1,0}, {0,1,0}}, //V Line
        new int [,] {{1,0,1}, {0,1,0}, {1,0,1}}  //Cross
                                    }; 


    private void Start() {
        
    }

    private void FixedUpdate() {
        timeUntilSpawn -= Time.deltaTime; 
        if (timeUntilSpawn <= 0){
            //Spawn stuff here
            //Choose formation
            int formation = Random.Range(0, 4); 
            //Choose enemy to spawn
            int enemy = Random.Range(0, enemies.Length);

            //randomize movement
            bool wave  = (Random.value > 0.5f);
            movementType = wave ? MovementType.Wave : MovementType.Straight;

            SpawnEnemies(spawnPatterns[formation], enemy, movementType);
            timeUntilSpawn = spawnDelay; 
        }
    }

    private void SpawnEnemies(int[,] formation, int enemy, MovementType movement){
        float spawnYLoc = Random.Range(3, 7); 
        float offset = 1f;

        bool wave = movement == MovementType.Wave; 

        for (int i = 0; i < 3; i ++){
            for (int j =0; j < 3; j++){
                //Instantiate objects 
                if (formation[i,j] == 1){
                    GameObject clone =  Instantiate(enemies[enemy],
                            new Vector2(transform.position.x + (j * offset), transform.position.y + spawnYLoc + (i * offset)), 
                            Quaternion.identity
                            );
                    BaseEnemy comp = clone.GetComponent<BaseEnemy>();
                    comp.setMovementType(wave);
                }
            }
        }
    }


}
