using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header ("Settings")]
    [SerializeField] private int health;
    [SerializeField] private int healthMax;
    [SerializeField] private int damage;
    [SerializeField] private int criticalDamage;
    
    [Header ("References")]
    [SerializeField] private EnemyAnimation enemyAnim;
    [SerializeField] private CharacterUI enemyUI;
    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimation playerAnim;

    private int randomDamage;
    private TypeDamageEffect typeDamageEffect;

    public void TakeDamage(int _damage) 
    {
        if (!enemyAnim.isTakeDamage) { enemyAnim.TakeDamage(); }

        health = Mathf.Clamp(health - _damage, 0, healthMax);
        enemyUI.UpdateBarHealth(health, healthMax);
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            enemyAnim.Death();
        }
        else
        {
            enemyAnim.QuizManagerChangeButtons();
        }
    }

    public void Attack()
    {
        bool criticalAttack = Random.value > 0.8f;

        if (!criticalAttack)
        {
            randomDamage = Random.Range(damage - 2, damage + 2);
            typeDamageEffect = TypeDamageEffect.Normal;
        }
        else
        {   
            randomDamage = Random.Range(criticalDamage - 2, criticalDamage + 2);
            typeDamageEffect = TypeDamageEffect.Critical;
        }
        
        if (!playerAnim.isShield)
        {
            GameObject damageEffect = DamageEffectPool.Instance.RequestDamageEffect(randomDamage, typeDamageEffect);
            damageEffect.transform.position = player.transform.position;
        }    

        player.TakeDamage(damage);
    }

    public void AttackFinal()
    {
        player.TakeDamage(criticalDamage);
    }

    public void CheckHealthEnemy()
    {
        player.CheckHealth();
    }
}
