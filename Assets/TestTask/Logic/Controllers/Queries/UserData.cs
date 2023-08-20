namespace TestTask.Logic.Controllers.Queries
{
    public readonly struct UserData
    {
        public bool IsEmpty => !string.IsNullOrEmpty(Name);
        
        public readonly string Name;
        public readonly int Rank;

        public UserData(string nickname, int rank)
        {
            Name = nickname;
            Rank = rank;
        }
    }
}