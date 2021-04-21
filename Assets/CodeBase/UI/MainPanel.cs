using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.UI
{
	public class MainPanel : MonoBehaviour, IUI_Panel
	{
		[Header("Base")]
		[SerializeField] private UIPanelType uIPanelType = UIPanelType.Main;
		[SerializeField] private UIController uIController = default;
		[SerializeField] private GameObject container = default;
		[SerializeField] private Button playButton = default;
		[SerializeField] private Button quitButton = default;

		private void Awake()
		{
			Init();
			PrepareButtons();
		}
		private void PrepareButtons()
		{
			playButton.onClick.RemoveAllListeners();
			playButton.onClick.AddListener(()=> 
			{
				uIController.ShowUIPanelAloneAction?.Invoke(UIPanelType.Game);
			});
			quitButton.onClick.RemoveAllListeners();
			quitButton.onClick.AddListener(() =>
			{
				//save
				Application.Quit();
			});
		}
		public void Construct() 
		{
			//some saving data service
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
		}
	}
}
