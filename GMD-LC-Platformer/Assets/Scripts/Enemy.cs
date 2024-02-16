using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage; 
    public PlayerHealth playerHealth;
    public bool _isStomped; 

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(_isStomped);
        //_isStomped = true;  
        if (_isStomped == false && other.gameObject.tag == "Player")
        {
                playerHealth.TakeDamage(damage);         
        }
        
    }
}
