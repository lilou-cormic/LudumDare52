using Godot;

public class MoneyDisplay : Label
{
    #region Initialization

    public override void _Ready()
    {
        GameManager.MoneyChanged += () => SetText();

        SetText();
    }

    #endregion

    #region Méthodes

    private void SetText()
    {
        Text = GameManager.Money.ToString();
    }

    #endregion
}
