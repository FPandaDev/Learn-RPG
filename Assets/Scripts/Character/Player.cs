using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header ("Settings")]
    [SerializeField] private int health;
    [SerializeField] private int healthMax;
    [SerializeField] private int damage;
    [SerializeField] private int criticalDamage;
    [SerializeField] private int useShield;

    [Header ("References")]
    [SerializeField] private PlayerAnimation playerAnim;
    [SerializeField] private CharacterUI playerUI;
    [SerializeField] private Enemy enemy;

    [SerializeField] private TextMeshProUGUI textShield;
    [SerializeField] private TextMeshProUGUI textPotion;

    private void Start()
    {
        damage = GameManager.instance.damage;
        criticalDamage = GameManager.instance.damageCritical;

        useShield = GameManager.instance.shield;

        textShield.text = $"Escudo ({useShield}/{GameManager.instance.shield})";
        textPotion.text = $"Curarse ({GameManager.instance.potions})";
    }

    public bool ShieldAvailable()
    {
        return useShield > 0;
    }

    public void UseShield() 
    {
        useShield--;
        playerAnim.ShieldActive();
        textShield.text = $"Escudo ({useShield}/{GameManager.instance.shield})";
    }

    public void UsePotion()
    {
        if (GameManager.instance.potions > 0)
        {
            GameManager.instance.potions--;
            health = Mathf.Clamp(health + 15, 0, healthMax);
            playerUI.UpdateBarHealth(health, healthMax);

            GameObject damageEffect = DamageEffectPool.Instance.RequestDamageEffect(15, TypeDamageEffect.Healing);
            damageEffect.transform.position = transform.position;

            textPotion.text = $"Curarse ({GameManager.instance.potions})";        
        }    
    }

    public void TakeDamage(int _damage) 
    {
        if (playerAnim.isShield) { return; }

        if (!playerAnim.isTakeDamage) { playerAnim.TakeDamage(); }

        health = Mathf.Clamp(health - _damage, 0, healthMax);
        playerUI.UpdateBarHealth(health, healthMax);
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            playerAnim.Death();
        } 
        else
        {
            playerAnim.ShieldDesactive();
        }
    }

    public void Attack()
    {
        int dmg = Random.Range(damage - 2, damage + 2);

        GameObject damageEffect = DamageEffectPool.Instance.RequestDamageEffect(dmg, TypeDamageEffect.Normal);
        damageEffect.transform.position = enemy.transform.position;

        enemy.TakeDamage(dmg);
    }

    public void AttackFinal()
    {
        int dmg = Random.Range(criticalDamage - 2, criticalDamage + 2);
        
        GameObject damageEffect = DamageEffectPool.Instance.RequestDamageEffect(dmg, TypeDamageEffect.Critical);
        damageEffect.transform.position = enemy.transform.position;

        enemy.TakeDamage(criticalDamage);
    }

    public void CheckHealthEnemy()
    {
        enemy.CheckHealth();
    }
}
