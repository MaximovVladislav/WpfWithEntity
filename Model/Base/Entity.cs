namespace Model.Base
{
    /// <summary>
    /// Базовый класс для сущности
    /// </summary>
    public abstract class Entity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return Id.Equals((obj as Entity)?.Id);
        }

        protected bool Equals(Entity other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}