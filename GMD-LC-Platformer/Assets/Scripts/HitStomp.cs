using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStomp : MonoBehaviour
{
   // public float bounce;
    //public Rigidbody2D rb2D;
    public bool  isStomped = false;
    public bool _isStomped => isStomped; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        isStomped = true; 
        if ( isStomped = true && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            isStomped = true;
            //Debug.Log(isStomped); 
            //rb2D.velocity = new Vector2(rb2D.velocity.x, bounce); 
        }
    }
}
