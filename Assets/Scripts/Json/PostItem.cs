using UnityEngine;
using UnityEngine.UI;

public class PostItem : MonoBehaviour
{
    [SerializeField] private Text _idText;
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _bodyText;

    public Transform Divider;
    public void UpdatePostItem(int id, string title, string body)
    {
        _idText.text = id.ToString();
        _titleText.text = title;
        _bodyText.text = body;
    }
}
