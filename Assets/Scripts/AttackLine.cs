using UnityEngine;
using System.Collections;

public class AttackLine : MonoBehaviour
{
    public LineRenderer line;
    public float length = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ShowLine());
        }
    }

    IEnumerator ShowLine()
    {
        line.enabled = true;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.right * length);

        yield return new WaitForSeconds(0.2f);

        line.enabled = false;
    }
}