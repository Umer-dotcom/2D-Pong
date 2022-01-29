using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    [SerializeField] bool player1;
    [SerializeField] bool player2;
    [SerializeField] float moveSpeed;
    [SerializeField] float upLimit;
    [SerializeField] float downLimit;
    private Vector2 newPos;

    void Update()
    {
        newPos = GetComponent<Transform>().position;
        if(player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                newPos.y += moveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                newPos.y -= moveSpeed;
            }
        }
        
        if(player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                newPos.y += moveSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                newPos.y -= moveSpeed;
            }
        }

        if(newPos.y > upLimit)
        {
            newPos.y = upLimit;
        }
        if(newPos.y < downLimit)
        {
            newPos.y = downLimit;
        }

        GetComponent<Transform>().position = newPos;
    }
}
