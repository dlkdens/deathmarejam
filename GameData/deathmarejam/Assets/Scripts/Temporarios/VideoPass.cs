using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitVideo");
    }

    private IEnumerator WaitVideo()
    {
        yield return new WaitForSeconds(35f);

        SceneManager.LoadScene("Fase1");
    }
}
