using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanelController : MonoBehaviour
{
    [Header("Panel Controllers: ")]
    [SerializeField] private UserProfilePanelController _userProfilePanelController;
    [SerializeField] private TodosPanelController _todosPanelController;
    [SerializeField] private AlbumsPanelController _albumsPanelController;
    [SerializeField] private PostsPanelController _postsPanelController;
    [SerializeField] private TopPanelController _topPanelController;
    [SerializeField] private PhotosPanelController _photosPanelController;

    [Header("Buttons: ")] [SerializeField] 
    private Button _userProfileButton,_todosPanelButton, _albumsPanelButton, _postsPanelButton;
    
    private void Awake()
    {
        _userProfileButton.onClick.AddListener(OnUserProfileButtonClicked);
        _todosPanelButton.onClick.AddListener(OnTodosPanelButtonClicked);
        _albumsPanelButton.onClick.AddListener(OnAlbumsPanelButtonClicked);
        _postsPanelButton.onClick.AddListener(OnPostsPanelButtonClicked);
    }

    private void OnDestroy()
    {
        _userProfileButton.onClick.RemoveListener(OnUserProfileButtonClicked);
        _todosPanelButton.onClick.RemoveListener(OnTodosPanelButtonClicked);
        _albumsPanelButton.onClick.RemoveListener(OnAlbumsPanelButtonClicked);
        _postsPanelButton.onClick.RemoveListener(OnPostsPanelButtonClicked);
    }

    private void OnUserProfileButtonClicked()
    {
        _todosPanelController.Hide();
        _albumsPanelController.Hide();
        _postsPanelController.Hide();
        _photosPanelController.Hide();

        _userProfilePanelController.Show();
    }

    private void OnTodosPanelButtonClicked()
    {
        _userProfilePanelController.Hide();
        _albumsPanelController.Hide();
        _postsPanelController.Hide();
        _photosPanelController.Hide();
        
        _todosPanelController.Show();
    }

    private void OnAlbumsPanelButtonClicked()
    {
        _userProfilePanelController.Hide();
        _todosPanelController.Hide();
        _postsPanelController.Hide();
        _photosPanelController.Hide();

        _albumsPanelController.Show();
    }
    
    private void OnPostsPanelButtonClicked()
    {
        _userProfilePanelController.Hide();
        _todosPanelController.Hide();
        _albumsPanelController.Hide();
        _photosPanelController.Hide();
        
        _postsPanelController.Show();
    }
}