using UnityEngine;
using EnumLibrary;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Vector2 movement = Vector2.zero;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = this.transform.position;
        position.x += movement.x * Time.deltaTime;
        position.z += movement.y * Time.deltaTime;
        this.transform.position = position;
	}

    public void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }

    public void SkillInput(InputID input)
    {
        switch(input)
        {
            case InputID.Melee:
                {
                    this.transform.Translate(this.transform.forward);
                    break;
                }
            case InputID.Range:
                {
                    this.transform.Translate(this.transform.forward * -1);
                    break;
                }
            case InputID.Jump:
                {
                    this.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000f);
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
