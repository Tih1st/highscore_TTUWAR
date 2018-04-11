using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class EnterName : MonoBehaviour {

    public InputField nameField;
    public GameObject BoardCanvas;
    public GameObject NameCanvas;

    private string charName;

    public void MakeActive()
    {
        BoardCanvas.SetActive(true);
        NameCanvas.SetActive(false);
    }

    public void OnSubmit()
    {
        charName = nameField.text;
        Debug.Log("Your name: " + charName);

        //TODO: GRAB SCORE VALUE FROM AR WORLD SCENE
        Highscores.AddNewHighscore(charName, 100);
        MakeActive();
    }

    

        
}
