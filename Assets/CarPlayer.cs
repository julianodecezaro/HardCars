using UnityEngine;
using System.Collections;

public class CarPlayer : MonoBehaviour {

	public 	GameObject 			Player;
	public 	Rigidbody2D 		PlayerRigidbody;
	public 	int					JumpForce;
	public 	float				CarRotation;
	public	Camera				MainCamera;

	// Use this for initialization
	void Start () {
		CarRotation = 1.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*if (Input.GetButton ("Horizontal")) {
			if (Input.GetAxis ("Horizontal") < 0) {
				CarRotation += (Player.transform.localRotation.z + 1);
			} else {
				CarRotation -= (Player.transform.localRotation.z + 1);			
			}
			Player.transform.localRotation = Quaternion.Euler(0, 0, CarRotation);
		}*/

		//if (Input.GetButton ("Vertical")) {
			//if (Input.GetAxis ("Vertical") < 0) {
				//Debug.Log (CarRotation.ToString());
			//PlayerRigidbody.AddTorque(CarRotation * 4.0f * -0.2f);
			//PlayerRigidbody.AddForce(transform.right * (Input.GetAxis ("Vertical") * -1.0f) * JumpForce * 50.0f);
			PlayerRigidbody.AddForce(transform.right * Input.GetAxis ("Horizontal") * JumpForce * 50.0f);



			//rigidbody2D.AddForce(transform.right * _inputs.y * acceleration * 50.0f);






			//} else {
				//PlayerRigidbody.AddForce (new Vector3((JumpForce * -1) * transform.right.x * transform.forward.x, 0 * transform.forward.y, CarRotation * transform.forward.z));
			//}
		//}

		MainCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);

	}
}
