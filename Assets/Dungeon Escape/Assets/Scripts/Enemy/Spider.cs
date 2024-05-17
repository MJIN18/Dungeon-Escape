using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject _acidPrefab;
    public int Health { get; set; }

    // Use for Initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
        Debug.Log("Health:" + Health);
    }

    public void Attack()
    {
        Vector2 spawnPos = new Vector2(transform.position.x + 1.0f, transform.position.y);
        Instantiate(_acidPrefab, spawnPos, Quaternion.identity);
    }
}
