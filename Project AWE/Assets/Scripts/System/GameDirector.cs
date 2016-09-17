using UnityEngine;
using System.Collections;

namespace AWESystem
{
    public class GameDirector : Singleton<GameDirector>
    {
        public GameObject Player { get; set; }

        private GameObject _player;

        // Use this for initialization
        protected virtual void Start()
        {
            if (Player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player");
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