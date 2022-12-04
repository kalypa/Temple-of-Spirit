using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EndingController : SingleMonobehaviour<EndingController>
{
    private CharacterController characterController;
    private NavMeshAgent agent;
    public Transform target;
    [SerializeField] private GameObject endingEnemy;
    private bool isEnd;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance + 0.01f) && isEnd == true)
        {
            Invoke("Bad", 4f);
        }
    }

    public void HappyEnding()
    {
        GameManager.Instance.ghost.SetActive(false);
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.fadeImage.DOFade(0, 4);
        Invoke("KillDo", 4f);
        Escape();
    }

    private void Escape()
    {
        agent.SetDestination(target.position);
        isEnd = true;
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            characterController.Move(agent.velocity * Time.deltaTime);
            return;
        }
    }

    private void KillDo()
    {
        DOTween.Kill(GameManager.Instance.fadeImage);
        GameManager.Instance.fadePanel.SetActive(false);
        GameManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
    }

    private void Bad()
    {
        endingEnemy.SetActive(true);
        this.gameObject.transform.DORotate(new Vector3(0, 270, 0), 8f);
        Invoke("End", 9f);
        Invoke("ReGame", 13f);
    }

    private void End()
    {
        GameManager.Instance.endingPanel.SetActive(true);
        OnClickManager.Instance.startPanel.SetActive(true);
    }

    private void ReGame()
    {
        GameManager.Instance.endingPanel.SetActive(false);
        DataManager.Instance.RestartInit();
    }
}
