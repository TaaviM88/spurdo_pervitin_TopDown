using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D _rb2D;
    public Animator anime;
    Vector2 movement, lastDir;
    float padding = 1f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Shooting shoot;
    PlayerManager player;
    Quaternion target;
    // Start is called before the first frame update
    void Start()
    {
       // SetUpBoundaries();
        _rb2D = GetComponent<Rigidbody2D>();
        shoot = GetComponent<Shooting>();
        player = GetComponent<PlayerManager>();
        //anime = GetComponent<Animator>();
    }


    private void Update()
    {   
        if(PauseMovements())
        {
            return;
        }
        
        if(player.playerIsAlive)
        {
            if(Input.GetButton("Fire1"))
            {
                if (!Input.GetButton("Fire2"))
                {
                    FireWeapon(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
                   
                }
                else
                {

                    FireWeapon(lastDir);
                }
                   
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PauseMovements())
        {
            return;
        }

        if (player.playerIsAlive)
        {
            move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        
        
    }

    private void move(float v1, float v2)
    {
        movement.x = v1;
        movement.y = v2;
        target = Quaternion.Euler(0, 0, -v1 * 90);
        _rb2D.MovePosition(_rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(!Input.GetButton("Fire2"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * moveSpeed);
        }
       

    }

    public void FireWeapon(Vector2 d)
    {
       shoot.FireWeapon(d);
        lastDir = d;
    }

    public bool PauseMovements()
    {
        if(GameManager.Instance.IsGamePaused() || !PlayerManager.Instance.playerIsAlive)
        {
            _rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            return true;
        }
        else
        {
            _rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            return false;
        }
    }
   /* public void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }*/
}
