using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Operation { SUMA, RESTA, MULTIPLICACION, DIVISION}

public class QuizManagerSimple : MonoBehaviour
{
    [SerializeField] Operation operation;

    [Header("References")]
    //[SerializeField] private QuizDataScriptable quizData;
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

    private float time;
    private bool inWait;
    private int randomAnswerIndex;

    [SerializeField] private float answer;
    [SerializeField] private int num1, num2;

    [SerializeField] private GameObject panelTransition;

    private void Start()
    {
        time = timeToAnswer;
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

    public void SetAnswers()
    {
        randomAnswerIndex = Random.Range(0, 4);

        num1 = Random.Range(0, 100);
        num2 = Random.Range(0, 100);

        for (int i = 0; i < optionsText.Length; i++) 
        {    
            if (i == randomAnswerIndex)
            {
                optionsText[i].text = TipoOperacion().ToString();
            }
            else
            {
                optionsText[i].text = (Random.Range(0, 100)).ToString();
            }        
        }
    }

    private float TipoOperacion()
    {
        switch (operation)
        {
            case Operation.SUMA:
                answer = num1 + num2;
                factText.text = $"{num1} + {num2}";
                break;

            case Operation.RESTA:
                answer = (num1 > num2) ? num1 - num2 : num2 - num1;
                factText.text = (num1 > num2) ? $"{num1} - {num2}" : $"{num2} - {num1}";
                break;

            case Operation.MULTIPLICACION:
                answer = num1 * num2;
                factText.text = $"{num1} x {num2}";
                break;

            case Operation.DIVISION:
                answer = num1 / num2;
                factText.text = $"{num1} / {num2}";
                break;
        }
        return answer;
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

    public void BackMenu()
    {
        StartCoroutine(FinalBattle("3. Level Menu"));
    }

    public IEnumerator FinalBattle(string scene)
    {
        panelTransition.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
}
