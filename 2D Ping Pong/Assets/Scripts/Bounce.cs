using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float bounceStrength;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ball = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 normal = other.GetContact(0).normal;

            ball.AddForce(-normal * bounceStrength);
        }
    }
}
