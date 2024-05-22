using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int _value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if(player != null)
            {
                player.AddGems(_value);
                //player._diamond += _value;
                Destroy(this.gameObject);
            }
        }
    }
}
