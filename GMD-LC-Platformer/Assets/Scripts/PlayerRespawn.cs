using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    public GameOverScreen GameOverScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {   
         if (other.gameObject.CompareTag("Hazard"))
        {
            
            PlayerHealth.health--;
            transform.position = respawn.transform.position;
            if (PlayerHealth.health <= 0 )
            {
                
               
                    GameOverScreen.Setup();
                
            }
        }
         
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawn = other.transform;
        }
    
    }
}
