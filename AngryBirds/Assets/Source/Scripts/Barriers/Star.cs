using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] private GameObject _star;
    [SerializeField] private GameObject _starImage;

    private void Awake()
    {
        _starImage.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bird>())
        {
            Destroy(_star); 
            _starImage.SetActive(true);
        }
    }
}
