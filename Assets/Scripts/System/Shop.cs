using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TextMeshProUGUI coins;

    private int tmpCost;

    private void Update()
    {
        coins.text = GameManager.instance.coins.ToString();
    }   

    public void Cost(int cost)
    {
        tmpCost = cost;       
    }
    
    public void BuyPotion()
    {
        if (GameManager.instance.coins >= tmpCost)
        {
            GameManager.instance.potions++;
            GameManager.instance.coins -= tmpCost;
        }
    }

    public void BuyShield(int shield)
    {
        if (GameManager.instance.coins >= tmpCost)
        {
            GameManager.instance.shield = shield;
            GameManager.instance.coins -= tmpCost;
        }
    }

    public void BuySword(int damage)
    {
        if (GameManager.instance.coins >= tmpCost)
        {
            GameManager.instance.damage = damage;
            GameManager.instance.damageCritical = damage + 4;
            GameManager.instance.coins -= tmpCost;
        }   
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
}
