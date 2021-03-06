﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace S3
{
    public class PlayerController : NetworkBehaviour
    {
        private void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

        public override void OnStartLocalPlayer()
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}

