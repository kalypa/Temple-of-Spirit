using Cinemachine;
using DG.Tweening;
using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
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
            Invoke("Good", 4f);
        }
    }

    public void HappyEnding()
    {
        EndingVolume();
        EndSceneStart();
        Escape();
    }

    public void SadEnding()
    {
        SadSceneStart();
        Invoke("KillDo", 10f);
        PlayerDead();
    }

    private void SadSceneStart()
    {
        GameManager.Instance.flashLight.enabled = true;
        GameManager.Instance.fadePanel.SetActive(true);
        GameManager.Instance.ghost.SetActive(false);
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.walk.enabled = false;
    }

    private void EndingVolume()
    {
        VolumeChange.Instance.vignette.intensity.value = 1;
        GameManager.Instance.fog.SetActive(true);
        VolumeChange.Instance.volume.weight = 0.25f;
    }
    private void EndSceneStart()
    {
        GameManager.Instance.ghost.SetActive(false);
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.walk.enabled = false;
        GameManager.Instance.fadeImage.DOFade(0, 4);
        Invoke("KillDo", 4f);
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
    private void PlayerDead()
    {
        gameObject.transform.position = GameManager.Instance.badendingPos.position;
        AudioManager.instance.Play("Blood");
        GameManager.Instance.blood.SetActive(true);
        Invoke("End", 9f);
        Invoke("ReGame", 13f);

    }

    private void KillDo()
    {
        DOTween.Kill(GameManager.Instance.fadeImage);
        GameManager.Instance.fadePanel.SetActive(false);
        GameManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
    }

    private void Good()
    {
        endingEnemy.SetActive(true);
        this.gameObject.transform.DORotate(new Vector3(0, 270, 0), 8f);
        AudioManager.instance.Play("Rising");
        Invoke("End", 9f);
        Invoke("ReGame", 13f);
    }

    private void End()
    {
        GameManager.Instance.fadePanel.SetActive(false);
        GameManager.Instance.endingPanel.SetActive(true);
        OnClickManager.Instance.startPanel.SetActive(true);
    }

    private void ReGame()
    {
        GameManager.Instance.endingPanel.SetActive(false);
        GameManager.Instance.blood.SetActive(false);
        DataManager.Instance.RestartInit();
    }
}
