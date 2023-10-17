using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    public Vector2 forMove = Vector2.left;

    void Start() 
    {
        Destroy(gameObject, 7);    
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(forMove * moveSpeed * Time.deltaTime);
    }

}
