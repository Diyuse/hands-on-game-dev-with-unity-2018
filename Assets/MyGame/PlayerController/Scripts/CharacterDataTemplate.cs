using UnityEngine;

namespace MyCompany.MyGame.Player
{
    [CreateAssetMenu(fileName = "New CharacterDataTemplate", menuName = "MyCompany/Data/Create Character Data Template")]
    public class CharacterDataTemplate : ScriptableObject
    {
        [SerializeField] private CharacterData characterData;

        public CharacterData Data
        {
            get { return characterData; }
        }
    }
}
