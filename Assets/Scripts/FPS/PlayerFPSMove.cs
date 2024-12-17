using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tornado4.Player
{
    public class PlayerFPSMove : MonoBehaviour
    {
        public float speed = 2.0f;

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(horizontal * Time.deltaTime * speed, 0,
                vertical * Time.deltaTime * speed);
        }
    }
}

