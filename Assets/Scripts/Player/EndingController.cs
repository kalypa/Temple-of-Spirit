using Cinemachine;
using DG.Tweening;
using InputSystem;
using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EndingController : SingleMonobehaviour<EndingController>
{
    private CharacterController characterController;
    private NavMeshAgent agent;
    [SerializeField] private GameObject endingEnemy;
    private bool isEnd = false;
    private bool isRestart = false;

    private void Update()
    {
        if(isEnd == true)
        {
            if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance + 0.01f))
            {
                if (isRestart == false)
                {
                    isRestart = true;
                    AudioManager.instance.StopPlaying("Run");
                    Invoke("Good", 4f);
                }
            }
        }
    }

    public void HappyEnding()
    {
        EndingVolume();
        EndSceneStart();
    }

    public void SadEnding()
    {
        SadSceneStart();
        Invoke("KillDo", 10f);
        PlayerDead();
    }

    private void SadSceneStart()
    {
        EndingInit();
    }

    private void EndingVolume()
    {
        VolumeChange.Instance.vignette.intensity.value = 1;
        GameManager.Instance.fog.SetActive(true);
        VolumeChange.Instance.volume.weight = 0.25f;
    }

    private void EndSceneStart()
    {
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.tutorialMusic;
        GameManager.Instance.backgroundmusic.Play();
        EndingInit();
        GameManager.Instance.fadePanel.SetActive(true);
        GameManager.Instance.fadeImage.DOFade(0, 6);
        OnClickManager.Instance.invisibleWall2.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
        Invoke("KillDo", 4f);
        Invoke("Escape", 4f);
    }

    private void EndingInit()
    {
        GameManager.Instance.ghost.SetActive(false);
        OnClickManager.Instance.batteryUI.SetActive(false);
        GameManager.Instance.ghost.transform.position = GameManager.Instance.enemyStartPos.position;
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.playerInput.enabled = false;
        GameManager.Instance.walk.enabled = false;
    }
    private void Escape()
    {
        agent.SetDestination(GameManager.Instance.goodEndingPos.position);
        isEnd = true;
        AudioManager.instance.Play("Run");
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
        Invoke("ReGame", 11f);

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
        Invoke("ReGame", 11f);
    }
      
    private void End()
    {
        GameManager.Instance.fadePanel.SetActive(false);
        GameManager.Instance.endingPanel.SetActive(true);
        OnClickManager.Instance.startPanel.SetActive(true);
        InputSystems.Instance.isPanel = true;
    }

    private void ReGame()
    {
        GameManager.Instance.endingPanel.SetActive(false);
        GameManager.Instance.blood.SetActive(false);
        DataManager.Instance.RestartInit();
    }
}
