namespace Assets.CodeBase.UI
{
	public interface IUI_Panel
	{
		UIPanelType UIPanelType { get; }
		void Init();
		void Show();
		void Hide();
	}
}
public enum UIPanelType
{
	None,
	Main,
	Game
}
