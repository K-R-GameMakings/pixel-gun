using UnityEngine;
using System.Collections;
namespace com.KiaGames.simpleHositle
{
    public class Looking_system : MonoBehaviour
    {
        public static bool cur_islocked = true;

        public Transform Player;
        public Transform Cams;

        public float xSensitivity;
        public float ySensitivity;
        public float maxAngle;

        private Quaternion camCenter;
        // Use this for initialization
        void Start()
        {
            camCenter = Cams.localRotation;
        }

        // Update is called once per frame
        void Update()
        {
            SetY();
            SetX();
            Updatecursorlock();


        }

        void SetY()
        {
            float t_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
            Quaternion t_delta = Cams.localRotation * t_adj;
            if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
            {
                Cams.localRotation = t_delta;
            }

        }
        void SetX()
        {
            float t_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
            Quaternion t_delta = Player.localRotation * t_adj;
            
            Player.localRotation = t_delta;
                

        }
        void Updatecursorlock()
        {
            if (cur_islocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    cur_islocked = false;

                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    cur_islocked = true;

                }
            }
        }
    }
}