using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompraFerreiro : MonoBehaviour
{
    [SerializeField]
    public GameObject playerChar;
    public Image FerreiroHUD;
    public Image Seta1;
    public Image Seta2;
    public Image Seta3;
    private int posicaoSeta;
    public int dindin;
    public GameObject hammerBro;
    public GameObject bigAxe;
    // Start is called before the first frame update
    void Start()
    {
        Seta1.enabled = false;
        Seta2.enabled = false;
        Seta3.enabled = false;
        posicaoSeta = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (FerreiroHUD.enabled == true)
        {
            PosicoesSeta();
            if (Input.GetKeyUp("return"))
            {
                
                if ((posicaoSeta == 0) && (dindin >=6))
                {
                    ScoreTextScript.coinAmount -= 6;
                    Instantiate(bigAxe, playerChar.transform.position + playerChar.transform.forward * 2, playerChar.transform.rotation);
                    Debug.Log("Axe");
                }
                if ((posicaoSeta == 1) && (dindin >= 8))
                {
                    ScoreTextScript.coinAmount -= 8;
                    Debug.Log("Mace");
                }
                else if ((posicaoSeta == 2) && (dindin >= 10))
                {
                    ScoreTextScript.coinAmount -= 10;
                    Instantiate(hammerBro, playerChar.transform.position + playerChar.transform.forward * 2, playerChar.transform.rotation);
                    Debug.Log("Hammer");
                }
            }
            
        }
        
    }
    void PosicoesSeta()
    {
        if (Input.GetKeyUp("d"))
        {
            if (posicaoSeta == 0)
            {
                posicaoSeta = 1;
                Seta1.enabled = false;
                Seta2.enabled = true;
                Seta3.enabled = false;
                Debug.Log("Pos1");
            }
            else if (posicaoSeta == 1)
            {
                posicaoSeta = 2;
                Seta1.enabled = false;
                Seta2.enabled = false;
                Seta3.enabled = true;
                Debug.Log("Pos2");
            }
        }
        if (Input.GetKeyUp("a"))
        {
            if (posicaoSeta == 2)
            {
                posicaoSeta = 1;
                Seta1.enabled = false;
                Seta2.enabled = true;
                Seta3.enabled = false;
                Debug.Log("Pos1");
            }
            else if (posicaoSeta == 1)
            {
                posicaoSeta = 0;
                Seta1.enabled = true;
                Seta2.enabled = false;
                Seta3.enabled = false;
                Debug.Log("Pos0");
            }
        }
         
    }

}
