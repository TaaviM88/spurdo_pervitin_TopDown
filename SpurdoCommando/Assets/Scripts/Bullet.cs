using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public string bulletName;
    public float bulletForce;
    public int collisionLayer = 10;
    public GameObject HitEffect;
    float btimer = 0, damage;
    float fadeTime;
    Rigidbody2D rb;
    Vector2 currentVelocity;
    bool saveVelocity = true;
    Vector2 _dir;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       // rb.AddForce(new Vector2 (0,1)* bulletForce, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
       if( PauseMovements())
        {
            return;
        }

       if(btimer > 0)
        {
            btimer -= Time.deltaTime;
        }
       else
        {
            DestroyBullet();
        }

    }

    public void UpdateBulletDamageAndFadeTimeAndDirection(float dmg, float t, Vector2 dir)
    {
        btimer = t;
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        damage = dmg;
        
        if(dir == Vector2.zero)
        {
            _dir = Vector2.up;
        }
        else
        {
            _dir = dir;
        }


        rb.AddForce(_dir.normalized * bulletForce, ForceMode2D.Impulse);
        //Tuhotaan luoti x-ajan päästä. Ajan määrittää aseen range
        //Invoke("DestroyBullet", t);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.layer == collisionLayer)
        {
            //   Instantiate(HitEffect);

            collision.gameObject.GetComponent<ITakeDamage<float>>().Damage(damage);
            Destroy(gameObject);
        }
    }

    public bool PauseMovements()
    {
        if (GameManager.Instance.IsGamePaused())
        {
            if (saveVelocity)
            {
                currentVelocity = rb.velocity;
                saveVelocity = false;
            }
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            return true;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            //rb.AddForce(currentVelocity,ForceMode2D.Impulse);
            saveVelocity = true;
            return false;
        }
    }
}
