using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{

    //TRYING A WAY TO START AUDIO AT BEGINNING OF GAME, IGNORE THIS FILE AS IT DOESN'T WORK

    [SerializeField]
    public GameObject menu;
    // Start is called before the first frame update
    void Awake(){
        menu.active = true;
        menu.active = false;
    }
}
