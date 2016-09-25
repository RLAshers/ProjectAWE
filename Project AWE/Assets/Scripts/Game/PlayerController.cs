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
            Vector3 strafe = Vector3.zero;

            movement *= speed * Time.deltaTime;

            this.transform.Translate(movement, this.transform);

            movement = Vector3.zero;
        }

        if (updateFocus)
        {
            //  Makes the head face in the camera direction
            LookDebug.transform.LookAt(LookDebug.transform.position + focus * 100f);


            float temp = LookDebug.transform.eulerAngles.y - this.transform.eulerAngles.y;

            Debug.Log(temp);

            if (temp > 180)
            {
                temp -= 360;
            }
            else if (temp < -180)
            {
                temp += 360;
            }

            temp = Mathf.Clamp(temp, -10, 10);

            if (Mathf.Abs(temp) > 8)
            {
                //  Makes the body orient itself
                Vector3 bodyOrientation = Vector3.zero;
                bodyOrientation.y += temp * Time.deltaTime * 10f;
                this.transform.eulerAngles += bodyOrientation;
            }

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
        focus = Camera.main.transform.forward;

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
