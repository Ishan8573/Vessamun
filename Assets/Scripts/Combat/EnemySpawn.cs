using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyData enemyToSpawn;   
    public Enemy enemyPrefab;        
    public Transform spawnPoint;     

    public void Generate()
    {
        if (!enemyToSpawn || !enemyPrefab || !spawnPoint)
        {
            Debug.LogError("EncounterGenerator missing references!");
            return;
        }
        var e = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        e.Apply(enemyToSpawn);
    }
}
