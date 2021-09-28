using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {        
        if (other.CompareTag("Player")) {            
            other.BroadcastMessage("PlayerApplyDamage");
            BroadcastMessage("FireballSelfDestruct", SendMessageOptions.DontRequireReceiver);
        }

        if (other.CompareTag("PlayerMissile")) {            
            // Don't destroy player missile if this object is an enemy missile
            if (!gameObject.CompareTag("EnemyMissile"))
                other.BroadcastMessage("SelfDestruct");            

            BroadcastMessage("EnemyApplyDamage", SendMessageOptions.DontRequireReceiver);            
        }
    }
}
