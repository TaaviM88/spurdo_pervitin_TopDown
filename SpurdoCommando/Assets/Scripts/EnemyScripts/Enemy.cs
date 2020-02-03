using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage<float>, IDie
{
    public float hitpoints = 2;
    public float timeToLive = 10f;
    public Rigidbody2D _rb2d;
    // Start is called before the first frame update
    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        //Invoke("Die", timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGamePaused())
        {
            return;
        }

        timeToLive -= Time.deltaTime;

        if(timeToLive < 0)
        {
            Die();
        }
    }

    public void Damage(float damageTaken)
    {
        hitpoints = Mathf.Min(hitpoints - damageTaken, hitpoints);

        if(hitpoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
