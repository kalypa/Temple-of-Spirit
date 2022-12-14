using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using InputSystem;
public class TutorialManager : SingleMonobehaviour<TutorialManager>
{
    public Image tutorialPanel;
    public bool isFirst = false;
    public void KeyTutorial()
    {
        InputSystems.Instance.isPanel = true;
        tutorialPanel.rectTransform.DOAnchorPosX(-560, 1f);
    }

    public void OnclickTutorialPanelBackButton()
    {
        tutorialPanel.rectTransform.DOAnchorPosX(-1420, 1f);
        Invoke("Kill", 1f);
    }

    private void Kill()
    {
        DOTween.Kill(tutorialPanel);
        InputSystems.Instance.isPanel = false;
        tutorialPanel.gameObject.SetActive(false);
        GameManager.Instance.walk.enabled = true;
        GameManager.Instance.playerInput.enabled = true;
        GameManager.Instance.controller.enabled = true;
        isFirst = true;
    }
}
