using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        if (health > damage)
        {
            Debug.Log("”дар по врагу");
            health -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
