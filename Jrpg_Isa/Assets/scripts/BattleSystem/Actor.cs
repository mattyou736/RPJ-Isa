using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : ScriptableObject
{
    //name of actor
    public new string name;
    public int health;
    public int maxHealth;
    //money its carrying
    public int gold;
    public Vector2 attackRange = Vector2.one;

    public bool alive
    {
        get
        {
            return health > 0;
        }
    }
    //never drop below 0
    public void DecreaseHealth(int value)
    {
        health = Mathf.Max(health - value, 0);
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void IncreaseGold(int value)
    {
        gold += value;
    }
    public void DecreaseGold(int value)
    {
        gold -= value;
    }

    //cloning  actor 
    public T Clone<T>() where T : Actor
    {
        var clone = ScriptableObject.CreateInstance<T>();
        clone.name = name;
        clone.health = health;
        clone.maxHealth = maxHealth;
        clone.gold = gold;
        clone.attackRange = attackRange;

        return clone;

    }

}
