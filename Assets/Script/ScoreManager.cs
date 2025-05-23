using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("スコア表示用のTextコンポーネント")]
    [SerializeField] private Text scoreText;

    [Header("スコアのアニメーション時間（秒）")]
    [SerializeField] private float animationDuration = 0.5f;

    private int score = 0;
    private int displayedScore = 0;
    private Tween scoreTween;

    private void Awake()
    {
        // シングルトン初期化
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 最初の表示を更新
        UpdateScoreText(0);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"スコアふえる！現在のスコア: {score}");

        AnimateScoreChange();
    }

    public int GetScore()
    {
        return score;
    }

    private void AnimateScoreChange()
    {
        scoreTween?.Kill(); 

        scoreTween = DOTween.To(
            () => displayedScore,
            value => {
                displayedScore = value;
                UpdateScoreText(displayedScore);
            },
            score,
            animationDuration
        ).SetEase(Ease.OutCubic);
    }
    public void RegisterScoreToRanking()
    {
        RankingManager.AddRankingData(score);
    }


    private void UpdateScoreText(int value)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score:{value:D4}";
        }
    }
}