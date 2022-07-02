using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZarinkinProject
{
    

    public class MiniCamera : MonoBehaviour
    {
        private Camera _camera;
        public Shader _shader;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _shader = Shader.Find("Unlit/Texture");

            if (_shader)
            {
                _camera.SetReplacementShader(_shader, "RenderType");
            }
        }

        private void OnDisable()
        {
            _camera.ResetReplacementShader();
        }
    }

}