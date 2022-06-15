using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationSelect : MonoBehaviour
{
    public Animator anim;
    private bool animationSelected = false;
    public Button btn1, btn2, btn3, btnContinue;
    public Text msgText;
    public string msg1, msg2, msg3, msgDefault;
    private FootIkSmooth footIk;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        footIk = GetComponent<FootIkSmooth>();
        msgText.text = msgDefault;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectAnimation(int number)
    {
        anim.SetInteger("AnimationNumber", number);
        if (!animationSelected)
        {
            animationSelected = true;
            btnContinue.interactable = true;
        }

        switch (number)
        {
            case 0:
                msgText.text = msg1;
                footIk.offsetFoot = new Vector3(0, 0.18f, 0); 
                break;
            case 1:
                msgText.text = msg2;
                footIk.offsetFoot = new Vector3(0, 0.15f, 0);
                break;
            case 2:
                msgText.text = msg3;
                footIk.offsetFoot = new Vector3(0, 0.15f, 0);
                break;
        }
    }

    public void Continue()
    {
        if (animationSelected)
        {
            //Cargar siguiente escena
            SceneManager.LoadScene("Scene2");
        }
    }
}
