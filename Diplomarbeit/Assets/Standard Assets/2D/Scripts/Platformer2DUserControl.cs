using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
		public GameObject bullet;
		public float speed = 150f;
		public bool move = true;

		private bool shoot = true;
		private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private List<GameObject> bullets = new List<GameObject>();

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

		public void Jump()
		{
			if (!m_Jump)
			{
				// Read the jump input in Update so button presses aren't missed.
				m_Jump = true;
			}
		}
		public void Shoot()
		{
			if ((Input.mousePosition.x > Screen.width / 5 || Input.mousePosition.y > Screen.height / 2.5)&&(Input.mousePosition.x > 60 || Input.mousePosition.y < Screen.height - 60)) 
			{
				Vector3 target = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				target = Camera.main.ScreenToWorldPoint(target);
				target.Set(target.x, target.y, gameObject.transform.position.z);
				
				GameObject obj = bullets.FirstOrDefault(x => !x.activeInHierarchy);
				if (obj == null) 
				{
					obj = (GameObject)Instantiate(bullet);
					bullets.Add(obj);
				}
				obj.SetActive (true);
				obj.transform.position = transform.position;
				obj.transform.rotation = transform.rotation;
				obj.GetComponent<Rigidbody2D>().velocity = (target - transform.position).normalized * speed; 
				shoot = false;
				Invoke ("CanShootAgain",1f);
			}
		}
		private void CanShootAgain()
		{
			shoot = true;
		}
        private void Update()
        {
			if (move) 
			{
				if (!m_Jump)
				{
					// Read the jump input in Update so button presses aren't missed.
					m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
				}
				if(shoot)
				{
					if (Input.GetMouseButtonDown (0)) 
					{
						Shoot ();
					}
				}

			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            // bool crouch = Input.GetKey(KeyCode.LeftControl);
            // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
			if (move) 
			{
				m_Character.Move(1, false, m_Jump);
				m_Jump = false;
			}  
        }
    }
}
