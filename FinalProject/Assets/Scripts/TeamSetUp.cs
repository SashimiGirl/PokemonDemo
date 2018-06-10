using UnityEngine;

public class TeamSetUp : MonoBehaviour
{
    public ChangeScene changeScene;
    const int AREA1 = 2;
    public const int SIZE = 4;
    public PokemonStats pokemonStats;
    public PokemonStats.Stats[] pokePlaya = new PokemonStats.Stats[SIZE];
    public int i = 0;

    void Start()
    {
        changeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        pokemonStats = GameObject.Find("Pokemon").GetComponent<PokemonStats>();
        for (int j = 0; j < SIZE; j++)
            pokePlaya[j] = new PokemonStats.Stats();
    }

    public void SwitchToWalk()
    {
        changeScene.ChangeToScene(AREA1);
    }
}
