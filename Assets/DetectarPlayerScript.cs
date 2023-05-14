using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectarPlayerScript : MonoBehaviour
{
    public GameObject gameOverCanva;
    public Invisibilityskill player;
    public bool playerInvisible;
    // Start is called before the first frame update
    void Start()
    {
        //playerInvisible = player._isInvisible;
        gameOverCanva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // if(!playerInvisible)
        // {
            
        // }
        if(other.CompareTag("Player"))
            {
                StartCoroutine(TelaDeGameOver());
                SceneManager.LoadScene(0);
            }
        
    }

    IEnumerator TelaDeGameOver()
    {
        gameOverCanva.SetActive(true);
        yield return new WaitForSeconds(3f);

    }
}
