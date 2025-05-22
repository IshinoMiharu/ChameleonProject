using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;
    public string nextSceneName;
    public void OnClickLoadScene()
    {
        ChangeScene(nextSceneName);
    }
    public void ChangeScene(string title)
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0);

        fadePanel.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            SceneManager.LoadScene(title);//ƒV[ƒ“–¼
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
