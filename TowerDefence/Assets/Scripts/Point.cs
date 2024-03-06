using UnityEngine;

public class Point : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                OnClick();
            }
        }
    }
    
    private void OnClick()
    {
        Tower tower = Resources.Load<Tower>("Tower");
        Instantiate(tower, transform.position, Quaternion.identity);
    }
}
