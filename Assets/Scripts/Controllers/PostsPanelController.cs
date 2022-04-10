using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PostsPanelController : AbstractPanelController
{
    [Header("Controllers: ")] [SerializeField]
    private LoginPanelController _loginPanelController;

    [SerializeField] 
    private TopPanelController _topPanelController;
    
    [Header("Prefab Settings:")] [SerializeField] 
    private PostItem _postItemPrefab;

    [SerializeField] 
    private CommentItem _commentItemPrefab;
    
    [SerializeField] 
    private Transform _root;
    
    [SerializeField]
    private GameObject _loadingScreen;
    
    private readonly List<PostItem> _postItems = new List<PostItem>();
    private readonly List<CommentItem> _commentItems = new List<CommentItem>();
    
    private List<Posts> _posts = new List<Posts>();
    private List<Comments> _comments = new List<Comments>();

    protected override async Task OnShow()
    {
        _loadingScreen.gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Loading");
        
        string content = await Extensions.GetContentFromServer("https://jsonplaceholder.typicode.com/posts?userId=", _loginPanelController.Id);
        _posts = Extensions.Deserialize<List<Posts>>(content);
        
        foreach (var p in _posts)
        {
            PostItem postItem = Instantiate(_postItemPrefab, _root);
            postItem.UpdatePostItem(p.Id, p.Title, p.Body);
            _postItems.Add(postItem);

            string commentContent = await Extensions.GetContentFromServer("https://jsonplaceholder.typicode.com/comments?postId=", p.Id);
            _comments = Extensions.Deserialize<List<Comments>>(commentContent);
            
            foreach (var c in _comments)
            {
                CommentItem commentItem = Instantiate(_commentItemPrefab, postItem.transform);
                commentItem.UpdateCommentItem(c.Id, c.Name, c.Email, c.Body);
                _commentItems.Add(commentItem);
            }
        }
        _loadingScreen.gameObject.SetActive(false);
        gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Posts");
    }

    protected override void OnHide()
    {
        for (int i = _postItems.Count - 1; i >= 0; i--)
        {
            Destroy(_postItems[i].gameObject);
        }
        _postItems.Clear();
        _commentItems.Clear();
    }
}
