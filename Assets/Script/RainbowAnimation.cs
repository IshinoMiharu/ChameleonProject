using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RainbowUI : MonoBehaviour
{
    [Header("色変化対象のUI Image")]
    [SerializeField] private Image targetImage;

    [Header("1色ごとの変化時間（秒）")]
    [SerializeField] private float colorChangeDuration = 0.5f;

    private void Start()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
        }

        // 虹色に変化させるシーケンス
        Sequence rainbowSequence = DOTween.Sequence();

        rainbowSequence.Append(targetImage.DOColor(Color.red, colorChangeDuration))
            .Append(targetImage.DOColor(new Color(1f, 0.5f, 0f), colorChangeDuration)) // Orange
            .Append(targetImage.DOColor(Color.yellow, colorChangeDuration))
            .Append(targetImage.DOColor(Color.green, colorChangeDuration))
            .Append(targetImage.DOColor(Color.cyan, colorChangeDuration)) // 水色
            .Append(targetImage.DOColor(Color.blue, colorChangeDuration))
            .Append(targetImage.DOColor(new Color(0.5f, 0f, 1f), colorChangeDuration)) // Violet
            .SetLoops(-1, LoopType.Restart) // 永久ループ
            .SetEase(Ease.Linear);
    }
}
