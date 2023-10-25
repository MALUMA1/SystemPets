namespace SysPet.Data
{
    public class DataAccess<T>
    {
        private readonly Repository repository;
        public DataAccess() 
        {
            repository = new Repository();
        }

        public async Task<IEnumerable<T>> GetAll(string sql)
        {
            var items = await repository.QueryAsync<T>(sql);
            return items;
        }

        public async Task<IEnumerable<T>> GetAll(string sql, object param)
        {
            var items = await repository.QueryAsync<T>(sql, param);
            return items;
        }

        public async Task<T> Get(string sql, object param)
        {
            var result = await repository.QuerySingleAsync<T>(sql,param);

            return result;
        }

        public int Execute(string sql)
        {
            var result = repository.Execute<T>(sql);

            return result;
        }

        public int Execute(string sql, object param)
        {
            var result = repository.Execute<T>(sql, param);

            return result;
        }
    }
}
