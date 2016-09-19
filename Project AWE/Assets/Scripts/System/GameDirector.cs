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
                if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
                {
                    GameObject[] _temp = GameObject.FindGameObjectsWithTag("Player");

                    foreach(GameObject unit in _temp)
                    {
                        if (unit.GetComponent<PlayerController>())
                        {
                            _player = unit.GetComponent<PlayerController>();
                            Player = _player;
                        }
                    }
                }
                else
                {
                    Debug.LogError("No Player found");
                }
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