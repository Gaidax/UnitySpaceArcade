using UnityEngine;
using System.Collections;

public class CometsController : MonoBehaviour {

    private float _speed;
    private float _drift;
    private Transform _transform;

    public Vector2 Player_Pos {
        get
        {
            return GameObject.Find("Plane").transform.position;
        }
        }

    public float Speed {
        get {
            return _speed;
        }
        set {
            _speed = value;
        }
    }

    public float Drift
    {
        get
        {
            return _drift;
        }
        set
        {
            _drift = value;
        }
    }

	// Use this for initialization
	void Start () {
        _transform = GetComponent<Transform>();

        _reset();
	}
	
	// Update is called once per frame
	void Update () {
        _move();
        _checkBounds();
	}

    private void _checkBounds()
    {
        if (_transform.position.x < Player_Pos.x - 6f)
        {
            _reset();
        }
    }

    private void _move()
    {
        Vector2 newPos = _transform.position;

        newPos.x -= Speed;
        newPos.y += Drift;

        _transform.position = newPos;
    }

    private void _reset()
    {
        Speed = Random.Range(0.20f, 0.30f);
        Drift = Random.Range(-0.15f, 0.15f);
        

        _transform.position = new Vector2(Player_Pos.x + 12f, Random.Range(Player_Pos.y-0.5f,Player_Pos.y + 0.5f));
    }
}
