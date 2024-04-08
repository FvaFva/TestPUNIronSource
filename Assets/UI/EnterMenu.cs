using System.Collections.Generic;
using UnityEngine;

public class EnterMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _connectMenu;
    [SerializeField] private CanvasGroup _lobbyMenu;
    [SerializeField] private CanvasGroup _loading;

    private Queue<CanvasGroup> _allGUI;
    private CanvasGroup _currentGUI;

    private void Awake()
    {
        _allGUI = new Queue<CanvasGroup>();
        _currentGUI = _connectMenu;

        _allGUI.Enqueue(_lobbyMenu);

        foreach (CanvasGroup go in _allGUI)
        {
            go.gameObject.SetActive(false);
        }
    }

    public void ShowLoading()
    {
        _currentGUI.gameObject.SetActive(false);
        _loading.gameObject.SetActive(true);
    }

    public void HideLoading()
    {
        _currentGUI.gameObject.SetActive(true);
        _loading.gameObject.SetActive(false);
    }

    public void ShowNextGUI()
    {
        _currentGUI.gameObject.SetActive(false);
        _currentGUI = _allGUI.Dequeue();
        _currentGUI.gameObject.SetActive(true);
    }
}
