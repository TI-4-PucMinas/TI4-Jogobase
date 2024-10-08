using UnityEngine;
using UnityEngine.UI;


public class GerenciadorDvida : MonoBehaviour
{
    public Image BarraDvida;
    public float VidaAtual = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cura(float vida)
    {
        VidaAtual += vida;
        VidaAtual = Mathf.Clamp(VidaAtual, 0,100);


        if (VidaAtual > 100) VidaAtual = 100;

        BarraDvida.fillAmount = VidaAtual / 100f;
    }



    public void machuca(float dano) { 
    
        VidaAtual -= dano;

        BarraDvida.fillAmount = VidaAtual / 100f;
    }

}
