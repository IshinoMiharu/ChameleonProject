using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    private static List<int> rankingData = Enumerable.Repeat(0, 3).ToList();//スコアを保持するリスト

    public static void AddRankingData(int data)//スコアを保持するためのメソッド
    {
        rankingData.Add(data);//リストにスコアを追加

        rankingData = rankingData.OrderBy(n => -n).Take(3).ToList();//リストの中身を降順にソート
    }

    [SerializeField] private Transform textGroup;//テキストのオブジェクトを持つオブジェクトを取得
    private Text[] texts;//テキストオブジェクトを配列で保持

    private void Start()
    {
        texts =textGroup.GetComponentsInChildren<Text>();//textGroupが持つ子オブジェクトをすべて取得
        for(int i = 0; i < 3; i++)
        {
            texts[i].text = $"{i + 1}:{rankingData[i].ToString().PadLeft(5, '0')}";//rankingDataが持つスコアを表示
        }
    }
}
