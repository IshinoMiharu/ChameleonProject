using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    private static List<int> rankingData = Enumerable.Repeat(0, 3).ToList();

    public static void AddRankingData(int data)
    {
        rankingData.Add(data);

        rankingData = rankingData.OrderBy(n => -n).Take(3).ToList();
    }

    [SerializeField] private Transform textGroup;
    private Text[] texts;

    private void Start()
    {
        texts =textGroup.GetComponentsInChildren<Text>();
        for(int i = 0; i < 3; i++)
        {
            texts[i].text = rankingData[i].ToString();
        }
    }
}
