using Godot;

public class DayDisplay : Label
{
    #region Initialization

    public override void _Ready()
    {
        GameManager.DayPassed += SetText;
    }

    #endregion

    #region Methods

    private void SetText()
    {
        Text = GameManager.Day.ToString();
    }

    #endregion
}
