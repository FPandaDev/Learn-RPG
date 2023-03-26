using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Animator anim;
    [SerializeField] private Enemy enemy;
    [SerializeField] private QuizManager quizManager;

    public bool isTakeDamage { get { return anim.GetBool("TakeDamage");} }

    public void ChangeTakeDamage()
    {
        anim.SetBool("TakeDamage", false);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void TakeDamage()
    {
        anim.SetBool("TakeDamage", true);
        quizManager.buttonDefend.interactable = false;
    }
    
    public void Death()
    {
        anim.SetBool("Death", true);
    }

    public void MeleeAttack()
    {
        enemy.Attack();
    }

    public void RangedAttack()
    {
        enemy.AttackFinal();
    }

    public void FinalAttack()
    {
        enemy.CheckHealthEnemy();       
    }

    public void QuizManagerChangeButtons()
    {
        quizManager.ChangeStateButtons();
    }

    public void PanelTransition()
    {
        StartCoroutine(quizManager.FinalBattle("Win"));
    }
}
