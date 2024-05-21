using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerManager[] players;       
    public BallManager ball;
    public AudioSource scoreSound;
    public Text pauseLabel;
    public Canvas _escapeMenu;

    private Vector3 _leftDirection;
    private Vector3 _rightDirection;
    private PlayerManager _roundWinner;
    private bool _isPause;
    private bool _isEscapeMenu;

    
    void Start()
    {
        _leftDirection = new Vector3(-1f, 0f);
        _rightDirection = new Vector3(1f, 0f);

        for (int i = 0; i < players.Length; i++)
        {
            players[i].PaddleInstance = Instantiate(players[i].paddlePrefab, players[i].paddleSpawnPoint.position, players[i].paddleSpawnPoint.rotation);
            players[i].PlayerNumber = i + 1;
            players[i].Setup();
        }

        ball.instance = Instantiate(ball.ballPrefab, ball.spawnPoint.position, ball.spawnPoint.rotation);
        ball.direction = _leftDirection;
        ball.Setup();

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {    
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
        StartCoroutine(GameLoop());
    }

    private IEnumerator RoundStarting()
    {     
        ResetAll();

        yield return null;
    }

    private IEnumerator RoundPlaying()
    {       
        while (!Goal())
        {
            if (!_isEscapeMenu && Input.GetButtonDown("Pause"))
            {
                Pause();
            }

            if (!_isPause && Input.GetButtonDown("EscapeMenu"))
            {
                EscapeMenu();
            }

            yield return null;
        }

        scoreSound.Play();
    }

    private IEnumerator RoundEnding()
    {
        _roundWinner = GetRoundWinner();

        if (_roundWinner != null)
            _roundWinner.Wins++;

        ball.direction = _roundWinner.PlayerNumber == 1? _leftDirection : _rightDirection;
        yield return null;
    }

    private bool Goal()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].IsGoal)
            {
                return true;
            }           
        }

        return false;
    }

    private void Pause()
    {
        if (!_isPause)
        {
            _isPause = true;
            pauseLabel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _isPause = false;
            pauseLabel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void EscapeMenu()
    {
        if (!_isEscapeMenu)
        {
            _isEscapeMenu = true;
            _escapeMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _isEscapeMenu = false;
            _escapeMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private PlayerManager GetRoundWinner()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i].IsGoal)
                return players[i];
        }

        return null;
    }

    private void ResetAll()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Reset();
        }

        ball.Reset();       
    }
}
