using UnityEngine;

public class CursoreController : MonoBehaviour
{
    [SerializeField] public Texture2D cursorTexture;
    
    void Start() => Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
}

