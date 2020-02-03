using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public GameObject bullet;
    public GameObject currentSubWeapon;
    GameObject basicSubWeapon;
    public Weapon currentWeapon;
    Weapon basicWeapon;
    public GameObject bulletStartPoint;
    bool canFire = true, canFireSubweapon =true;

    public void Start()
    {
        basicWeapon = currentWeapon;
        basicSubWeapon = currentSubWeapon;
    }

    public void FireWeapon(Vector2 d)
    {
        if(canFire)
        {
            GameObject bullet = Instantiate(currentWeapon.GetBullet(), bulletStartPoint.transform.position,Quaternion.Euler(0,0,0));
            bullet.GetComponent<Bullet>().UpdateBulletDamageAndFadeTimeAndDirection(currentWeapon.damage, currentWeapon.range,d);
            canFire = false;
            StartCoroutine(MainWeaponCooldown(currentWeapon.GetFirerate()));
        }
       
    }

    public void FireSubWeapon()
    {
        if(canFireSubweapon)
        {
            Instantiate(currentSubWeapon, bulletStartPoint.transform.position, Quaternion.identity);
            canFireSubweapon = false;
            //Add subweapon cooldown later
            StartCoroutine(SubWeaponCooldown(1));
        }
    }

    IEnumerator MainWeaponCooldown(float t)
    {

        yield return new WaitForSeconds(t);
        canFire = true;
    }

    IEnumerator SubWeaponCooldown(float t)
    {

        yield return new WaitForSeconds(t);
        canFireSubweapon = true;
    }

    //päivitetään uuteen aseseen
    public void UpdateWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
    }
    public void UpdateSubweapon(GameObject newSubWeapon)
    {
        currentSubWeapon = newSubWeapon;
    }
    //palautetaan ensimmäiseen aseeseen
    public void RollBackBasicWeapon()
    {
        currentWeapon = basicWeapon;
    }

    public void RollBackBasicSubweapon()
    {
        currentSubWeapon = basicSubWeapon;
    }
}
