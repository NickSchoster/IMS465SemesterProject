using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private ColorType enemyColor;
    [SerializeField] private ColorRuleSet rules;
   // private EnemySPawner spawned;

    private void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponent<ColorBlock>();
        if (block != null && rules.CanActivate(block.blockColor, enemyColor))
        {
           // spawned.maxEnemyCount--;
            Destroy(gameObject);
        }
    }
    
}
