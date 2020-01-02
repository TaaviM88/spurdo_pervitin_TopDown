using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D _rb2D;
    public Animator anime;
    Vector2 movement;
    [SerializeField] float padding = 1f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();
        _rb2D = GetComponent<Rigidbody2D>();
        //anime = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    private void move(float v1, float v2)
    {
        movement.x = v1;
        movement.y = v2;

        _rb2D.MovePosition(_rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    public void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
