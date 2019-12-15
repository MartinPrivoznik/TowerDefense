using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    public float orthographicSize = 3.056f;
    public float aspect = 1.33333f;
    void Start()
    {
        var camera = Camera.main;
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -camera.orthographicSize * camera.aspect, camera.orthographicSize * camera.aspect,
                -camera.orthographicSize, camera.orthographicSize,
                camera.nearClipPlane, camera.farClipPlane);
    }
}
