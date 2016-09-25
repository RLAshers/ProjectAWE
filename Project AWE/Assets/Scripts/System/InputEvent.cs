using EnumLibrary;

namespace AWESystem
{
    public class InputEvent
    {
        private bool _ready;
        private string _button;
        private InputID _id;
        private ButtonType _type;

        public InputEvent(InputID id, ButtonType type)
        {
            _id = id;
            _type = type;
            _ready = true;
            _button = "";
        }

        public void Ready()
        {
            _ready = true;
        }

        public bool CheckState()
        {
            return _ready;
        }

        public InputID GetID(string button)
        {
            if (_type == ButtonType.Single)
            {
                _ready = false;
                _button = button;
            }

            return _id;
        }

        public string GetButton()
        {
            return _button;
        }
    }
}