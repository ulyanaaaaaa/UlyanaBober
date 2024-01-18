using UnityEngine;

public class UnitFabrica : MonoBehaviour
{
    private Unit _unit;

    private void Awake()
    {
        _unit = Resources.Load <Unit> ("Unit");
    }

    public Unit CreateUnit(Vector3 position, Transform parent)
    {
        return Instantiate(_unit, position, Quaternion.identity, parent).GetComponent<Unit>();
    }
}
