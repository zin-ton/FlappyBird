using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float _speed = 2f;
    private float _leftEdge;

    private void Start()
    {
        _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    public void Update()
    {
        transform.position += Vector3.left * (_speed * Time.deltaTime);
        if (transform.position.x < _leftEdge)
        {
            Destroy(gameObject);
        }
    }
}