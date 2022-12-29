using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using game;

/// <summary>
/// La classe <c>SellScript</c> s'occupe de la vente d'une plante. Elle g�re le curseur (<c>slider</c>) qui a une valeur de d�but et une valeur de fin (<c>endValue</c>).
/// La valeur du curseur correspond � l'attribut <c>resValue</c>. Losqu'on vend, on peut choisir une plante (<c>plantChoosed</c>).
/// Les deux derniers attributs sont : market et transformRef. 
/// </summary>
public class SellScript : MonoBehaviour 
{
    public PopUp classePopup;
    public TextMeshProUGUI endValue;
    public TextMeshProUGUI resValue;
    public Slider slider;
    private EnumTypePlant plantChoosed;
    public Market market;
    public Transform transformRef;

    /// <summary>
    /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. �tant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
    /// Pour notre cas elle choisie d'avoir la plante ELB d�j� s�lectionn�e.
    /// </summary>
    void Start()
    {
        plantChoosed = EnumTypePlant.ELB;
    }

    /// <summary>
    /// La m�thode <c>changePlant</c> permet de changer la plante s�lectionn�e.
    /// </summary>
    /// <param name="newPlant">la nouvelle plante</param>
    public void changePlant(EnumTypePlant newPlant)
    {
        plantChoosed = newPlant;
        slider.value = 0;
    }

    /// <summary>
    /// La m�thode <c>changeMaxValue</c> permet de changer la valeur maximum du curseur.
    /// </summary>
    /// <param name="maxValue">la nouvelle valeur</param>
    public void changeMaxValue(int maxValue)
    {
        endValue.text = maxValue.ToString();
        slider.maxValue = maxValue;
        slider.value = slider.maxValue;
    }

    /// <summary>
    /// La m�thode <c>valueChanged</c> permet de changer la valeur du curseur.
    /// </summary>
    public void valueChanged()
    {

        resValue.text = Math.Round(slider.value) + " : " + (totalPrice());
    }

    /// <summary>
    /// La m�thode <c>totalPrice</c> permet d'indiquer la valeur de la somme que va gagner le joueur.
    /// </summary>
    /// <returns>La somme gagn� par le joueur s'il vend cette quantit�.</returns>
    public int totalPrice()
    {
        int currentValue = (int)Math.Round(slider.value);
        int price = market.getLastPricePlant(plantChoosed);
        return price * currentValue;
    }

    /// <summary>
    /// La m�thode <c>sell</c> permet de vendre la quantit� de plante souhait�e par le joueur.
    /// </summary>
    public void sell()
    {
        if ((int)Math.Round(slider.value) > 0)
        {
            classePopup.message("VENDU!");
            //StartCoroutine(classePopup.message("VENDU!"));

            BasicPlant plante = CreateAllSeedPlant.dicoPlant.createPlant(plantChoosed);
            CreateAllSeedPlant.mainInventory.SubstractFromInventory(plante, (int)Math.Round(slider.value));
            transformRef.GetComponent<Game>().AddMoney(totalPrice());
            changeMaxValue(0);
        }
    }

}