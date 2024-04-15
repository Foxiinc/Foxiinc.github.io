using DefaultNamespace;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        ObjectMover[] movers = FindObjectsOfType<ObjectMover>();
        ObjectCreator[] creators = FindObjectsOfType<ObjectCreator>();

        foreach (ObjectMover i in movers)
        {
            i.enabled = false;
        }
        
        foreach (ObjectCreator i in creators)
        {
            i.enabled = false;
        }

        Destroy(GetComponent<PlayerJumper>());
        
        _gameOverScreen.SetActive(true);

        CoinCollector coinCollector = FindObjectOfType<CoinCollector>();

        if (!coinCollector)
        {
            return;
        }
        
        SaveMethods.Save(new DataForSave()
        {
            CoinCount = coinCollector.CoinCapital
        });

        Time.timeScale = 0;
    }
}