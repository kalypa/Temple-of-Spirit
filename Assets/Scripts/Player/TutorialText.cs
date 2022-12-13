using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : SingleMonobehaviour<TutorialText>
{
    public Text textUI;
    public string TutorialStoryText = "찢어지게 가난해서 힘들게 살아가던 나는 근처 산속 사원에 엄청나게 " +
        "값비싼 \r\n신물이 있다는 소문을 들었다. 그 소문에 홀려 깊은 산속에 들어가 길을 잃었지만... \r\n나는 " +
        "어째서인지 사원에 도착해 있었다...";
    
    public IEnumerator OnType(float interval, string Say)
    {
        foreach (char item in Say)
        {
            textUI.text += item;
            yield return new WaitForSeconds(interval);
        }
    }
}
