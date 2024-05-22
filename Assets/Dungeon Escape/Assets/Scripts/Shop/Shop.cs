using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    
    private PlayerController player;

    private int _currentSelectedItem;
    private int _currentItemCost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            if(player != null)
            {
                UIManager.Instance.OpenShop(player._diamond);
            }
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                {
                    UIManager.Instance.UpdateShopSelection(60);
                    _currentSelectedItem = 0;
                    _currentItemCost = 200;
                    break;
                }
            case 1:
                {
                    UIManager.Instance.UpdateShopSelection(-40);
                    _currentSelectedItem = 1;
                    _currentItemCost = 400;
                    break;
                }
            case 2:
                {
                    UIManager.Instance.UpdateShopSelection(-140);
                    _currentSelectedItem = 2;
                    _currentItemCost = 100;
                    break;
                }
        }
    } 

    public void BuyItem()
    {
        if (player._diamond >= _currentItemCost)
        {
            if(_currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            Debug.Log("Award Item Number: " + _currentSelectedItem);
            player._diamond = player._diamond - _currentItemCost;
            Debug.Log("Gems Left: " + player._diamond);
            //_shopPanel.SetActive(false);
        }
        else
        {
            _shopPanel.SetActive(false);
        }
    }
}
