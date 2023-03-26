using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScene : MonoBehaviour
{
    [SerializeField] private Image loadBar;

    private void Start()
    {
        LoadScene();
        //StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        string _nextScene = GameManager.instance.nextScene;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_nextScene);

        while (!asyncOperation.isDone)
        {
            loadBar.fillAmount = asyncOperation.progress / 0.9f;
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    public async void LoadScene()
    {
        var scene = SceneManager.LoadSceneAsync(GameManager.instance.nextScene);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            loadBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);
        scene.allowSceneActivation = true;
    }


}
