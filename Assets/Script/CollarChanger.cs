using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class ColorChanger : MonoBehaviour
{
    [Header("色変更対象のRenderer")]
    [SerializeField] private Renderer targetRenderer;

    [Header("色の切り替えにかかる時間（秒）")]
    [SerializeField] private float colorChangeDuration = 0.5f;

    [Header("一致時のスコア倍率")]
    [SerializeField] private float matchMultiplier = 5f;

    private Material targetMaterial;
    private Color currentTargetColor = Color.white;
    private ColorTag currentColorTag = ColorTag.White;
    private Tween colorTween;

    private List<Collider2D> currentTriggers = new List<Collider2D>();

    private void Start()
    {
        targetMaterial = targetRenderer.material;
        targetMaterial.color = Color.white;
    }

    private void Update()
    {
        Color desiredColor = GetDesiredColor(out ColorTag desiredTag);

        if (desiredColor != currentTargetColor)
        {
            currentTargetColor = desiredColor;
            currentColorTag = desiredTag;

            colorTween?.Kill();

            colorTween = targetMaterial
                .DOColor(currentTargetColor, colorChangeDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    Debug.Log($"色が変わりきった：{currentColorTag}");
                    CheckMatchingColliders();
                });
        }
    }

    private Color GetDesiredColor(out ColorTag tag)
    {
        bool key1 = Input.GetKey(KeyCode.A);
        bool key2 = Input.GetKey(KeyCode.W);
        bool key3 = Input.GetKey(KeyCode.D);

        if (key1 && key2 && key3)
        {
            tag = ColorTag.Black;
            return Color.black;
        }
        else if (key1 && key2)
        {
            tag = ColorTag.Purple;
            return new Color(0.5f, 0f, 0.5f);
        }
        else if (key2 && key3)
        {
            tag = ColorTag.Green;
            return Color.green;
        }
        else if (key1 && key3)
        {
            tag = ColorTag.Orange;
            return new Color(1f, 0.5f, 0f);
        }
        else if (key1)
        {
            tag = ColorTag.Red;
            return Color.red;
        }
        else if (key2)
        {
            tag = ColorTag.Blue;
            return Color.blue;
        }
        else if (key3)
        {
            tag = ColorTag.Yellow;
            return Color.yellow;
        }
        else
        {
            tag = ColorTag.White;
            return Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!currentTriggers.Contains(other))
            currentTriggers.Add(other);

        TryScoreAndDestroy(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentTriggers.Remove(other);
    }

    private void CheckMatchingColliders()
    {
        foreach (var col in currentTriggers.ToArray())
        {
            if (col != null)
            {
                TryScoreAndDestroy(col);
            }
        }
    }

    private void TryScoreAndDestroy(Collider2D col)
    {
        ColorItem item = col.GetComponent<ColorItem>();

        if (item != null)
        {
            int baseScore = item.ScoreValue;
            float finalScore = baseScore;

            if (item.tag == "Trap")
            {
                ScoreManager.Instance.decreaseScore(Mathf.RoundToInt(finalScore));

            }
            else if (item.ColorTag == currentColorTag)
            {
                if(item.tag != "Trap")
                {
                    finalScore *= matchMultiplier;
                    Debug.Log($"色一致アイテム発見！+{finalScore}点（倍率:{matchMultiplier}）");
                }
            }
            else
            {
                Debug.Log($"色不一致アイテム接触：+{finalScore}点");
            }

            ScoreManager.Instance.AddScore(Mathf.RoundToInt(finalScore));
            currentTriggers.Remove(col);
            Destroy(col.gameObject);
        }
    }
}
