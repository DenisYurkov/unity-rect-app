using UnityEngine;
using UnityEngine.UI;

public class PhotosItem : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Image _image;

    public void UpdatePhotosItem(string title, Sprite sprite)
    {
        _title.text = title;
        _image.sprite = sprite;
    }
}
