using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class BGParallaxEffect : MonoBehaviour
{
    [SerializeField] private float ParallaxSpeedX;
    //private float ParallaxSpeedY;
    private Transform CamTransform;
    private float StartPositionX;
    private float SpriteSizeX;

    private void Awake()
    {
        CamTransform = Camera.main.transform;
        StartPositionX = transform.position.x;
        SpriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float RelativeDisX = CamTransform.position.x * ParallaxSpeedX;

        transform.position = new Vector3(StartPositionX + RelativeDisX, transform.position.y, transform.position.z);

        float RelativecamDisX = CamTransform.position.x * (1 - ParallaxSpeedX);

        if(RelativecamDisX > StartPositionX + SpriteSizeX)
        {
            StartPositionX += SpriteSizeX;
        }
        else if(RelativecamDisX < StartPositionX - SpriteSizeX)
        {
            StartPositionX -= SpriteSizeX;
        }
    }
}
