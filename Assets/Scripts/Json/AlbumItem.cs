using UnityEngine;
using UnityEngine.UI;

public class AlbumItem : MonoBehaviour
{
    [SerializeField] private Text _id;
    [SerializeField] private Text _title;

    public Button ButtonImage;

    public void UpdateAlbumItem(int id, string title)
    {
        _id.text = id.ToString();
        _title.text = title;
    }
}
