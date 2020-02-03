using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ITakeDamage<float>, IDie
{
    public static PlayerManager Instance;
    public float hitPoints = 1;
    public bool playerIsAlive = true;
    Vector3 startPoint;
    public ShaderController shader;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        startPoint = transform.position;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPlayerPosition()
    {
        return gameObject.transform.position;
    }
    
    public void Damage(float damageTaken)
    {
        hitPoints = Mathf.Min(hitPoints - damageTaken, hitPoints);

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player is död");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ToStart")
        {
            transform.position = startPoint;
        }
    }
}
