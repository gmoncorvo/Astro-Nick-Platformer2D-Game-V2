using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moncrow.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Eneies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .5f;
    public float delay = 0.1f;
    public Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPoint();
    }

    private void SpawnPoint()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }

}
