using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleFabrica))]

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private CounterUI _counter;
    [SerializeField] private int _currentCount, _goalCount;
    [SerializeField] private float _delay;
    private CircleFabrica _fabrica;

    private void Awake()
    {
        _fabrica = GetComponent<CircleFabrica>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void RemoveCurrentCircle()
    {
        _currentCount--;
    }

    private void CheckCircleCount()
    {
        if (_currentCount >= _goalCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void CreateCircle()
    {
        Circle circleCreated = null;
        _currentCount++;
        Vector3 randomPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        int random = Random.Range(0, 100);
        if (random < 25)
        {
            circleCreated = _fabrica.CreateCircle(randomPosition).Setup(_counter);
        }
        if(random >= 25 && random < 50)
        {          
            circleCreated = _fabrica.CreateDangerCircle(randomPosition).Setup(_counter);
            circleCreated.OnDestroy += circleCreated.DestroyLvl;
        }
        if (random >= 50 && random < 75)
        {
            circleCreated = _fabrica.CreateMoveCircle(randomPosition).Setup(_counter);
        }
        if (random >= 75)
        {
            circleCreated=_fabrica.CreateLifeTimeCircle(randomPosition).Setup(_counter);
        }
        circleCreated.OnClick += RemoveCurrentCircle;
        CheckCircleCount();
    }


    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return null;
            for (int i = _currentCount; _currentCount < _goalCount; i++)
            {
                yield return new WaitForSeconds(_delay);
                CreateCircle();
            }
        }
    }
}
