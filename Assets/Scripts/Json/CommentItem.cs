using UnityEngine;
using UnityEngine.UI;

public class CommentItem : MonoBehaviour
{
    [SerializeField] private Text _id;
    [SerializeField] private Text _name;
    [SerializeField] private Text _email;
    [SerializeField] private Text _body;

    public void UpdateCommentItem(int id, string name, string email, string body)
    {
        _id.text = id.ToString();
        _name.text = name;
        _email.text = email;
        _body.text = body;
    }
}
