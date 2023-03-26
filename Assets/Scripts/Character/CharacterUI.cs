using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] public Image fillHealth;

    public void UpdateBarHealth(int health, int healthMax) 
    {
        fillHealth.fillAmount = (float)health / healthMax;
    }
}
