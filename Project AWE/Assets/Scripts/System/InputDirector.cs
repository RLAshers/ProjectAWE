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
        private Dictionary<string, InputID> _InputDictionary = new Dictionary<string, InputID>();

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

                _player.SetMovement(movement);

            }
            //  This handles movement via Keyboard
            else
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

                _player.SetMovement(movement);
            }

            //  This handles orientation via Console
            if (Application.isConsolePlatform)
            {

            }
            //  This handles orientation via Mouse
            else
            {

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
                {

                }
            }

            //  This handles buttons via Console and Keyboard
            if (Input.GetButtonDown("A Button") || Input.GetButton("A Button"))
            {
                _player.SkillInput(_InputDictionary["A Button"]);
            }
            if (Input.GetButtonDown("B Button") || Input.GetButton("B Button"))
            {
                _player.SkillInput(_InputDictionary["B Button"]);
            }
            if (Input.GetButtonDown("X Button") || Input.GetButton("X Button"))
            {
                _player.SkillInput(_InputDictionary["X Button"]);
            }
            if (Input.GetButtonDown("Y Button") || Input.GetButton("Y Button"))
            {
                _player.SkillInput(_InputDictionary["Y Button"]);
            }

        }

        public virtual void SetPlayer(PlayerController aPlayer)
        {
            _player = aPlayer;
            _ready = true;
        }

        public virtual void SetInputDictionary(Dictionary<string, InputID> aDictionary)
        {
            _InputDictionary = aDictionary;
        }

        protected virtual void InitializeDictionary()
        {
            //  This is the default Input Dictionary
            _InputDictionary.Add("A Button", InputID.Jump);
            _InputDictionary.Add("B Button", InputID.Melee);
            _InputDictionary.Add("X Button", InputID.Defend);
            _InputDictionary.Add("Y Button", InputID.Range);
        }
    }
}