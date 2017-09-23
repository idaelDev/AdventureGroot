using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class GrootController : MonoBehaviour {

    PlatformerCharacter2D character;

	// Use this for initialization
	void Start () {
        character = GetComponent<PlatformerCharacter2D>();
	}
	
	// Update is called once per frame
	void Update () {
        character.Move(1, false, false);
	}
}
