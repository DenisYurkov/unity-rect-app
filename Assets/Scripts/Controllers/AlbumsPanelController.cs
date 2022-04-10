using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AlbumsPanelController : AbstractPanelController
{
    [Header("Controllers: ")] [SerializeField] 
    private LoginPanelController _loginPanelController;
    
    [SerializeField] 
    private TopPanelController _topPanelController;
    
    [SerializeField] 
    private PhotosPanelController _photosPanelController;
    
    [Header("Prefab Settings: ")] [SerializeField] 
    private AlbumItem _albumItemPrefab;
    
    [SerializeField]
    private Transform _root;

    [SerializeField]
    private GameObject _loadingScreen;
    
    private readonly List<AlbumItem> _albumItems = new List<AlbumItem>();
    private List<Album> _albums = new List<Album>();

    protected override async Task OnShow()
    {
        _loadingScreen.gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Loading");
        
        var content = await Extensions.GetContentFromServer("https://jsonplaceholder.typicode.com/albums?userId=", _loginPanelController.Id);
        _albums = Extensions.Deserialize<List<Album>>(content);
        
        foreach (var album in _albums)
        {
            AlbumItem albumItem = Instantiate(_albumItemPrefab, _root);
            albumItem.UpdateAlbumItem(album.Id, album.Title);
            _albumItems.Add(albumItem);

            albumItem.ButtonImage.onClick.AddListener(() => ChangeID(album));
        }
        _loadingScreen.gameObject.SetActive(false);
        gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Albums");
    }

    private void ChangeID(Album album)
    {
        Hide();
        _photosPanelController.AlbumID = album.Id;
        _photosPanelController.Show();
    }

    protected override void OnHide()
    {
        for (int i = _albumItems.Count - 1; i >= 0; i--)
        {
            _albumItems[i].ButtonImage.onClick.RemoveAllListeners();
            Destroy(_albumItems[i].gameObject);
        }
        _albumItems.Clear();
    }
}
