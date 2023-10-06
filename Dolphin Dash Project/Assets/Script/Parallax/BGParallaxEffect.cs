using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class BGParallaxEffect : MonoBehaviour
{
    [SerializeField] private float ParallaxSpeedX;
    [SerializeField] private float ParallaxSpeedY;
    //private float ParallaxSpeedY;
    private Transform CamTransform;
    private float StartPositionX;
    private float StartPositionY;
    private float SpriteSizeX;

    private void Awake()
    {
        CamTransform = Camera.main.transform;
        StartPositionX = transform.position.x;
        StartPositionY = transform.position.y;
        SpriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float RelativeDisX = CamTransform.position.x * ParallaxSpeedX;
        float RelativeDisY = CamTransform.position.y * ParallaxSpeedY;

        transform.position = new Vector3(StartPositionX + RelativeDisX, StartPositionY + RelativeDisY, transform.position.z);

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
