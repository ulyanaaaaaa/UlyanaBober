using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] private GameObject _tapEffect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickEffector((Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    private void ClickEffector(Vector2 position)
    {
        Instantiate(_tapEffect, position, Quaternion.identity, transform);
    }
}
