using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Create new Weapon Data (SO)")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public int damage;
    public enum Dice {
        d4,
        d6,
        d8,
        d10,
        d12,
        d20,
    }
    
}

