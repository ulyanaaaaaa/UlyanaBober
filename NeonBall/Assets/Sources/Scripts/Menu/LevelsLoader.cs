using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelsLoader : MonoBehaviour
{
    [SerializeField] private List<LevelData> _data;
    private LevelCell _levelCell;
    private DiContainer _diContainer;

    [Inject]
    public void Constructor(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void Awake()
    {
        _levelCell = Resources.Load<LevelCell>(AssetsPath.DataPath.LevelCell);
        GenerateCells();
    }

    private void GenerateCells()
    {
        for (int i = 0; i < _data.Count; i++)
        {
            _diContainer.InstantiatePrefabForComponent<LevelCell>(_levelCell
                ,transform.position + new Vector3(80*i,0,0)
                ,Quaternion.identity 
                ,transform)
                .Setup(_data[i]);
        }
    }
}
