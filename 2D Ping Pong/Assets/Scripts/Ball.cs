using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] GameManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        Debug.Log("Ball Velocity (x, y) ==> (" + this.GetComponent<Rigidbody2D>().velocity.x + ", " + 
            this.GetComponent<Rigidbody2D>().velocity.y + ")");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(manager)
        {
            if (other.gameObject.CompareTag("LeftGoal"))
            {
                Debug.Log("Player 2 scores!");
                Scored();
                manager.AddPoints("P2");
            }
            if (other.gameObject.CompareTag("RightGoal"))
            {
                Debug.Log("Player 1 scores!");
                Scored();
                manager.AddPoints("P1");
            }
        }
    }

    private void Scored()
    {
        GameObject obj = Instantiate(particles, transform.position, Quaternion.identity);   //Play Explosion
        Destroy(obj, 5);

        this.gameObject.SetActive(false);   //Disable or Hide the ball
    }
}
