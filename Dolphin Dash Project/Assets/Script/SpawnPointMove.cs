using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMove : MonoBehaviour
{
    [SerializeField] private float offset;

    private void Update()
    {
        this.transform.position = new Vector3(Camera.main.transform.position.x + offset, 0, 0);
    }
}
