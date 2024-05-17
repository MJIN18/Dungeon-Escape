using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            return;
        }

        IDamageable hit = other.GetComponent<IDamageable>();
        Debug.Log("Hit:" + other.name);

        if(hit != null)
        {
            if(_canDamage)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(DamageResetRoutine());
            }
        }
    }

    IEnumerator DamageResetRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
