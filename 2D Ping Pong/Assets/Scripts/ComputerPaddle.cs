using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    [SerializeField] Rigidbody2D ball;
    [SerializeField] float moveSpeed;
    [SerializeField] float upLimit;
    [SerializeField] float downLimit;

    [Range(0f, 6f)]
    [SerializeField] float offset;
    [SerializeField] float moveOffset;

    private Vector2 newPos;
    void Update()
    {
        if (!ball)
        {
            Debug.Log("Ball to be tracked not found!");
            Debug.Log("Finding Gameobject with tag = Ball");
            ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        }
        else
        {
            newPos = GetComponent<Transform>().position;
            //If ball is moving towards the paddle and ball is halfway accrossed then move
            if(ball.velocity.x > 0 && ball.GetComponent<Transform>().position.x > offset)
            {
                //Track the position of ball and move accordingly
                if(ball.position.y > newPos.y)
                {
                    newPos.y += (moveSpeed - moveOffset);
                }
                if(ball.position.y < newPos.y)
                {
                    newPos.y -= (moveSpeed - moveOffset);
                }
            }
            
            //Don't let ball cross the border
            if (newPos.y > upLimit)
            {
                newPos.y = upLimit;
            }
            if (newPos.y < downLimit)
            {
                newPos.y = downLimit;
            }

            this.GetComponent<Transform>().position = newPos;   //Set it's new position
        }
        //Debug.Log("Ball Velocity (x, y) ==> (" + ball.velocity.x + ", " + ball.velocity.y + ")");
    }
}
