using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    private const string TitleSceneName = "Title";
    private const string IngameSceneName = "InGame";
    
    public Image fadePanel;
    public float fadeDuration = 1f;
    public string nextSceneName;

    private void Start()
    {
         Scene scene = SceneManager.GetActiveScene();
         if (scene.name == TitleSceneName)
         {
             SoundManager.instance.PlayBGM(SoundManager.BGM_Type.Tittle);
         }
         else
         {
             SoundManager.instance.PlayBGM(SoundManager.BGM_Type.GameStart);
         }
    }

    public void OnClickLoadScene()
    {
        ChangeScene(nextSceneName);
        if (nextSceneName == TitleSceneName)
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM_Type.Tittle);
        }
        if (nextSceneName == IngameSceneName)
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM_Type.GameStart);
        }
    }
    public void ChangeScene(string title)
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0);

        fadePanel.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            SceneManager.LoadScene(title);//�V�[����
        });
    }

    public void FadeIn()
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 1);

        fadePanel.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            fadePanel.gameObject.SetActive(false);
        });
    }
}
