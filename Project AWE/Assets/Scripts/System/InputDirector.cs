using UnityEngine;
using EnumLibrary;
using System.Collections;
using System.Collections.Generic;

namespace AWESystem
{
    public class InputDirector : Singleton<InputDirector>
    {
        private bool _ready = false;
        private PlayerController _player;

        //  These variables handle Inputs
        private List<InputEvent> _StandbyInput = new List<InputEvent>();
        private Dictionary<string, InputEvent> _InputDictionary = new Dictionary<string, InputEvent>();

        protected override void Awake()
        {
            //  This keeps it as a Singleton
            base.Awake();
            //  Initialize default values needed
            InitializeDictionary();
        }

        // Use this for initialization
        protected virtual void Start()
        {
            
            if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                //Cursor.lockState = CursorLockMode.Locked;
            }
            
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (!_ready)
            {
                return;
            }

            //  This handles movement via Console
            if ((Input.GetAxis("Left Joystick Horizontal") != 0) ||
                (Input.GetAxis("Left Joystick Vertical") != 0))
            {
                Vector2 movement = Vector2.zero;

                movement.x = Input.GetAxis("Left Joystick Horizontal");
                movement.y = Input.GetAxis("Left Joystick Vertical");

                _player.Move(movement);

            }
            //  This handles movement via Keyboard
            else if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                Vector2 movement = Vector2.zero;

                //  Forward Movement
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
                {
                    movement.y += 1;
                }
                //  Back Movement
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
                {
                    movement.y += -1;
                }
                //  Left Movement
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
                {
                    movement.x += -1;
                }
                //  Right Movement
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
                {
                    movement.x += 1;
                }

                _player.Move(movement);
            }

            //  This handles orientation via Console
            if ((Input.GetAxis("Right Joystick Horizontal") != 0) ||
                (Input.GetAxis("Right Joystick Vertical") != 0))
            {
                Vector2 orientation = Vector2.zero;


            }
            //  This handles orientation via Mouse
            else if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    Vector3 orientation = Vector3.zero;

                    orientation.x = Input.GetAxis("Mouse Y");
                    orientation.y = Input.GetAxis("Mouse X");

                    _player.Look(orientation);
                }
            }

            //  This handles buttons via Console and Keyboard
            if (Input.GetButtonDown("A Button") || Input.GetButton("A Button"))
            {
                InputEvent input = _InputDictionary["A Button"];

                if (input.CheckState())
                {
                    _player.SkillInput(input.GetID("A Button"));

                    if (!input.CheckState())
                    {
                        _StandbyInput.Add(input);
                    }
                }
            }
            if (Input.GetButtonDown("B Button") || Input.GetButton("B Button"))
            {
                InputEvent input = _InputDictionary["B Button"];

                if (input.CheckState())
                {
                    _player.SkillInput(input.GetID("B Button"));

                    if (!input.CheckState())
                    {
                        _StandbyInput.Add(input);
                    }
                }
            }
            if (Input.GetButtonDown("X Button") || Input.GetButton("X Button"))
            {
                InputEvent input = _InputDictionary["X Button"];

                if (input.CheckState())
                {
                    _player.SkillInput(input.GetID("X Button"));

                    if (!input.CheckState())
                    {
                        _StandbyInput.Add(input);
                    }
                }
            }
            if (Input.GetButtonDown("Y Button") || Input.GetButton("Y Button"))
            {
                InputEvent input = _InputDictionary["Y Button"];

                if (input.CheckState())
                {
                    _player.SkillInput(input.GetID("Y Button"));

                    if (!input.CheckState())
                    {
                        _StandbyInput.Add(input);
                    }
                }
            }


            //  This handles resetting Single Fire Checks
            foreach (InputEvent input in _StandbyInput)
            {
                if (Input.GetButtonUp(input.GetButton()))
                {
                    input.Ready();
                }
            }
        }

        public virtual void SetPlayer(PlayerController aPlayer)
        {
            _player = aPlayer;
            _ready = true;
        }

        public virtual void SetInputDictionary(Dictionary<string, InputEvent> aDictionary)
        {
            _InputDictionary = aDictionary;
        }

        protected virtual void InitializeDictionary()
        {
            //  This is the default Input Dictionary
            _InputDictionary.Add("A Button", new InputEvent(InputID.Jump,   ButtonType.Single));
            _InputDictionary.Add("B Button", new InputEvent(InputID.Melee,  ButtonType.Single));
            _InputDictionary.Add("X Button", new InputEvent(InputID.Defend, ButtonType.Single));
            _InputDictionary.Add("Y Button", new InputEvent(InputID.Range,  ButtonType.Single));
        }


    }
}