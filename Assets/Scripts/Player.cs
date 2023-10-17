using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 moveDirection;

    void Start() 
    {
        moveDirection = Vector2.up;    
    }

    void Update() 
    {
        Move();
        GetInput(); 
    }

    void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            moveDirection *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            moveDirection *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameManager.Instance.RestartGame();
        }

        if(other.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.IncreaseScore();
            moveSpeed *= 1.006f;
        }
    }

}
