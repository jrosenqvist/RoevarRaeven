using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.BroadcastMessage("PlayerDeath");
        }
        if (other.CompareTag("Enemy")) {
            Destroy(other, 0);
        }
    }
}
