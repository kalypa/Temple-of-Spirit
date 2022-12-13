using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : SingleMonobehaviour<TutorialText>
{
    public Text textUI;
    public string TutorialStoryText = "�������� �����ؼ� ����� ��ư��� ���� ��ó ��� ����� ��û���� " +
        "����� \r\n�Ź��� �ִٴ� �ҹ��� �����. �� �ҹ��� Ȧ�� ���� ��ӿ� �� ���� �Ҿ�����... \r\n���� " +
        "��°������ ����� ������ �־���...";
    
    public IEnumerator OnType(float interval, string Say)
    {
        foreach (char item in Say)
        {
            textUI.text += item;
            yield return new WaitForSeconds(interval);
        }
    }
}
