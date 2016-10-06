using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private Transform _transform;

    // Use this for initialization
    void Start () {
        _transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 newPos = _transform.position;

        newPos.x -= 0.15f;

        _transform.position = newPos;
    }
}
