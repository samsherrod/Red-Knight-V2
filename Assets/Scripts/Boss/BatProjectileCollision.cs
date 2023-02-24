﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProjectileCollision : MonoBehaviour
{
    // Enemy attack
    [SerializeField] private int attackDamage = 20;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Destroy(gameObject);
        }
    }

}