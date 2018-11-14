namespace Podemski.Musicorum.Dao.Contexts
{
    internal sealed class FileContext : Context
    {
        private readonly string _fileName;

        internal FileContext(string fileName) => _fileName = fileName;

        public override void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        protected override void LoadContext()
        {
            throw new System.NotImplementedException();
        }
    }
}
