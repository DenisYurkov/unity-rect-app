using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PhotosPanelController : AbstractPanelController
{
    [Header("Controllers: ")] [SerializeField] 
    private TopPanelController _topPanelController;
    
    [Header("Prefab Settings: ")] [SerializeField] 
    private PhotosItem _photosItemPref;
    
    [SerializeField] 
    private Transform _root;

    [SerializeField] 
    private GameObject _loadingScreen;

    private readonly List<PhotosItem> _photosItems = new List<PhotosItem>();
    private List<Photos> _photos = new List<Photos>();

    public int AlbumID { get; set; }

    protected override async Task OnShow()
    {
        _topPanelController.ChangeTitle("Loading");
        _loadingScreen.gameObject.SetActive(true);
        
        var content = await Extensions.GetContentFromServer("https://jsonplaceholder.typicode.com/photos?albumId=", AlbumID);
        _photos = Extensions.Deserialize<List<Photos>>(content);
        
        foreach (var p in _photos)
        {
            var getImage = await Extensions.GetContentFromServerByte(p.Url);
           
            Texture2D texture2D = new Texture2D(2, 2);
            texture2D.LoadImage(getImage);
            
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
            PhotosItem photosItem = Instantiate(_photosItemPref, _root);
            
            photosItem.UpdatePhotosItem(p.Title, sprite);
            _photosItems.Add(photosItem);
        }
        _loadingScreen.gameObject.SetActive(false);
        gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Photos");
    }

    protected override void OnHide()
    {
        for (int i = _photosItems.Count - 1; i >= 0; i--)
        {
            Destroy(_photosItems[i].gameObject);
        }
        _photosItems.Clear();
    }
}