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
    private bool _isMouseDown;

    public Cube Setup(CubeFabrica cubeFabrica)
    {
        _cubeFabrica = cubeFabrica;
        return this;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _isMouseDown = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _isMouseDown = false;
        Shoot();
    }
    
    private void Update()
    {
        if (_isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (_count == cube._count)
            {
                Destroy(cube);
                Destroy(gameObject);
                Cube newCube = Resources.Load<Cube>((_count * _count).ToString());
                Instantiate(newCube, transform.position, Quaternion.identity).
                    SetCount(_count * 2);
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
