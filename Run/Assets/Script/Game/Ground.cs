using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = this.GetComponent<BoxCollider2D>();
        this.width = backgroundCollider.size.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= -width)
        {
            this.Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(this.width * 2, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
