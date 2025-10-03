using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    [Header("config")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private TextMeshProUGUI vidaTMP;

    private float vidaActual;
    private float vidaMax;

    // Update is called once per frame
    void Update()
    {
        ActualizarVidaPersonaje();
    }

    private void ActualizarVidaPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActual / vidaMax, 10f * Time.deltaTime);

        vidaTMP.text = $"{(int)vidaActual} / {(int)vidaMax}";
    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
}
