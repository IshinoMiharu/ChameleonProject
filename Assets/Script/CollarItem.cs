using UnityEngine;

public class ColorItem : MonoBehaviour
{
    [Header("このオブジェクトの色タグを指定")]
    [SerializeField] private ColorTag colorTag;

    [Header("加算されるスコア値")]
    [SerializeField] private int scoreValue = 10;

    public ColorTag ColorTag => colorTag;
    public int ScoreValue => scoreValue;
}