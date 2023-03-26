using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Animator anim;
    [SerializeField] private Player player;
    [SerializeField] private QuizManager quizManager;

    public bool isTakeDamage { get { return anim.GetBool("TakeDamage");} }

    public bool isShield { get { return anim.GetBool("Shield");} }

    public void ShieldActive()
    {
        anim.SetBool("Shield", true);
        quizManager.buttonDefend.interactable = false;
    }

    public void ShieldDesactive()
    {
        anim.SetBool("Shield", false);  
        quizManager.ChangeStateButtons();
    }

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

    public void AttackEnemyAnimation()
    {
        player.Attack();
    }

    public void AttackFinalEnemyAnimation()
    {
        player.AttackFinal();
    }

    public void FinalAttack()
    {
        player.CheckHealthEnemy();
    }

    public void PanelTransition()
    {
        StartCoroutine(quizManager.FinalBattle("Lose"));
    }    
}
