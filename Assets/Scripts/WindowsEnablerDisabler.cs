using UnityEngine;

public class WindowsEnablerDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    public void Hide()
    {
        _window.SetActive(false);
    }

    public void Show()
    {
        _window.SetActive(true);
    }
}
