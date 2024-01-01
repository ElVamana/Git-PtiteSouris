using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] private int playerMaxHealth;
    [SerializeField] private int playerCurrentHealth;
    private PlayerController _playerController;
    public GameObject pickParticle;
    public Transform topPlayerHead;

    public Image heartIcon;
    Transform heartPanel;
    public Color fillColor, emptyColor;
    public GameObject deathParticle;

    Respawner spawner;




    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawner>();
        spawner.SetPosition(transform.position);
        heartPanel = GameObject.Find("HeartPanel").transform;

        for (int i = 0; i < playerMaxHealth; i++)
        {
            Image icon = Instantiate(heartIcon, heartPanel);
            icon.color = fillColor;
        }
        playerCurrentHealth = playerMaxHealth;
    }


    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            spawner.PlayerIsDead();
            Instantiate(deathParticle, topPlayerHead.position, topPlayerHead.rotation);
            Destroy(gameObject);
        }
        UpdateHeart();

    }

    public void GainMaxHealth()
    {
        GameObject clone = Instantiate(pickParticle, topPlayerHead.position, topPlayerHead.rotation);
        clone.transform.SetParent(topPlayerHead);
        playerMaxHealth += 1;
        ResetHealth();

    }

    public void GainHealth(int amount)
    {
        playerCurrentHealth += amount;
        GameObject clone = Instantiate(pickParticle, topPlayerHead.position, topPlayerHead.rotation);
        clone.transform.SetParent(topPlayerHead);
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        //UpdateHeart();
    }



    public void LoseHealth(int amount, Vector3 push)
    {
        playerCurrentHealth -= amount;

        if (playerCurrentHealth < 0)
        {
            playerCurrentHealth = 0;
        }
        _playerController.controller.Move(-push);
        _playerController.flashRed();
        // UpdateHeart();
    }
   
    public void ResetHealth()
    {
        playerCurrentHealth = playerMaxHealth;
        Image icon = Instantiate(heartIcon, heartPanel);
        icon.color = fillColor;
        //   UpdateHeart();
    }

   
    void UpdateHeart()
    {
        Image[] icons = heartPanel.GetComponentsInChildren<Image>();
        for (int n = 0; n < playerMaxHealth; n++)
        {
            if (n < playerCurrentHealth)
            {
                icons[n+1].color = fillColor;
            }
            else
            {
                icons[n+1].color = emptyColor;
            }
        }
      /*  if (playerCurrentHealth > 0 && playerCurrentHealth < icons.Length)
        {
            icons[playerCurrentHealth].color = emptyColor;
        }*/
    }


}

