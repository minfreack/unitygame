using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary{
	public float xMinimum, xMaximum, yMinimum, yMaximum;
}

public class PlayerController : MonoBehaviour
{		
		public Move moverComponent;
		public float speed;
		public Boundary boundary;

		public Transform shootOrigin;
		public GameObject shootPrefab;
    private void Start()
    {
        moverComponent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {		
			Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical"),
				transform.position.z);
			moverComponent.direction = direction;

			float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
			float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
			transform.position = new Vector3(x, y);

			if (Input.GetButtonDown("Shoot")){
				Instantiate(shootPrefab, shootOrigin, false);
			}
		}
}
