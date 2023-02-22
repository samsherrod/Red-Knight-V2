﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the dealing of damage to health components.
/// </summary>
public class Damage : MonoBehaviour
{
    [SerializeField] private bool canDamage = true;
    [Tooltip("Allows for this object to kill another object instantly. Damage Amount will be ignored.")]
    [SerializeField] private bool canOneShot = false;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private bool dealDamageOnTriggerEnter = false;
    [SerializeField] private bool dealDamageOnTriggerStay = false;

    /// <summary>
    /// When this object collides with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage && !collision.CompareTag("Ignore"))
        {
            if (dealDamageOnTriggerEnter)
            {
                DealDamage(collision.gameObject);
            }
        }
    }

    /// <summary>
    /// When this object collides with another object and stays next to it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canDamage && !collision.CompareTag("Ignore"))
        {
            if (dealDamageOnTriggerStay)
            {
                DealDamage(collision.gameObject);
            }
        }
    }

    private void DealDamage(GameObject collisionGameObject)
    {
        Health collidedHealth = collisionGameObject.GetComponent<Health>();
        if (collidedHealth != null)
        {
            if (!collisionGameObject.CompareTag(gameObject.tag))
            {
                if (canOneShot) collidedHealth.TakeDamage(collidedHealth.GetCurrentHealth());
                else collidedHealth.TakeDamage(damageAmount);
            }
        }
    }

    public void StopDamaging()
    {
        canDamage = false;
        Debug.Log("canDamage: " + canDamage);
    }
}