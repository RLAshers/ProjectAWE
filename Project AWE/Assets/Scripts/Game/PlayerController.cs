using UnityEngine;
using EnumLibrary;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject LookDebug;

    private Vector3 movement = Vector3.zero;
    private Vector3 focus = Vector3.zero;
    private bool updateFocus = false;
    private float speed = 5f;
    private float accel = 5f;
    private float jump = 0f;

    private Rigidbody _RigidBody;

	// Use this for initialization
	void Start () {
        _RigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (movement.magnitude > 0)
        {
            movement *= speed * Time.deltaTime;
            this.transform.Translate(movement, Space.World);

            movement = Vector3.zero;
        }

        if (updateFocus)
        {
            focus *= Time.deltaTime * accel;

            this.transform.Rotate(Vector3.left, focus.x, Space.World);
            this.transform.Rotate(Vector3.up, focus.y, Space.World);

            Camera.main.transform.LookAt(this.transform.position + this.transform.forward * 100f);
            LookDebug.transform.position = this.transform.position + this.transform.forward * 100f;

            //this.transform.parent.Rotate(focus * Time.deltaTime);
            //this.transform.parent.Rotate(orientation);

            updateFocus = false;
        }
    }

    void LateUpdate()
    {
        
    }

    void FixedUpdate()
    {
        if (jump > 0)
        {
            _RigidBody.AddForce(Vector3.up * jump);
            jump = 0;
        }
    }

    public void Move(Vector2 movement)
    {
        this.movement.z = movement.y;
        this.movement.x = movement.x;
    }

    public void Look(Vector3 look)
    {
        focus = look;

        //Camera.main.transform.LookAt(focusTarget.transform.position);

        updateFocus = true;
    }

    public void SkillInput(InputID input)
    {
        switch(input)
        {
            case InputID.Melee:
                {
                    this.transform.Translate(this.transform.forward, Space.World);
                    break;
                }
            case InputID.Range:
                {
                    this.transform.Translate(this.transform.forward * -1, Space.World);
                    break;
                }
            case InputID.Jump:
                {
                    jump = 50000f;
                    break;
                }
            case InputID.Defend:
                {
                    Debug.Log("Block!");
                    break;
                }
            case InputID.Roll:
                {
                    Debug.Log("Roll!");
                    break;
                }
            default:
                {

                    break;
                }
        }
    }
}
