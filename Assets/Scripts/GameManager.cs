using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    public Text _scoreText;
    public GameObject _playButton;
    public GameObject _gameOverText;
    public Player _player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
        _playButton.SetActive(false);
        _gameOverText.SetActive(false);
        Time.timeScale = 1f;
        _player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (var t in pipes)
        {
            Destroy(t.gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        _gameOverText.SetActive(true);
        _playButton.SetActive(true);
        Pause();
    }
    
}