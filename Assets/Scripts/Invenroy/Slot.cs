using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetSprite(Sprite sprite)
    {
        var color = sprite == null ? Color.clear : Color.white;
        _image.color = color;
        _image.sprite = sprite;
    }
}
