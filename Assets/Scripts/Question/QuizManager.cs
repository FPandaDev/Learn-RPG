using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private QuizDataScriptable quizData;
    [SerializeField] private SystemAttack systemAttack;

    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimation playerAnim;

    [SerializeField] private EnemyAnimation enemyAnim;

    [Header("References UI")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI factText;
    [SerializeField] private TextMeshProUGUI[] optionsText;

    public Button buttonDefend;
    [SerializeField] private Button[] buttons;

    [Header("Settings")]
    [SerializeField] private float timeToAnswer;
    [SerializeField] private float timeBetweenQuestions;
    

    private List<Question> questions;
    private Question currentQuestion;

    private float time;
    private bool inWait;
    private int randomQuestionIndex;
    private int randomAnswerIndex;

    [SerializeField] private GameObject panelTransition;

    private void Start()
    {
        questions = quizData.questions;
        time = timeToAnswer;

        //SetCurrentQuestion();
    }

    private void Update()
    {
        if (!inWait)
        {
            timeText.text = "-";
            return;
        }

        if (time <= 0)
        {
            StartCoroutine(TimeIsOver());
        }

        time -= Time.deltaTime;
        timeText.text = ((int)time).ToString();   
    }

    public void SetCurrentQuestion()
    {
        randomQuestionIndex = Random.Range(0, questions.Count);
        randomAnswerIndex = Random.Range(0, 4);

        currentQuestion = questions[randomQuestionIndex];
        optionsText[randomAnswerIndex].text = currentQuestion.correctAnswer;

        factText.text = currentQuestion.question;

        int tmp = 0;
        for (int i = 0; i < 4; i++)
        {
            if (i != randomAnswerIndex)
            {
                optionsText[i].text = currentQuestion.options[tmp];
                tmp++;
            }
        }
        questions.RemoveAt(randomQuestionIndex);
    }

    public void StartQuestion()
    {
        inWait = !inWait;
        time = timeToAnswer;
    }

    public void UserSelectTrue(int i)
    {
        StartCoroutine(Attack(i));
    }

    private IEnumerator TimeIsOver()
    {
        inWait = false;
        systemAttack.DisableQuiz();

        yield return new WaitForSeconds(timeBetweenQuestions);

        buttonDefend.interactable = player.ShieldAvailable();
        enemyAnim.Attack();
    }

    private IEnumerator Attack(int index)
    {
        StartQuestion();
        systemAttack.DisableQuiz();
        yield return new WaitForSeconds(timeBetweenQuestions);

        if (index == randomAnswerIndex)
        {
            playerAnim.Attack();
        }
        else
        {
            buttonDefend.interactable = player.ShieldAvailable();
            enemyAnim.Attack();
        }
    }

    public void ChangeStateButtons()
    {
        foreach (Button _button in buttons)
        {
            _button.interactable = !_button.interactable;
        }
    }

    public IEnumerator FinalBattle(string scene)
    {
        panelTransition.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }

    public void BackMenu()
    {
        StartCoroutine(FinalBattle("3. Level Menu"));
    }
}