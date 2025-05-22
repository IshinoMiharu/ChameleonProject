using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    private static List<int> rankingData = Enumerable.Repeat(0, 3).ToList();//�X�R�A��ێ����郊�X�g

    public static void AddRankingData(int data)//�X�R�A��ێ����邽�߂̃��\�b�h
    {
        rankingData.Add(data);//���X�g�ɃX�R�A��ǉ�

        rankingData = rankingData.OrderBy(n => -n).Take(3).ToList();//���X�g�̒��g���~���Ƀ\�[�g
    }

    [SerializeField] private Transform textGroup;//�e�L�X�g�̃I�u�W�F�N�g�����I�u�W�F�N�g���擾
    private Text[] texts;//�e�L�X�g�I�u�W�F�N�g��z��ŕێ�

    private void Start()
    {
        texts =textGroup.GetComponentsInChildren<Text>();//textGroup�����q�I�u�W�F�N�g�����ׂĎ擾
        for(int i = 0; i < 3; i++)
        {
            texts[i].text = $"{i + 1}:{rankingData[i].ToString().PadLeft(5, '0')}";//rankingData�����X�R�A��\��
        }
    }
}
