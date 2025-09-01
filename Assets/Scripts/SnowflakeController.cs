using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SnowflakeController : MonoBehaviour
{
    private float MovementSpeed = 1.0f;
    [SerializeField] private Vector2 MovementSpeedRange = new(1.0f, 3.0f);

    private float HorizontalDirectionMovement;

    private Vector2 MovementDirection = Vector2.zero;

    private void Awake()
    {
        MovementDirection = new Vector2(HorizontalDirectionMovement, -1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementSpeed = Random.Range(MovementSpeedRange.x, MovementSpeedRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        MovementDirection = new Vector2(HorizontalDirectionMovement, -1);
        transform.Translate(MovementDirection * (MovementSpeed * Time.deltaTime), Space.World);
    }

    void SetHorizontalMovement(float horizontalMovement)
    {
        HorizontalDirectionMovement =  horizontalMovement;
    }
}
