using System;
using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Block block;

    private void Start()
    {
        block.InstantiatePool(20, transform);

        if (GameManager.Instance.isGamePaused)
        {
            StopCoroutine(WaveSpawn());
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGamePaused += OnGamePaused;
    }

    private void OnDisable()
    {
        if (GameManager.Instance)
            GameManager.Instance.OnGamePaused -= OnGamePaused;
    }

    private void OnGamePaused(bool isPaused)
    {
        if (isPaused)
        {
            StopSpawn();
        }
        else
        {
            StartSpawn();
        }
    }

    private void StartSpawn()
    {
        StartCoroutine(WaveSpawn());
    }

    private void StopSpawn()
    {
        StopCoroutine(WaveSpawn());
    }

    IEnumerator WaveSpawn()
    {
        while (!GameManager.Instance.isGamePaused)
        {
            yield return new WaitForSeconds(1.5f);

            Block b = block.Get();
            b.transform.position = transform.position;
        }
    }
}