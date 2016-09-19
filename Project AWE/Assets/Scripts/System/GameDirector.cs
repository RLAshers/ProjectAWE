using UnityEngine;
using System.Collections;

namespace AWESystem
{
    public class GameDirector : Singleton<GameDirector>
    {
        public PlayerController Player { get; set; }

        private PlayerController _player;

        // Use this for initialization
        protected virtual void Start()
        {
            if (Player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                Player = _player;
            }

            if (_player != null)
            {
                InputDirector.Instance.SetPlayer(_player);
            }
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            
        }
    }
}