using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fadeCanvas;//インスペクタからPrefab化したCanvasを入れる

    void Start()
    {
        if (!FadeManager.isFadeInstance)
        {
            Instantiate(fadeCanvas);
        }

        Invoke("findFadeObject", 0.02f);// 起動時用にCanvasの召喚をちょっと待つ
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        fadeCanvas.GetComponent<FadeManager>().fadeIn();
    }

    public async void sceneChange(string sceneName)
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);//暗転するまで待つ
        SceneManager.LoadScene(sceneName);
    }
}
