using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPOO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dialogue d=new Dialogue();
        Personne p = d.Interlocuteur1;
        //d.interlocuteur2=p
        d.Interlocuteur2 = p;
        d.Contenu = "coucou";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
