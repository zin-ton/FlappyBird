using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    public float _gravity = -9.8f;
    public float _jumpForce = 5f;
    private SpriteRenderer _spriteRenderer;
    public Sprite[] _sprites;
    private int _currentSpriteIndex;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Animate), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        _direction = Vector3.zero;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    private void Jump()
    {
        _direction = Vector3.up * _jumpForce;
    }

    private void Animate()
    {
        _currentSpriteIndex++;
        if (_currentSpriteIndex >= _sprites.Length)
        {
            _currentSpriteIndex = 0;
        }

        _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                FindFirstObjectByType<GameManager>().GameOver();
                break;
            case "Scoring":
                FindFirstObjectByType<GameManager>().IncreaseScore();
                break;
        }
    }
}