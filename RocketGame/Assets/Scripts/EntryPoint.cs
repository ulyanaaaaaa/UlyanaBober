using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _rocketStartPoint;
    private KeabordInput _input;
    private MoneyFabrica _moneyFabrica;
    private MoneyFabrica _moneyFabricaCreated;
    private FuelFabrica _fuelFabrica;
    private FuelFabrica _fuelFabricaCreated;
    private CloudFabrica _cloudFabrica;
    private CloudFabrica _cloudFabricaCreated;
    private Rocket _rocket;
    private Rocket _rocketCreated;
    private FailWindow _failWindow;
    private FailWindow _failWindowCreated;
    private FuelBar _fuelBar;
    private FuelBar _fuelBarCreated;
    private ShopSpeedItem _shopSpeedItem;
    private ShopSpeedItem _shopSpeedItemCreated;

    private void Awake()
    {
        _input = GetComponent<KeabordInput>();
        _rocket = Resources.Load<Rocket>("Rocket");
        _failWindow = Resources.Load<FailWindow>("FailWindow"); 
        _fuelBar = Resources.Load<FuelBar>("FuelBar"); 
        _moneyFabrica = Resources.Load<MoneyFabrica>("MoneyFabrica");
        _cloudFabrica = Resources.Load<CloudFabrica>("CloudFabrica");
        _fuelFabrica = Resources.Load<FuelFabrica>("FuelFabrica");
        _shopSpeedItem = Resources.Load<ShopSpeedItem>("ItemSpeed");
        CreateRocket();
        CreateUI();
        _input.OnPlay += CreateSpawners;
    }

    private void CreateUI()
    {
        _fuelBarCreated = Instantiate(_fuelBar, 
            _failWindow.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _fuelBarCreated.Setup(_rocketCreated);
        _fuelBarCreated.GetComponent<RectTransform>().localPosition = _fuelBar.GetComponent<RectTransform>().localPosition;

        _failWindowCreated = Instantiate(_failWindow, 
            _failWindow.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _failWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
        _failWindowCreated.Setup(_rocketCreated);
        
        _shopSpeedItemCreated = Instantiate(_shopSpeedItem, 
            _shopSpeedItem.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _shopSpeedItemCreated.Setup(_rocketCreated);
        _shopSpeedItemCreated.GetComponent<ShopSpeedItemViewer>().Setup(_rocketCreated);
        _shopSpeedItemCreated.GetComponent<RectTransform>().localPosition = _shopSpeedItem.GetComponent<RectTransform>().localPosition;
    }

    private void CreateRocket()
    {
        _rocketCreated = Instantiate(_rocket, _rocketStartPoint.position, Quaternion.identity);
        _rocketCreated.Setup(_input);
    }

    private void CreateSpawners()
    {
        _moneyFabricaCreated = Instantiate(_moneyFabrica);
        _moneyFabricaCreated.Setup(_rocketCreated);
        _cloudFabricaCreated = Instantiate(_cloudFabrica);
        _cloudFabricaCreated.Setup(_rocketCreated);
        _fuelFabricaCreated = Instantiate(_fuelFabrica);
        _fuelFabricaCreated.Setup(_rocketCreated);
    }
}
