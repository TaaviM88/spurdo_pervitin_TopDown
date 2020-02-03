using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float firerate;
    public float range;
    public float clip;
    public GameObject bullet;
    

    public string GetWeaponName()
    {
        return weaponName;
    }
    public GameObject GetBullet()
    {
        return bullet;
    }
    public float GetDamage()
    {
        return damage;
    }
    public float  GetFirerate()
    {
        return firerate;
    }
    public float GetClip()
    {
        return clip;
    }

    public float GetRange()
    {
        return range;
    }
}
