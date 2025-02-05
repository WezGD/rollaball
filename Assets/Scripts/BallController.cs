using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.AI;

namespace Valve.VR.InteractionSystem.Sample
{
    public class BallController : MonoBehaviour
    {
        public Transform Joystick;

        public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
        public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");

        public float speed = 5.0f;
        public float upMult = 250.0f;
        public float joyMove = 0.01f;

        private Interactable interactable;
        private Rigidbody catRb;
        private EnemyMovement enemy;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            catRb = GameObject.Find("/Cat").GetComponent<Rigidbody>();
            enemy = GameObject.Find("/Map/Enemy").GetComponent<EnemyMovement>();
        }

        private void Update()
        {
            Vector3 movement = Vector2.zero;
            bool jump = false;

            if (interactable.attachedToHand)
            {
                SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

                if (enemy != null && !enemy.followTarget)
                {
                    enemy.GetComponent<EnemyMovement>().followTarget = true;
                }
                
                Vector2 m = moveAction[hand].axis;
                movement = new Vector3(m.x, 0.0f, m.y);

                jump = jumpAction[hand].stateDown;
            }

            Joystick.localPosition = movement * joyMove;

            float rot = transform.eulerAngles.y;
            movement = Quaternion.AngleAxis(rot, Vector3.up) * movement;

            if (jump)
            {
                catRb.AddForce(new Vector3(0.0f, this.upMult, 0.0f));
            }

            if (movement.magnitude > 0.1f)
            {
                catRb.MovePosition(catRb.position + movement * speed * Time.deltaTime);

                // Get the target rotation, but only affect the Y axis
                Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
                Quaternion newRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

                catRb.MoveRotation(Quaternion.Slerp(catRb.rotation, newRotation, Time.deltaTime * 10f));
            }
        }
    }
}