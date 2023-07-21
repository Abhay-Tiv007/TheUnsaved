using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private bool isDead;
		public bool fridged;
		public Transform shot;
		public GameObject pref;
		public float force;
		public float dur;
		public float angle;
		

		private float curr;
		public int c;


		private float jumpFactor;
		private bool canJump;
		void Start(){
			isDead=false;
		}

		public float getCurr(){
			return curr;
		}

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			fridged=false;
        }


        private void Update()
        {
			if(isDead||fridged||Time.timeScale==0)
				return;
			if(c>0){
			if(CrossPlatformInputManager.GetButton("Fire1")&&curr<dur){
				bool holded;
				if(CrossPlatformInputManager.GetButtonDown("Fire1")){

				}
				curr+=Time.deltaTime;
				shot.eulerAngles=new Vector3(0,0,(curr/dur)*angle*Mathf.Sign(transform.localScale.x));
			}else if(CrossPlatformInputManager.GetButtonUp("Fire1")||curr>=dur){
				c--;
				GameObject tosh=Instantiate(pref,shot.transform.position,Quaternion.identity) as GameObject;
				//tosh.transform.parent=shot;
				tosh.GetComponent<Rigidbody2D>().AddForce(shot.right*force*curr*Mathf.Sign(transform.localScale.x),ForceMode2D.Impulse);
				tosh.transform.parent=null;
				curr=0.0f;
				shot.eulerAngles=new Vector3(0,0,0);
			}
			}

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
				canJump=CrossPlatformInputManager.GetButtonDown("Jump");
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");//||(Mathf.Abs (CrossPlatformInputManager.GetAxis("Jump"))==1.0f);
				//CrossPlatformInputManager.SetAxisZero("Jump");
			}else{
				jumpFactor=0.0f;
				//CrossPlatformInputManager.ResetInputAxes();
			}
        }

        private void FixedUpdate()
        {
			if(isDead||fridged||Time.timeScale==0)
				return;
            // Read the inputs.
			bool crouch = Input.GetKey(KeyCode.LeftControl)||(CrossPlatformInputManager.GetAxis("Vertical")<-0.5);

			float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
			if(CrossPlatformInputManager.GetAxis("Jump")>=1.0f&&canJump){
				m_Character.Move(h, crouch, m_Jump,1.0f);
				canJump=false;
				jumpFactor=0.0f;
			}
			else if(m_Jump) {
				//jumpFactor=0.75f+(CrossPlatformInputManager.GetAxis("Jump"))/4.0f;
				m_Character.Move(h, crouch, m_Jump,1.0f);
				canJump=false;
			}
			m_Character.Move(h, crouch, false,0.0f);
			//if(CrossPlatformInputManager.GetButtonDown("Jump"))
				m_Jump = false;
        }

		public void stopJumpin(){
			m_Jump = false;
		}

		public void PlayerDied(){
			isDead=true;
		}

		public void Freeze(){
			m_Character.Move(0, false, false,0);
			fridged=true;
		}
		public void UnFreeze(){
			fridged=false;
		}
    }
}
