using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class LevelCell : MonoBehaviour
{
   private Button _button;
   private LevelData _levelData;
   private SceneService _sceneService;

   [Inject]
   public void Constructor(SceneService sceneService)
   {
      _sceneService = sceneService;
   }

   private void Awake()
   {
      _button = GetComponent<Button>();
   }

   private void Start()
   {
      _button.onClick.AddListener(OpenLevel);
   }

   public void Setup(LevelData data)
   {
      _levelData = data;
   }

   private void OpenLevel()
   {
      _sceneService.LoadScene(_levelData.Scene.Name);
   }
}
