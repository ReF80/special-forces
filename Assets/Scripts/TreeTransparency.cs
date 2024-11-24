using UnityEngine;

public class TreeTransparency : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    public Color transparentColor;
        
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color; 
        transparentColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _spriteRenderer.color = transparentColor; 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _spriteRenderer.color = _originalColor; 
    }
}