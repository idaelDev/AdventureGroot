using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLink : MonoBehaviour {

    public delegate void OnNiddleContact();
    public event OnNiddleContact EventOnNiddleContact;

    private FixedJoint2D joint;
    private SpriteRenderer renderer;
    private WaitForSeconds wait;

    private void Start()
    {
        joint = GetComponent<FixedJoint2D>();
        renderer = GetComponent<SpriteRenderer>();
        wait = new WaitForSeconds(2);
    }

    IEnumerator FadeCoroutine()
    {
        yield return wait;
        float t = 0;
        while (t < 1)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Lerp(1, 0, t));
            t += Time.deltaTime;
            yield return 0;
        }
        gameObject.SetActive(false);
    }

    public void CutLink()
    {
        joint.enabled = false;
        StartCoroutine(FadeCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Niddle")
        {
            NiddleController nc = collision.gameObject.GetComponent<NiddleController>();
            if (nc.isOnMovement)
            {
                EventOnNiddleContact();
            }
        }
    }

}
