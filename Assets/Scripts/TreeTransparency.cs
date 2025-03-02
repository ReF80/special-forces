using UnityEngine;

public class TreeTransparency : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Color _transparentColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color; 
        _transparentColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _spriteRenderer.color = _transparentColor; 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _spriteRenderer.color = _originalColor; 
    }
}