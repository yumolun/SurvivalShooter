using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponButton : MonoBehaviour
{
    public PlayerShooting PlayerShooting;
    public int WeaponNumber;
    public Text Name; 
    public Text Cost; 
    public Text Description;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Start()
    {
        SetButton();
    }

    private void SetButton()
    {
        Name.text = PlayerShooting.weapons[WeaponNumber].name;
        Cost.text = "$" + PlayerShooting.weapons[WeaponNumber].Cost;
        Description.text = PlayerShooting.weapons[WeaponNumber].Description;
    }

    public void OnClick()
    {
        if(ScoreManager.score >= PlayerShooting.weapons[WeaponNumber].Cost)
        {
            ScoreManager.score -= PlayerShooting.weapons[WeaponNumber].Cost;
            PlayerShooting.currentWeapon = WeaponNumber;
        }
        else
        {
            source.Play();
        }
    }
}
