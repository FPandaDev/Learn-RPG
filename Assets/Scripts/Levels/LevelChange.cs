using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private Image levelImage;

    [SerializeField] private Level[] levels;

    [SerializeField] private Image levelBlock;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textPlay;

    [SerializeField] Color colorAvailable;
    [SerializeField] Color colorInavailable;

    private int currentIndex;

    private void Awake()
    {
        ChangeLevel(0);
    }

    public void ChangeLevel(int _change)
    {
        currentIndex += _change;

        if (currentIndex < 0) currentIndex = levels.Length - 1;
        else if (currentIndex > levels.Length - 1) currentIndex = 0;

        DisplayLevel(levels[currentIndex]);
    }

    public void DisplayLevel(Level _level)
    {
        levelName.text = _level.levelName;
        levelImage.sprite = _level.levelImage;

        if (!_level.available)
        {
            button.interactable = false;
            levelBlock.enabled = true;
            levelImage.color = colorInavailable;
            textPlay.color = colorInavailable;
        }
        else
        {
            button.interactable = true;
            levelBlock.enabled = false;
            levelImage.color = colorAvailable;
            textPlay.color = colorAvailable;
        }
    }

    public void PlayLevel()
    {
        //GameManager.instance.nextScene = levels[currentIndex].levelScene;
        //SceneManager.LoadScene("Loader");
        SceneManager.LoadScene(levels[currentIndex].levelScene);
    }

    public void BackMenu(string index)
    {
        SceneManager.LoadScene(index);
    }
}
