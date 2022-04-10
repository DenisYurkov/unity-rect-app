using UnityEngine;
using UnityEngine.UI;

public class TodoItem : MonoBehaviour
{
    [SerializeField] private Text _idText;
    [SerializeField] private Text _titleText;
    [SerializeField] private Toggle _completedToggle;

    public void UpdateTodoItem(int id, string title, bool completed)
    {
        _idText.text = id.ToString();
        _titleText.text = title;
        _completedToggle.isOn = completed;
    }
}