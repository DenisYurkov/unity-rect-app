using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelController : AbstractPanelController
{
    [Header("Controllers: ")] [SerializeField] 
    private UserProfilePanelController _userProfilePanelController;

    [Header("UI")] [SerializeField] 
    private Button _loginButton;
    
    [SerializeField] 
    private InputField _inputField;
    public int Id { get; private set;}

    private void Awake() => _loginButton.onClick.AddListener(OnLoginButtonClicked);

    private void OnLoginButtonClicked()
    {
        Id = Convert.ToInt32(_inputField.text);

        if (Id > 0 && Id <= 10)
        {
            Hide();
            _userProfilePanelController.Show();             
        }
        else
        {
            Debug.LogWarning("You entered an <b>ID</b> that does not exist! Write <b>ID</b> from 1 to 10.");
        }
    }

    private void OnDestroy() => _loginButton.onClick.RemoveListener(OnLoginButtonClicked);
}