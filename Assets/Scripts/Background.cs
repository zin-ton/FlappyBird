using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    public float _animationSpeed = 2f;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Update()
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed, 0) * Time.deltaTime;
    }
}