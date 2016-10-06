using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {
    private float _speed;
    private Transform _transform;


    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
    // Use this for initialization
    void Start () {
        _speed = 0.4f;
        _transform = GetComponent<Transform>();
    }

    private void _move()
    {
             Vector2 newPos = _transform.position;
            newPos.x += Speed;
            _transform.position = newPos;

    }

    // Update is called once per frame
    void Update () {
        _move();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {

            Destroy(gameObject);
        }

    }


}
