using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float cameraOffsetX, cameraOffsetY;    
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
         //= new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = new Vector3(playerPosition.x + cameraOffsetX, playerPosition.y + cameraOffsetY, -10f);
    }
}
