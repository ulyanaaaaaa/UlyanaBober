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
    private ShopFuelItem _shopFuelItem;
    private ShopFuelItem _shopFuelItemCreated;
    private MoneyCounter _moneyCounter;
    private MoneyCounter _moneyCounterCreated;

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
        _shopFuelItem = Resources.Load<ShopFuelItem>("ItemFuel");
        _moneyCounter = Resources.Load<MoneyCounter>("MoneyCounter");
        CreateMoneyCounter();
        CreateRocket();
        CreateUI();
        _input.OnPlay += CreateSpawners;
        _input.OnPlay += DisableShop;
        _input.OnPlay += FuelBarCreated;
    }

    private void CreateUI()
    {
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
        _shopSpeedItemCreated.GetComponent<RectTransform>().localPosition = 
            _shopSpeedItem.GetComponent<RectTransform>().localPosition;
        
        _shopFuelItemCreated = Instantiate(_shopFuelItem, 
            _shopFuelItem.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _shopFuelItemCreated.Setup(_rocketCreated);
        _shopFuelItemCreated.GetComponent<ShopFuelItemViewer>().Setup(_rocketCreated);
        _shopFuelItemCreated.GetComponent<RectTransform>().localPosition = 
            _shopFuelItem.GetComponent<RectTransform>().localPosition;
    }

    private void CreateMoneyCounter()
    {
        _moneyCounterCreated = Instantiate(_moneyCounter,
            _moneyCounter.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _moneyCounterCreated.GetComponent<RectTransform>().localPosition = 
            _moneyCounter.GetComponent<RectTransform>().localPosition;
    }

    private void CreateRocket()
    {
        _rocketCreated = Instantiate(_rocket, _rocketStartPoint.position, Quaternion.identity);
        _rocketCreated.Setup(_input, _moneyCounterCreated);
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
    
    private void FuelBarCreated()
    {
        _fuelBarCreated = Instantiate(_fuelBar, 
            _failWindow.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _fuelBarCreated.Setup(_rocketCreated);
        _fuelBarCreated.GetComponent<RectTransform>().localPosition = 
            _fuelBar.GetComponent<RectTransform>().localPosition;

    }

    private void DisableShop()
    {
        _shopSpeedItemCreated.gameObject.SetActive(false);
        _shopFuelItemCreated.gameObject.SetActive(false);
    }
}
