using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
		[Space(5)]
		public float maxDepth=-10;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
			//Player.position.x<boundLeft.position.x||Player.position.x>boundRight.position.x||Player.position.y<boundDown.position.y||Player.position.y>boundUp.position.y)
			//if(transform.position.x<bounds[0].position.x||Player.position.x>bounds[1].position.x||Player.position.y<bounds[2].position.y||Player.position.y>bounds[3].position.y)
				
			if(GameObject.FindGameObjectWithTag("Player").transform.position.y<maxDepth)
				return;
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
			Vector3 newPos1 = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping/4.0f);

			transform.position = new Vector3(newPos.x,newPos1.y,newPos.z);

            m_LastTargetPosition = target.position;
        }
    }
}
