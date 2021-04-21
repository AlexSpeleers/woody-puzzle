using Assets.CodeBase.Factory;
using UnityEngine;
using UnityEngine.UI;
using Grid = Assets.CodeBase.Game.Grid;

namespace Assets.CodeBase.UI
{
	public class GamePanel : MonoBehaviour, IUI_Panel
	{
		[Header("Base")]
		[SerializeField] private UIPanelType uIPanelType = UIPanelType.Game;
		[SerializeField] private UIController uIController = default;
		[SerializeField] private GameObject container = default;
		[SerializeField] private PatternContainer patternContainer = default;
		[SerializeField] private Grid grid = default;

		[Header("Buttons")]
		[SerializeField] private Button toMainMenuButton = default;
		[SerializeField] private Button restartButton = default;

		private void Awake()
		{
			Init();
			PrepareButtons();
		}
		private void PrepareButtons() 
		{
			toMainMenuButton.onClick.RemoveAllListeners();
			toMainMenuButton.onClick.AddListener(()=> 
			{
				//cleanUpBoard
				uIController.ShowUIPanelAloneAction?.Invoke(UIPanelType.Main);
			});
			restartButton.onClick.RemoveAllListeners();
			restartButton.onClick.AddListener(()=> 
			{
				//cleanUpBoard
			});
		}
		public void Construct(IFactory factory, Canvas canvas) 
		{
			grid.Construct(factory, canvas);
			patternContainer.Construct(factory, canvas, grid);
		}

		public UIPanelType UIPanelType => uIPanelType;

		public void Hide()
		{
			container.SetActive(false);
		}

		public void Init()
		{
			uIController.InterfacePanels.Add(this);
		}

		public void Show()
		{
			container.SetActive(true);
			grid.ShowBoard();
			patternContainer.PopulatePatterns();
		}
	}
}
