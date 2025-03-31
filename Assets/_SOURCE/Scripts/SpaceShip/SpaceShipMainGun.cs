using System.Collections;
using UnityEngine;

public class SpaceShipMainGun : MonoBehaviour
{
    [SerializeField] Bullet defaultBullet;

    private void Start()
    {
        defaultBullet.InstantiatePool(20, null);

        StartCoroutine(SpawnBullet());
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
        StartCoroutine(SpawnBullet());
    }

    private void StopSpawn()
    {
        StopCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        while (!GameManager.Instance.isGamePaused)
        {
            yield return new WaitForSeconds(.5f);

            Bullet bullet = defaultBullet.Get();
            bullet.transform.position = transform.position;
        }
    }
}