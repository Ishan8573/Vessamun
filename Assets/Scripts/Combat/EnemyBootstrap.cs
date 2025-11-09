using UnityEngine;

[RequireComponent(typeof(EnemySpawn))]
public class BattleBootstrap : MonoBehaviour
{
    void Start()
    {
        var gen = GetComponent<EnemySpawn>();
        gen.Generate();
    }
}

