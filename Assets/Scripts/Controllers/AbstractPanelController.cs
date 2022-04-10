using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractPanelController : MonoBehaviour
{
    public void Show()
    {
        Hide();
        Extensions.CancelToken();
        OnShow();
    }

    public void Hide()
    {
        Extensions.CancelToken();
        gameObject.SetActive(false);
        OnHide();
    }

    protected virtual Task OnShow()
    {
        return Task.CompletedTask;
    }

    protected virtual void OnHide()
    {
    }
}