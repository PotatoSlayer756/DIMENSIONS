using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    public GameObject mainmenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            StartingGame();
        }
    }

    void StartingGame()
    {
        mainmenu.SetActive(false);
        Animator animator;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject Go = gameObject.transform.GetChild(i).gameObject;
            animator = Go.GetComponent<Animator>();
            animator.Play("OpeningEYE");
        }
        animator = GetComponent<Animator>();
        animator.Play("scalingintoeye");
    }

    void ToTheNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
