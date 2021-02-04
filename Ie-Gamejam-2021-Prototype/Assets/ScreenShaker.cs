using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    private Vector3 origen;

    private List<float[]> screenShakers = new List<float[]>();

    void Start()
    {
        origen = transform.position;

        EventManager.current.screenShake += AddScreenShake;
    }


    void Update()
    {
        transform.position = origen;

        for (int i = 0; i < screenShakers.Count; i++)
        {
            if (screenShakers[i] != null)
            {
                screenShakers[i][0] -= Time.deltaTime;

                transform.position += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * screenShakers[i][1];

                if (screenShakers[i][0] <= 0)
                {
                    screenShakers[i] = null;
                }
            }
        }
    }

    public void AddScreenShake(float duration, float Amount)
    {
        if (screenShakers.Contains(null))
        {
            for (int i = 0; i < screenShakers.Count; i++)
            {
                if (screenShakers[i] == null)
                {
                    screenShakers[i] = new float[2] { duration, Amount };
                }
            }
        }
        else
        {
            screenShakers.Add(new float[2] { duration, Amount });
        }
    }
}
