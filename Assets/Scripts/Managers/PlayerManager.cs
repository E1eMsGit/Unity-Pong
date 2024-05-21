using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerManager
{
    public GameObject paddlePrefab;
    public Color paddleColor;
    public Transform paddleSpawnPoint;
    public GameObject gateInstance;
    public Text scoreLabel;
    
    private PaddleMovement _paddleMovement;
    private PaddleHit _paddleHit;
    private Gate _gate;
    private int _wins;

    public bool IsGoal { get => _gate.IsGoal; }
    public int Wins 
    { 
        get => _wins; 
        set
        {
            _wins = value;
            if (scoreLabel != null)
            {
                scoreLabel.text = _wins.ToString();
            }          
        }
    }
    public int PlayerNumber { get; set; }
    public GameObject PaddleInstance { get; set; }

    public void Setup()
    {
        _paddleMovement = PaddleInstance.GetComponent<PaddleMovement>();
        _paddleMovement.playerNumber = PlayerNumber;
        _paddleHit = PaddleInstance.GetComponent<PaddleHit>();
        _paddleHit.playerNumber = PlayerNumber;

        SpriteRenderer paddleSpriteRender = PaddleInstance.GetComponentInChildren<SpriteRenderer>();
        paddleSpriteRender.color = paddleColor;

        _gate = gateInstance.GetComponent<Gate>();
    }

    public void Reset()
    {
        PaddleInstance.transform.position = paddleSpawnPoint.position;
        PaddleInstance.transform.rotation = paddleSpawnPoint.rotation;

        PaddleInstance.SetActive(false);
        PaddleInstance.SetActive(true);

        gateInstance.SetActive(false);
        gateInstance.SetActive(true);
    }
}
