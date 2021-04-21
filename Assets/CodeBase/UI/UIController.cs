using Assets.CodeBase.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.UI
{
	public class UIController : MonoBehaviour
	{
		public List<IUI_Panel> InterfacePanels { get; set; } = new List<IUI_Panel>();
		public Action<UIPanelType> ShowUIPanelAloneAction = default;
		public Action<UIPanelType> ShowUIPanelAlongAction = default;
		public MainPanel mainPanel = default;
		public GamePanel gamePanel = default;
		public Canvas canvas = default;

		private void OnEnable()
		{
			ShowUIPanelAloneAction += ShowPanelAlone;
			ShowUIPanelAlongAction += ShowPanelAlong;
		}

		private void OnDisable()
		{
			ShowUIPanelAloneAction -= ShowPanelAlone;
			ShowUIPanelAlongAction -= ShowPanelAlong;
		}

		public void Construct(IFactory factory) 
		{
			mainPanel.Construct();
			gamePanel.Construct(factory, canvas);
		}

		private void ShowPanelAlone(UIPanelType _uIPanelType)
		{
			InterfacePanels.Find(somePanel => somePanel.UIPanelType == _uIPanelType)?.Show();
			var temp = InterfacePanels.FindAll(somePanel => somePanel.UIPanelType != _uIPanelType);
			foreach (var item in temp)
			{
				item.Hide();
			}
		}

		private void ShowPanelAlong(UIPanelType _uIPanelType)
		{
			InterfacePanels.Find(somePanel => somePanel.UIPanelType == _uIPanelType)?.Show();
		}
	}
}