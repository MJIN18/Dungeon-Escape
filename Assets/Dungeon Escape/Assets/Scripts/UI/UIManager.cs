using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is NULL!");
            }
            return _instance;
        }
    }
    [SerializeField] private TextMeshProUGUI _gemCountText;
    [SerializeField] private TextMeshProUGUI _playerGemCountText;
    [SerializeField] private Image _selectionImg;
    [SerializeField] private Image[] _lifeUnits;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = "Player Gems: " + gemCount + "G";
    }

    public void UpdateShopSelection(int ypos)
    {
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, ypos);
    }

    public void UpdateGemCount(int count)
    {
        _gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        _lifeUnits[livesRemaining].enabled = false;
        //for (int i = 0; i <= livesRemaining; i++)
        //{
        //    if (i == livesRemaining)
        //    {
        //        _lifeUnits[i].enabled = false;
        //    }
        //}
    }
}
