using UnityEngine;
using UnityEngine.UI;

public class TopPanelController : MonoBehaviour
{
    [Header("Controllers: ")] [SerializeField] 
    private LoginPanelController _loginPanelController;
    
    [SerializeField]
    private UserProfilePanelController _userProfilePanelController;
    
    [SerializeField]
    private TodosPanelController _todosPanelController;
    
    [SerializeField]
    private AlbumsPanelController _albumsPanelController;
    
    [SerializeField]
    private PostsPanelController _postsPanelController;
    
    [SerializeField]
    private PhotosPanelController _photosPanelController;

    [Header("Buttons:")] [SerializeField] 
    private Button _logoutButton;
    
    private Text _title;

    private void Awake()
    {
        _title = GetComponentInChildren<Text>();
        _logoutButton.onClick.AddListener(OnLogoutButtonClicked);
    }

    private void OnLogoutButtonClicked()
    {
        Extensions.CancelToken();
        
        _userProfilePanelController.Hide();
        _todosPanelController.Hide();
        _albumsPanelController.Hide();
        _postsPanelController.Hide();
        _photosPanelController.Hide();

        _loginPanelController.gameObject.SetActive(true);
    }

    public void ChangeTitle(string text)
    {
        _title.text = text;
    }

    private void OnDestroy()
    {
        _logoutButton.onClick.RemoveListener(OnLogoutButtonClicked);
    }
    
    private void OnApplicationQuit()
    {
        Extensions.CancelToken();
    }
}
