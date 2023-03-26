using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemAttack : MonoBehaviour
{
    public Animator animPanelQuiz;
    public QuizManager quizManager;

    public void ButtonAttack()
    {
        quizManager.ChangeStateButtons();
        quizManager.StartQuestion();
        quizManager.SetCurrentQuestion();

        animPanelQuiz.SetTrigger("ActiveQuiz");
    }

    public void DisableQuiz()
    {
        animPanelQuiz.SetTrigger("DisableQuiz");
    }
}
