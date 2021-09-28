using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.BroadcastMessage("HealthPickup");
            Destroy(gameObject, 0.05f);
            GameObject.Find("PickUp").GetComponent<AudioSource>().Play();
        } 
    }
}
