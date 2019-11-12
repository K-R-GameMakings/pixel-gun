using UnityEngine;
using System.Collections;

namespace com.KiaGames.simpleHositle
{
    public class moving_system : MonoBehaviour
    {
        public float sprintmodifier;
        public float speed;
        public float jumpForce;
        private Rigidbody rig;
        public Camera myCamera;
        public float baseFOV;
        public float sprintFovmodifier = 1.15f;
        public Transform Ground_transform;
        public LayerMask Ground;

        // Use this for initialization
        void Start()
        {
            baseFOV = myCamera.fieldOfView;
            rig = GetComponent<Rigidbody>();
            Camera.main.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float move_horizontal = Input.GetAxis("Horizontal");
            float move_vertical = Input.GetAxis("Vertical");
            Vector3 t_diraction = new Vector3(move_horizontal,0, move_vertical);
            t_diraction.Normalize();
            float t_adj = speed;
            bool sprint = Input.GetKey(KeyCode.LeftShift);
            bool jump = Input.GetKey(KeyCode.Space);

            
            bool is_grounded = Physics.Raycast(Ground_transform.position,Vector3.down, 0.1f,Ground);
            bool is_jumping = jump && is_grounded;
            bool is_sprinting = sprint && move_vertical > 0 && !is_jumping && is_grounded;
            if (is_sprinting)
            {
                t_adj *= sprintmodifier;
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, baseFOV * sprintFovmodifier, Time.deltaTime * 8f);
            }
            else
            {
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, baseFOV, Time.deltaTime * 8f);
            }
            if (is_jumping)
            {
                rig.AddForce(Vector3.up * jumpForce);
            }


            Vector3 t_velocity = transform.TransformDirection(t_diraction) * t_adj * Time.deltaTime;
            t_velocity.y = rig.velocity.y;

            rig.velocity = t_velocity;
        }
    }
}