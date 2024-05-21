using System;
using UnityEngine;

[Serializable]
public class BallManager
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    [HideInInspector] public GameObject instance;
    [HideInInspector] public Vector3 direction;

    private BallMovement movement;

    public void Setup()
    {
        movement = instance.GetComponent<BallMovement>();
        movement.Direction = direction;
    }

    public void Reset()
    {
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = spawnPoint.rotation;
        movement.Direction = direction;

        instance.SetActive(false);
        instance.SetActive(true);
    }
}
