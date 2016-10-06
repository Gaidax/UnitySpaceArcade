using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _playerInput;
    private float _speed;

    [Header("GameController")]
    public GameController gameController;
    // Use this for initialization

    [Header("Elements")]
    public GameObject Laser;
    public GameObject FirePoint;

    void Start () {
        _transform = this.GetComponent<Transform>();
        _speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        _move();
        shoot();
	}

    private void _move()
    {
        _currentPosition = _transform.position;

        _playerInput = Input.GetAxis("Vertical");

        if (_playerInput > 0)
        {
            _currentPosition += new Vector2(0, _speed);
        }

        if (_playerInput < 0)
        {
            _currentPosition -= new Vector2(0, _speed);
        }

        _transform.position = new Vector2(-27.62f, Mathf.Clamp(_currentPosition.y, -5f, 5f));

    }
    private void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Laser, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }

private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Comet"))
        {
            gameController.LivesValue -= 1;

        }

    }
}
