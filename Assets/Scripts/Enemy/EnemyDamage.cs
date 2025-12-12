using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Vector3 hitDirection = other.transform.position - transform.position;

          
            other.GetComponent<PlayerHeallth>()?.TakeDamage(damageAmount, hitDirection);
        }
    }
}
