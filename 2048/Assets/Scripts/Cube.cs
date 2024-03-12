using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int _count;
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private CubeFabrica _cubeFabrica;
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        MoveObjectWithMouse();
    }
    
    public void MoveObjectWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            transform.position = Vector3.Lerp(transform.position, targetPoint, Time.deltaTime * 10f);
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Shoot();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (_count == cube._count)
            {
                Cube newCube = Resources.Load<Cube>((_count * 2).ToString());
                
                Instantiate(newCube, transform.position, Quaternion.identity).
                    SetCount(_count * 2);
                
                Destroy(cube);
                Destroy(gameObject);
            }
        }
    }

    private void SetCount(int count)
    {
        _count = count;
    }

    private void Shoot()
    {
        _rigidbody.AddForce(Vector3.up * _speed, ForceMode.Impulse);
        _cubeFabrica.CreateRandomCube();
    }
}
