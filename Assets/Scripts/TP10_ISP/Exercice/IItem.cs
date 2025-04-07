
namespace TP10
{
    // Interface simple pour les objets
    public interface IItem
    {
        string Name { get; }
        void Use(IGameCharacter character);
    }
}