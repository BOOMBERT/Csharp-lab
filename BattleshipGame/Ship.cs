namespace BattleshipGame
{
    internal class Ship
    {
        private readonly HashSet<(int, int)> takenFields;
        private readonly HashSet<(int, int)> hitFields = new();
        public int Length { get; }

        public Ship(int length, HashSet<(int, int)> takenFields)
        { 
            Length = length;
            this.takenFields = new HashSet<(int, int)>(takenFields);
        }

        public HashSet<(int, int)> GetTakenFields()
        {
            return takenFields;
        }

        public void Hit((int, int) field)
        {
            foreach (var takenField in takenFields)
            {
                if (takenField == field)
                {
                    hitFields.Add(field);
                    break;
                }
            }
        }

        public bool IsSunk()
        {
            return takenFields.Count == hitFields.Count;
        }
    }
}
