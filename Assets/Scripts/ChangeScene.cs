using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private string nextScene; 

    public void ChangeNextLevel()
    {
        StartCoroutine(ChangeLevel());
    }

    private IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }
}
