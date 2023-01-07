using Godot;
using System.Linq;

namespace PurpleCable
{
    public abstract class ValueSelector<T> : Node2D
        where T : struct
    {
        [Export] Label ValueText = null;

        [Export] protected T[] Values = null;

        [Export] int _SelectedIndex = 0;
        public int SelectedIndex
        {
            get => _SelectedIndex;

            set
            {
                _SelectedIndex = value;
                SetText();
            }
        }

        private float _coolDown = 0f;

        public override void _Ready()
        {
            SetText();
        }

        public override void _Process(float delta)
        {
            if (_coolDown > 0)
            {
                _coolDown -= delta;
                return;
            }

            //TODO Godot - if (FindObjectOfType<EventSystem>().currentSelectedGameObject == gameObject)
            {
                var horizontal = GetRawHorizontalAxis();

                if (Mathf.Abs(horizontal) > 0.01f)
                {
                    ChangeValue(horizontal);

                    _coolDown = 0.5f;
                }
            }
        }

        protected virtual float GetRawHorizontalAxis()
        {
            return Input.GetAxis("Left", "Right"); //TODO Godot - Input.GetAxisRaw("Horizontal");
        }

        public void SetValue(T value)
        {
            SelectedIndex = Values.ToList().IndexOf(value);
        }

        public void ChangeValue(float horizontal)
        {
            if (horizontal > 0)
                SelectedIndex = Mathf.Clamp(SelectedIndex + 1, 0, Values.Length - 1);
            else
                SelectedIndex = Mathf.Clamp(SelectedIndex - 1, 0, Values.Length - 1);

            OnValueChanged(Values[SelectedIndex]);

            SetText();
        }

        protected abstract void OnValueChanged(T value);

        private void SetText()
        {
            string text = string.Empty;
            if (SelectedIndex > 0)
                text += "◄ ";

            text += GetDisplayText(Values[SelectedIndex]);

            if (SelectedIndex < Values.Length - 1)
                text += " ►";

            ValueText.Text = text;
        }

        protected virtual string GetDisplayText(T value)
        {
            return TextManager.GetText(value.ToString());
        }
    }
}
