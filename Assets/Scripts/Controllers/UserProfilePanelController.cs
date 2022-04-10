using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class UserProfilePanelController : AbstractPanelController
{
    [Header("Controllers")] [SerializeField]
    private LoginPanelController _loginPanelController;

    [SerializeField] private TopPanelController _topPanelController;

    [Header("UI Text")] [SerializeField] 
    private Text _id, _name, _username, _email, _phone, _website, _addressStreet, _suite, _city, _zipCode, _geo, 
        _companyName, _catchPhrase, _bs;
       
    [Header("Loading Screen")] [SerializeField]
    private GameObject _loadingScreen;
    
    private List<Users> _users = new List<Users>();
    
    protected override async Task OnShow()
    {
        _loadingScreen.gameObject.SetActive(true);
        _topPanelController.ChangeTitle("Loading");
        
        string content = await Extensions.GetContentFromServer("https://jsonplaceholder.typicode.com/users?id=", _loginPanelController.Id);
        _users = Extensions.Deserialize<List<Users>>(content);
        
        foreach (var user in _users)
        {
            _id.text = user.Id.ToString();
            _name.text = user.Name;
            _username.text = user.Username;
            _email.text = user.Email;
            _phone.text = user.Phone;
            _website.text = user.WebSite;
            _addressStreet.text = user.Address.Street;
            _suite.text = user.Address.Suite;
            _city.text = user.Address.City;
            _zipCode.text = user.Address.ZipCode;
            _geo.text = user.Address.Geo.Lat + "\n";
            _geo.text += user.Address.Geo.Lng;
            _companyName.text = user.Company.Name;
            _catchPhrase.text = user.Company.CatchPhrase;
            _bs.text = user.Company.Bs;
        }
        _loadingScreen.gameObject.SetActive(false);
        gameObject.SetActive(true);
        _topPanelController.ChangeTitle("User Profile");
    }
    
    protected override void OnHide()
    {
        _id.text = "";
        _name.text = "";
        _username.text = "";
        _email.text = "";
        _phone.text = "";
        _website.text = "";
        _addressStreet.text = "";
        _suite.text = "";
        _city.text = "";
        _zipCode.text = "";
        _geo.text = "";
        _companyName.text = "";
        _catchPhrase.text = "";
        _bs.text = "";
    }
}
