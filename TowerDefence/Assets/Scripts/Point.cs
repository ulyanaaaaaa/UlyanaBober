using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnClick();
                    Destroy(gameObject);
                }
            }
        }
    }
    
    private void OnClick()
    {
        SmallTower tower = Resources.Load<SmallTower>("Tower");
        Instantiate(tower, transform.position, Quaternion.identity).Setup(_wallet);
    }
}
