using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Tornado4.Player
{
    public class PlayerFPSMove : MonoBehaviour, IJsonSaveable
    {
        public float speed = 2.0f;

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(horizontal * Time.deltaTime * speed, 0,
                vertical * Time.deltaTime * speed);
        }

        public JToken CaptureAsJToken()
        {
            JToken positionJToken = transform.position.ToToken();
            return positionJToken;
        }

        public void RestoreFromJToken(JToken state)
        {
            transform.position = state.ToVector3();
        }
    }
}

