using UnityEngine;
using System.Collections;

namespace AWESystem
{
    public class InputDirector : Singleton<InputDirector>
    {
        private bool _ready = false;
        private GameObject _player;

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

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("'A' Pressed");
            }
        }

        public virtual void SetPlayer(GameObject aPlayer)
        {
            _player = aPlayer;
            _ready = true;
        }
    }
}