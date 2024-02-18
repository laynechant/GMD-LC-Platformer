using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn; 
    private void OnTriggerEnter2D(Collider2D other)
    {   
         if (other.gameObject.CompareTag("Hazard"))
        {
            transform.position = respawn.transform.position;
        }
         
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawn = other.transform;
        }
    
    }
}
