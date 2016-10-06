using UnityEngine;
using System.Collections;

public class SpaceController : MonoBehaviour {
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
        _transform = GetComponent<Transform>();
        _speed = 0.15f;
	}
	
	// Update is called once per frame
	void Update () {
        _move();
        _checkBounds();
	}

    private void _move()
    {
        Vector2 newPosition = _transform.position;
        newPosition.x  -= this._speed;
        _transform.position = newPosition;
    }

    private void _checkBounds()
    {
        if (_transform.position.x <= -45f)
        {
            _reset();
        }
    }

    private void _reset()
    {
        _transform.position = new Vector2(-3.79f, 1.93f);
    }
}
