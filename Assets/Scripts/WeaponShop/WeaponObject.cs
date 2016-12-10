using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponObject : ScriptableObject
{
    public string WeaponName = "Weapon Name Here";
    public int Cost = 50;
    public string Description;
    public float FireRate = 0.5f;
    public int Damage = 10;
    public float Range = 100;
}
