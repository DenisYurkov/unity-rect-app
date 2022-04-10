using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TodosPanelController : AbstractPanelController
{
    [Header("Controllers")] [SerializeField]
    private LoginPanelController _loginPanelController;

    [SerializeField] 
    private TopPanelController _topPanelController;

    [Header("Prefab Settings: ")] [SerializeField] 
    private TodoItem _todoItemPrefab;
    
    [SerializeField] 
    private Transform _root;
    
    [SerializeField]
    private GameObject _loadingScreen;
    
    private readonly List<TodoItem> _todoItems = new List<TodoItem>();
    private List<Todo> _todos = new List<Todo>();
    
    protected override async Task OnShow()
    {
        _loadingScreen.gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Loading");
        
        string content = await Extensions.GetContentFromServer("https://jsonplaceholder.typicode.com/todos?userId=", _loginPanelController.Id);
        _todos = Extensions.Deserialize<List<Todo>>(content);
        
        foreach (var t in _todos)
        {
            TodoItem todoItem = Instantiate(_todoItemPrefab, _root);
            todoItem.UpdateTodoItem(t.Id, t.Title, t.Completed);
            _todoItems.Add(todoItem);
        }
        _loadingScreen.gameObject.SetActive(false);
        gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Todos");
    }

    protected override void OnHide()
    {
        for (int i = _todoItems.Count - 1; i >= 0; i--)
        {
            Destroy(_todoItems[i].gameObject);
        }
        _todoItems.Clear();
    }
}