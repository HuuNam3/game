using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToWord : MonoBehaviour
{
    public GameObject target;

    private void LateUpdate()
    {
        target = GameObject.FindGameObjectWithTag("word");
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 position = new Vector3(target.transform.position.x, target.transform.position.y + -0.05f, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, position, 12 * Time.deltaTime);
        }
    }
}
