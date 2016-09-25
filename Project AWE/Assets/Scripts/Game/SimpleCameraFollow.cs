using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform FollowTarget;

    private Vector3 _DeadZone;

	// Use this for initialization
	void Start () {
        _DeadZone = (this.transform.position - FollowTarget.position);
        if (_DeadZone.magnitude > Time.deltaTime)
        {
            this.transform.position = FollowTarget.position;
        }

        _DeadZone = (this.transform.eulerAngles - FollowTarget.eulerAngles);
        if (_DeadZone.magnitude > Time.deltaTime)
        {
            this.transform.rotation = FollowTarget.rotation;
        }
	}
	
	// Update is called once per frame
	void Update () {
        _DeadZone = (this.transform.position - FollowTarget.position);
        if (_DeadZone.magnitude > Time.deltaTime)
        {
            this.transform.position = FollowTarget.position;
        }

        _DeadZone = (this.transform.eulerAngles - FollowTarget.eulerAngles);
        if (_DeadZone.magnitude > Time.deltaTime)
        {
            //this.transform.rotation = FollowTarget.rotation;
        }
    }
}
