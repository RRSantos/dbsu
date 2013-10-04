
namespace dbsu.core.DTO
{
    public abstract class DbBase
    {
        private int getOrder()
        {
            var result = int.MaxValue;
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                var splittedName = this.Name.Split('-');
                if (splittedName.Length > 1)
                    int.TryParse(splittedName[splittedName.Length - 1], out result);
            }

            return result;
        }

        public string Name { get; set; }
        public int Order { get { return this.getOrder(); } }
    }
}
