using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelEnd;

    public float tiempoTransicion;

    private void Start()
    {
        panelStart.SetActive(true);
        panelEnd.SetActive(false);
    }   

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EsperarTransicion(string nameScene)
    {
        StartCoroutine(ActivarTransicion(nameScene));     
    }

    public IEnumerator ActivarTransicion(string nameScene)
    {
        panelEnd.SetActive(true);
        yield return new WaitForSeconds(tiempoTransicion);
        ChangeScene(nameScene);
    }
}