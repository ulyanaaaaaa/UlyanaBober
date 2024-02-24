using System;
using UnityEngine;

public class FailWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    private void Awake()
    {
        _window.SetActive(false);
    }

    private void Open()
    {
        _window.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        StopAllCoroutines();
    }

    public void Setup(Player player)
    {
        player.OnDie += Open;
    }
}
