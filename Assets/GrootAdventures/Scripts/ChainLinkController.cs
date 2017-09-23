using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLinkController : MonoBehaviour {

    ChainLink[] links;

	// Use this for initialization
	void Start () {
        links = GetComponentsInChildren<ChainLink>();
        for (int i = 0; i < links.Length; i++)
        {
            links[i].EventOnNiddleContact += DestroyChain;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DestroyChain()
    {
        for (int i = 0; i < links.Length; i++)
        {
            links[i].CutLink();
        }
    }
}
