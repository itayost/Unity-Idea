using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

namespace playerNameSpace
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public GameObject aCamera;
        CharacterController controller;
        float speed = 4;
        float angularSpeed = 100;
        //AudioSource footStepSnd;

        public static bool canMove = true;
        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>(); // connects controller to player's controller
                                                              //footStepSnd = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (canMove)
            {
                float dx, dz;
                float rotationAboutY, rotationAboutX;

                // simple motion
                // transform.Translate(new Vector3(0,0,0.01f));

                rotationAboutX = -Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
                rotationAboutY = Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
                transform.Rotate(new UnityEngine.Vector3(0, rotationAboutY, 0));
                // rotates only camera
                aCamera.transform.Rotate(new UnityEngine.Vector3(rotationAboutX, 0, 0));


                dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;

                UnityEngine.Vector3 motion = new UnityEngine.Vector3(dx, -1, dz); // In Local coordinates

                motion = transform.TransformDirection(motion); // transforms local coordinates to global coordinates

                controller.Move(motion); // in global coordinates
                if (dx != 0 || dz != 0)
                {
                    /*if (!footStepSnd.isPlaying)
                    {
                        footStepSnd.Play();
                    }*/
                }
            }

        }

        public void UpdateSpeed(float additionalSpeed)
        {
            if(speed + additionalSpeed > 0)
            {
                speed += additionalSpeed;
            }
        }

        public static void setCanMove(bool flag)
        {
            canMove = flag;
        }
    }
}
