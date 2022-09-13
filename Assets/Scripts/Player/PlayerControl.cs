using System;
using UnityEngine;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private void Update()
        {
            Control(_speed);
        }

        private void Control(float speed)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Vector3 vectorUp = new Vector3(0,0,1);
                transform.position += vectorUp * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Vector3 vectorUp = new Vector3(0,0,-1);
                transform.position += vectorUp * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Vector3 vectorUp = new Vector3(-1,0,0);
                transform.position += vectorUp * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Vector3 vectorUp = new Vector3(1,0,0);
                transform.position += vectorUp * Time.deltaTime * speed;
            }
        }
    }
}