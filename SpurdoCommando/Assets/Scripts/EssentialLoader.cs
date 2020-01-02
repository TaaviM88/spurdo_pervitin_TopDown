using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameManager;
    public GameObject audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (UIManager.Instance == null)
        {
            //UIFade.Instance = Instantiate(UIScreen).GetComponent<UIFade>();
            Instantiate(UIScreen);

        }

        /*if (SpurdoManager.Instance == null)
        {
            GameObject start = GameObject.Find("LevelStartPoint");

            GameObject clone = Instantiate(player, start.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("player found");
        }*/

        if (GameManager.Instance == null)
        {
            Instantiate(gameManager);
        }

        if (AudioManager.Instance == null)
        {
            Instantiate(audioManager);
        }
    }
}
